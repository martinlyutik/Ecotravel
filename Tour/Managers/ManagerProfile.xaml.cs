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

namespace Tour.Managers
{
    public partial class ManagerProfile : Window
    {
        public ManagerProfile(Classes.Manager manager)
        {
            InitializeComponent();

            Login.Text = manager.Login;
            Number.Text = manager.Number;
            Email.Text = manager.Email;
            FIO.Text = manager.Fio;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Authentification.LogIn log = new Authentification.LogIn();
            log.Show();
        }

        private void SelectAllUsers_Click(object sender, RoutedEventArgs e)
        {
            SelectAllUsers all = new SelectAllUsers();
            all.Show();
        }

        private void WorkOnTickets_Click(object sender, RoutedEventArgs e)
        {
            SelectAllTickets tick = new SelectAllTickets();
            tick.Show();
        }
    }
}
