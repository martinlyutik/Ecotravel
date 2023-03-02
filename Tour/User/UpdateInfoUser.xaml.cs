using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace Tour.User
{
    public partial class UpdateInfoUser : Window
    {
        private int _id;
        public UpdateInfoUser(Classes.User user)
        {
            _id = user.Id;
            InitializeComponent();

            Name.Text = user.Namme;
            Surname.Text = user.Surname;
            Otch.Text = user.Otch;
            Email.Text = user.Email;
            Visa.Text = user.Visa;
            Passport.Text = user.Passport;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
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

                if (Email.Text == "" || Surname.Text == "" 
                    || Name.Text == "" || Otch.Text == "" 
                    || Passport.Text == "" || Visa.Text == "")
                {
                    MessageBox.Show("Поля не могут быть пустыми!");
                    return;
                }

                for (int i = 0; i < Surname.Text.Length; i++)
                {
                    if (MS.Success)
                    {
                        MessageBox.Show("Поле Фамилия не может содержать пробелы!");
                        return;
                    }
                }

                for (int i = 0; i < Name.Text.Length; i++)
                {
                    if (MN.Success)
                    {
                        MessageBox.Show("Поле Имя не может содержать пробелы!");
                        return;
                    }
                }

                for (int i = 0; i < Otch.Text.Length; i++)
                {
                    if (MO.Success)
                    {
                        MessageBox.Show("Поле Отчество не может содержать пробелы!");
                        return;
                    }
                }

                for (int i = 0; i < Passport.Text.Length; i++)
                {
                    if (MP.Success)
                    {
                        MessageBox.Show("Поле Паспортные данные не может содержать пробелы!");
                        return;
                    }
                }

                for (int i = 0; i < Visa.Text.Length; i++)
                {
                    if (MV.Success)
                    {
                        MessageBox.Show("Поле Виза не может содержать пробелы!");
                        return;
                    }
                }

                for (int i = 0; i < Email.Text.Length; i++)
                {
                    if (ME.Success || !MEe.Success)
                    {
                        MessageBox.Show("Поле Email не может содержать пробелы и должно содержать @!");
                        return;
                    }
                }

                DB db = new DB();

                SqlCommand command = new SqlCommand("UPDATE Users SET surname = '"
                    + Surname.Text + "', namme = '"
                    + Name.Text + "', otch = '"
                    + Otch.Text + "', passport = '"
                    + Passport.Text + "', visa = '"
                    + Visa.Text + "', email = '"
                    + Email.Text + "' WHERE id = " + _id + "", db.GetConnection());

                db.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Данные изменены!");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Данные не были изменены!");
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
