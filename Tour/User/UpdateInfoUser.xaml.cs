using System;
using System.Collections.Generic;
using System.Data;
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
using Tour.Classes;

namespace Tour.User
{
    public partial class UpdateInfoUser : Window
    {
        private int _id;
        public UpdateInfoUser(Classes.User user)
        {
            _id = user.Id;
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        public Boolean CheckLogin()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM Users" +
                " WHERE number = '" + Number.Text + "'", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            db.OpenConnection();

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Данный логин уже занят!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdtButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex R = new Regex("\\s+");
                Regex E = new Regex("@");
                Match MEe = E.Match(Email.Text);
                Match MS = R.Match(Surname.Text);
                Match MN = R.Match(Name.Text);
                Match MO = R.Match(Otch.Text);
                Match MP = R.Match(Passport.Text);
                Match MV = R.Match(Visa.Text);
                Match ME = R.Match(Email.Text);
                Match MNu = R.Match(Number.Text);

                for (int i = 0; i < Surname.Text.Length; i++)
                {
                    if (MS.Success)
                    {
                        MessageBox.Show("Поле Фамилия не может быть пустым!");
                        return;
                    }
                }

                for (int i = 0; i < Name.Text.Length; i++)
                {
                    if (MN.Success)
                    {
                        MessageBox.Show("Поле Имя не может быть пустым!");
                        return;
                    }
                }

                for (int i = 0; i < Otch.Text.Length; i++)
                {
                    if (MO.Success)
                    {
                        MessageBox.Show("Поле Отчество не может быть пустым!");
                        return;
                    }
                }

                for (int i = 0; i < Passport.Text.Length; i++)
                {
                    if (MP.Success)
                    {
                        MessageBox.Show("Поле Паспортные данные не может быть пустым!");
                        return;
                    }
                }

                for (int i = 0; i < Visa.Text.Length; i++)
                {
                    if (MV.Success)
                    {
                        MessageBox.Show("Поле Виза не может быть пустым!");
                        return;
                    }
                }

                for (int i = 0; i < Email.Text.Length; i++)
                {
                    if (ME.Success || !MEe.Success)
                    {
                        MessageBox.Show("Поле Email не может быть пустым и должно содержать @!");
                        return;
                    }
                }

                for (int i = 0; i < Number.Text.Length; i++)
                {
                    if (MNu.Success)
                    {
                        MessageBox.Show("Поле Телефон не может быть пустым!");
                        return;
                    }
                }

                if (CheckLogin()) return;

                DB db = new DB();

                SqlCommand command = new SqlCommand("UPDATE Users SET surname = '"
                    + Surname.Text + "', namme = '"
                    + Name.Text + "', otch = '"
                    + Otch.Text + "', passport = '"
                    + Passport.Text + "', visa = '"
                    + Visa.Text + "', email = '"
                    + Email.Text + "', number = '"
                    + Number.Text + "' WHERE id = " + _id + "", db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные сохранены!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Данные не были сохранены!");
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
