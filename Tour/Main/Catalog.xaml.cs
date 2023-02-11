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

namespace Tour.Main
{
    public partial class Catalog : Window
    {
        private Classes.User _user;

        public Catalog(Classes.User user)
        {
            InitializeComponent();

            _user = user;
        }

        private void CreateTicket_Click(object sender, RoutedEventArgs e)
        {
            User.TicketTour tick = new User.TicketTour(_user);
            tick.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Authentification.LogIn log = new Authentification.LogIn();
            log.Show();
        }
    }
}
