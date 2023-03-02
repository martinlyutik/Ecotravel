using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Tour.Admin.Functions.UpdateTourFunctions.Insert
{
    public partial class InsertCity : Window
    {
        public InsertCity()
        {
            InitializeComponent();

            DB db = new DB();

            SqlCommand command = new SqlCommand("SELECT namme FROM Country", db.GetConnection());

            db.OpenConnection();

            Country.Items.Clear();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Country.Items.Add(reader[0].ToString());
            }
            reader.Close();

            db.CloseConnection();
        }

        private void InsertCity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex R = new Regex("\\s+");
                Match MC = R.Match(City.Text);

                if (City.Text == "")
                {
                    MessageBox.Show("Поле не может быть пустым!");
                    return;
                }

                if (Country.SelectedItem == null)
                {
                    MessageBox.Show("Выберите параметр!");
                    return;
                }

                for (int i = 0; i < City.Text.Length; i++)
                {
                    if (MC.Success)
                    {
                        MessageBox.Show("Поле не может содержать пробелы!");
                        return;
                    }
                }

                DB db = new DB();

                SqlCommand command = new SqlCommand("INSERT INTO City (id_country, namme) VALUES ((SELECT id FROM Country WHERE namme = '" + Country.SelectedItem + "'), '" + City.Text + "')", db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Город был успешно добавлен!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Город не был добавлен!");
                    return;
                }

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }            
        }
    }
}
