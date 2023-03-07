using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

namespace Tour.Main
{
    public partial class Catalog : Window
    {
        private Classes.User _user;

        private List<string[]> Countries = null;

        private List<string[]> FilteredCountries = null;

        private List<string[]> Cities = null;

        private List<string[]> FilteredCities = null;

        public Catalog(Classes.User user)
        {
            InitializeComponent();

            _user = user;

            Countries = new List<string[]>();
            Cities = new List<string[]>();

            string[] country = null;
            string[] city = null;

            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT namme FROM Country", db.GetConnection());

            SqlCommand cmd = new SqlCommand("SELECT City.namme, Country.namme FROM City LEFT JOIN Country ON City.id_country = Country.id", db.GetConnection());

            db.OpenConnection();

            CountryList.Items.Clear();
            CityList.Items.Clear();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                country = new string[] { reader[0].ToString() };

                Countries.Add(country);
            }
            reader.Close();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                city = new string[] { rdr[0].ToString() + " (" + rdr[1].ToString() + ")" };

                Cities.Add(city);
            }
            rdr.Close();

            db.CloseConnection();

            RefreshCountryList(Countries);

            RefreshCityList(Cities);
        }

        private void FilterCountry_TextChanged(object sender, EventArgs e)
        {
            FilteredCountries = Countries.Where((x) =>
            x[0].ToLower().Contains(FilterCountry.Text.ToLower())).ToList();
            
            RefreshCountryList(FilteredCountries);
        }

        private void FilterCity_TextChanged(object sender, EventArgs e)
        {
            FilteredCities = Cities.Where((x) =>
            x[0].ToLower().Contains(FilterCity.Text.ToLower())).ToList();

            RefreshCityList(FilteredCities);
        }

        private void RefreshCityList(List<string[]> List)
        {
            CityList.Items.Clear();

            foreach (string[] s in List)
            {
                CityList.Items.Add(s[0]);
            }
        }

        private void RefreshCountryList(List<string[]> List)
        {
            CountryList.Items.Clear();                       

            foreach (string[] s in List)
            {
                CountryList.Items.Add(s[0]);
            }            
        }        

        private void CreateTicket_Click(object sender, RoutedEventArgs e)
        {
            Main.TicketTour tick = new Main.TicketTour(_user);
            tick.Show();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User.UserProfile up = new User.UserProfile(_user);
            up.Show();
        }

        private void AlpSortCountry_Click(object sender, RoutedEventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (var item in CountryList.Items)
            {
                list.Add(item);
            }
            list.Sort();

            CountryList.Items.Clear();

            foreach(var item in list)
            {
                CountryList.Items.Add(item);
            }
        }

        private void AlpSortCity_Click(object sender, RoutedEventArgs e)
        {
            ArrayList list = new ArrayList();

            foreach (var item in CityList.Items)
            {
                list.Add(item);
            }
            list.Sort();

            CityList.Items.Clear();

            foreach (var item in list)
            {
                CityList.Items.Add(item);
            }
        }

        private void ClosingButton(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
