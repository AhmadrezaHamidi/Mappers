using BookAndShelve.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;
using BookAndShelve.DbContext;

namespace BookAndShelve.XmlFile
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    
    public partial class Register : Window
    {
        private readonly MyDbContext _MyDb;
        public Register()
        {
            _MyDb = new MyDbContext();
            InitializeComponent();
            
            this.DataContext = this;
            Gender = new List<string> { "man", "woman" }; 

        }
        private string _firstName;
        public string FirstNametTxt
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }
        private string _lastName;
        public string LastNameTxt
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        private string _emailAddrss;
        public string EmailAddressTxt
        {
            get
            { return _emailAddrss;}
            set
            { _emailAddrss = value; }
        }
        private string _ageTxt;
        public string AgeTxt {
            get { return _ageTxt; }
            set { _ageTxt = value; } 
        }
        private string _selectedGender;
        public string SelectedGender
        {
            get { return _selectedGender; }
            set { _selectedGender = value; }
        }
        private List<string> _gender;
        public List<string> Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        private string _passWord;
        public string PassWord
        { get { return _passWord; }
            set { _passWord = value; } 
        }
        private string _passWordRip;
        public string RepeatPassword
        { get { return _passWordRip; } 
            set { _passWordRip = value; } }

       

        private bool _acceptRuls;

        public bool AcceptRuls
        {
            get { return _acceptRuls; }
            set { _acceptRuls = value; }
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_MyDb.Users.Any(x => x.Email == EmailAddressTxt))
            {
                MessageBox.Show("This email is exist later");
            }

            Tbuser user1 = new Tbuser
            {
                FirstName = FirstNametTxt,
                LastName = LastNameTxt,
                Age =int.Parse(AgeTxt), 
                Sex = SelectedGender,
                PasswordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(PassWord)),
                UserName=FirstNametTxt
                //Roole
                

            };
           /// user1.Id = null;
            _MyDb.users.Add(user1);
            _MyDb.SaveChanges();
            MessageBox.Show("Register is okey");
            var login = new Login();
            login.Show();


        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrEmpty(FirstNametTxt) &&
            !string.IsNullOrEmpty(LastNameTxt) &&
            !string.IsNullOrEmpty(EmailAddressTxt) &&
            !string.IsNullOrEmpty(AgeTxt) &&
            !string.IsNullOrEmpty(SelectedGender) &&
            AcceptRuls.Equals(true) && !string.IsNullOrEmpty(PassWord) && !string.IsNullOrEmpty(RepeatPassword) && PassWord == RepeatPassword;
            //


        }
    }
}
