using BookAndShelve.DbContext;
using BookAndShelve.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for UserAccunt.xaml
    /// </summary>
    public partial class UserAccunt : Window
    {
        private readonly MyDbContext MyDb;
        private Tbuser _user;
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
                //    OnPropertyChanged("Shelves");
            }
        }

        public UserAccunt(string UserName)
        {
            InitializeComponent();
            this.DataContext = this;
            MyDb = new MyDbContext();
            _user = MyDb.Users.Where(x => x.UserName == UserName).FirstOrDefault();
            Shelves = new ObservableCollection<Tbshelve> (MyDb.Shelves.Where(x => x.UserId == _user.Id).ToList());
            
        }

        private  ICommand _profileCommand;
        
        public ICommand ProfileCommand => _profileCommand != null ? _profileCommand : new DelegateCommand(ExecuteProfileCommand);
        private void ExecuteProfileCommand(object parameter)
        {
            var Register = new Register();
            Register.Show();
        }
        private ICommand _ShelveCommand;

        public ICommand ShelveCommand => _ShelveCommand != null ? _ShelveCommand : new DelegateCommand(ExecuteShelveCommand);
        private void ExecuteShelveCommand(object parameter)
        {
            var Register = new Librery(_user.UserName);
            Register.Show();
        }


        //public List<Tbshelve> shelve
        //{
        //    get { return _shelvve; }
        //    set { _shelvve = value; }
        //}

    }
}
