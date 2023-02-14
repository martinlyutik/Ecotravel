using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Tour.Admin.Functions.UpdateTourFunctions.Delete
{
    public partial class DeleteVidTransp : Window
    {
        public DeleteVidTransp()
        {
            InitializeComponent();

            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("SELECT namme FROM Vid_Transp", db.GetConnection());

                db.OpenConnection();

                VidTransp.Items.Clear();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VidTransp.Items.Add(reader[0].ToString());
                }
                reader.Close();

                db.CloseConnection();
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void DeleteVidTransp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();

                SqlCommand command = new SqlCommand("DELETE FROM Vid_Transp WHERE namme = " + VidTransp.SelectedItem, db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Удаление произвдено успешно!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("При удалении произошла ошибка!");
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
