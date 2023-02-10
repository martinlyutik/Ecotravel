using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tour.Authentification;

namespace Tour.User
{
    public partial class UserProfile : Window
    {
        private Classes.User _user;
        public UserProfile(Classes.User user)
        {
            _user = user;

            InitializeComponent();

            Surn.Text = user.Surname;
            Name.Text = user.Namme;
            Otch.Text = user.Otch;
            Passport.Text = user.Passport;
            Visa.Text = user.Visa;
            Number.Text = user.Number;
            Email.Text = user.Email;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LogIn log = new LogIn();
            log.Show();
        }

        private void UpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfoUser updt = new UpdateInfoUser(_user);
            updt.Show();
        }

        private void OpenCatalog_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
