using BookAndShelve.DbContext;
using System;
using System.Collections.Generic;
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

namespace BookAndShelve.XmlFile
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly MyDbContext MyDb;

        public Login()
        {
            this.DataContext = this;
            MyDb = new MyDbContext();
            InitializeComponent();
        }
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var FoundUser = MyDb.Users.Where(x => x.UserName == UserName).FirstOrDefault();
            if (FoundUser == null)
            {
                MessageBox.Show("this user is not exist");
            }
            else
            {
                if (FoundUser.PasswordHash == Convert.ToBase64String(Encoding.UTF8.GetBytes(((PasswordBox)e.Parameter).Password)))
                { 
                    var PaygeOfical = new UserAccunt(FoundUser.UserName);
                    PaygeOfical.Show();
                }
                else
                {
                    MessageBox.Show("the pasword is not correct");
                }
            }
        }
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) 
        {
            e.CanExecute = !string.IsNullOrEmpty(UserName);
        }


    }
}
