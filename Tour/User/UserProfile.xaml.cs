using System.Windows;
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

            Who.Content = "Профиль пользователя " + user.Namme;

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
            this.Hide();
            Main.Catalog catalog = new Main.Catalog(_user);
            catalog.Show();
        }

        private void CheckTickets_Click(object sender, RoutedEventArgs e)
        {
            CheckTicket tick = new CheckTicket(_user);
            tick.Show();
        }
    }
}
