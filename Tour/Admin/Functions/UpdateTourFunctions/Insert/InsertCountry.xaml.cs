using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tour.Admin.Functions.UpdateTourFunctions.Insert
{
    public partial class InsertCountry : Window
    {
        public InsertCountry()
        {
            InitializeComponent();

            Visa.Items.Add("Да");
            Visa.Items.Add("Нет");
        }

        private void InsertCountry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Country.Text == "")
                {
                    MessageBox.Show("Поле не может быть пустым!");
                    return;
                }

                if (Visa.SelectedItem == null)
                {
                    MessageBox.Show("Выберите параметр!");
                    return;
                }

                Regex R = new Regex("\\s+");
                Match MC = R.Match(Country.Text);

                for (int i = 0; i < Country.Text.Length; i++)
                {
                    if (MC.Success)
                    {
                        MessageBox.Show("Поле не может быть пустым!");
                        return;
                    }
                }

                DB db = new DB();

                SqlCommand command = new SqlCommand("INSERT INTO Country (namme, visayn) VALUES ('" + Country.Text + "', '" + Visa.SelectedItem + "')", db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Страна добавлен!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Страна не добавлена!");
                    return;
                }

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
