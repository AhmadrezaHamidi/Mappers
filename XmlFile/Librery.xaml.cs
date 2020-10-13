using BookAndShelve.DbContext;
using BookAndShelve.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookAndShelve.XmlFile
{
    /// <summary>
    /// Interaction logic for Librery.xaml
    /// </summary>
    public partial class Librery : Window , INotifyPropertyChanged
    {
        private readonly MyDbContext MyDb;
        private Tbuser _user;
        public event PropertyChangedEventHandler PropertyChanged;
        public Librery(string UserName)
        {
            InitializeComponent();
            this.DataContext = this;
            MyDb = new MyDbContext();
            _user = MyDb.Users.Where(x => x.UserName == UserName)
                .FirstOrDefault();
            SelectedShelve = new Tbshelve();
            SelectedBook = new tbBook();
            ///  Shelves = new ObservableCollection<Tbshelve>(MyDb.Shelves.Where(x => x.UserId == _user.Id).ToList());
            ///  

        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        

        //        public ObservableCollection<Tbshelve> Shelves { get; set; }
        private ObservableCollection<Tbshelve> _shelves;

        public ObservableCollection<Tbshelve> Shelves
        {
            get
            {
                return _shelves;
            }
            set
            {
                _shelves = value;
                OnPropertyRaised(nameof(Shelves));
            }
        }
        private Tbshelve _selectedShelve;

        public Tbshelve SelectedShelve
        {
            get { return _selectedShelve; }
            set
            {
                _selectedShelve = value;
                OnPropertyRaised(nameof(Shelves));
                Bookes = new ObservableCollection<tbBook>(MyDb.BookAndShelvecs
               .Where(x => x.Shelved == SelectedShelve.Id).Include(x => x.book).Select(x => x.book).ToList());
                OnPropertyRaised(nameof(Bookes));
                OnPropertyRaised(nameof(SelectedShelve));
            }
        }
        private ObservableCollection<tbBook> _bookes;
        public ObservableCollection<tbBook> Bookes
        {
            get
            {
                return _bookes;
            }
            set
            {
                _bookes = value;
                OnPropertyRaised(nameof(Bookes));
            }
        }
        private tbBook _selectedBook;

        public tbBook SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                OnPropertyRaised(nameof(Bookes));
                OnPropertyRaised(nameof(SelectedBook));

            }
        }


        private ICommand _libarayCommand;
        public ICommand LibarayCommand => _libarayCommand != null ? _libarayCommand : new DelegateCommand(ExecuteLibarayCommand);
        private void ExecuteLibarayCommand(object parameter)
        {
          
            Shelves = new ObservableCollection<Tbshelve>(MyDb.Shelves.Where(x => x.UserId == _user.Id).ToList());
           
            //  PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Shelves)));3
        }
        private ICommand _updateshelve;
        public ICommand UpdateShelveCommand => _updateshelve != null ? _updateshelve : new DelegateCommand(CanExecuteUpdateShele , ExecuteUpdateshelveCommand);
        private void ExecuteUpdateshelveCommand(object parameter)
        {
            var newshelve=MyDb.Shelves.Where(x => x.Id == SelectedShelve.Id).FirstOrDefault();
            newshelve.Titeel = SelectedShelve.Titeel;
            newshelve.Name = SelectedShelve.Name;


            MyDb.SaveChanges();

            //  PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Shelves)));3
        }
        public bool CanExecuteUpdateShele(object parameter)
        {
            return SelectedShelve != null;
        }

    }
}
