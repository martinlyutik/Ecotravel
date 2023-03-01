using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

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

                SqlCommand command = new SqlCommand("INSERT INTO Country" +
                    " (namme, visayn) VALUES ('" + Country.Text + "', '"
                    + Visa.SelectedItem + "')", db.GetConnection());

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

        private void ClosingButton(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
