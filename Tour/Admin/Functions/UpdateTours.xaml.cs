using System.Windows;

namespace Tour.Admin.Functions
{
    public partial class UpdateTours : Window
    {
        public UpdateTours()
        {
            InitializeComponent();
        }

        private void DeleteCountry_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Delete.DeleteCountry del = new UpdateTourFunctions.Delete.DeleteCountry();
            del.Show();
        }

        private void CreateCountry_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Insert.InsertCountry ins = new UpdateTourFunctions.Insert.InsertCountry();
            ins.Show();
        }

        private void DeleteCity_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Delete.DeleteCity ct = new UpdateTourFunctions.Delete.DeleteCity();
            ct.Show();
        }

        private void CreateCity_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Insert.InsertCity cit = new UpdateTourFunctions.Insert.InsertCity();
            cit.Show();
        }

        private void DeleteTypeVac_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Delete.DeleteTypeVac vac = new UpdateTourFunctions.Delete.DeleteTypeVac();
            vac.Show();
        }

        private void CreateTypeVac_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Insert.InsertTypeVac vac = new UpdateTourFunctions.Insert.InsertTypeVac();
            vac.Show();
        }

        private void DeleteVidTransp_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Delete.DeleteVidTransp tr = new UpdateTourFunctions.Delete.DeleteVidTransp();
            tr.Show();
        }

        private void CreateVidTransp_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Insert.InsertVidTransp vid = new UpdateTourFunctions.Insert.InsertVidTransp();
            vid.Show();
        }

        private void DeleteVidRazm_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Delete.DeleteVidRazm raz = new UpdateTourFunctions.Delete.DeleteVidRazm();
            raz.Show();
        }

        private void CreateVidRazm_Click(object sender, RoutedEventArgs e)
        {
            UpdateTourFunctions.Insert.InsertVidRazmesch raz = new UpdateTourFunctions.Insert.InsertVidRazmesch();
            raz.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Admin adm = new Admin();
            adm.Show();
        }

        private void ClosingButton(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
