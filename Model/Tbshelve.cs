using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BookAndShelve.Model
{
    public class Tbshelve : INotifyPropertyChanged
    {
        public int Id { get; set; }

//        public string Name { get; set; }
        private string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Titeel { get; set; }
        public Tbuser User { get; set; }
        public string UserId { get; set; }
        public List<TbBookAndShelve> bookAndShelvecs { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
