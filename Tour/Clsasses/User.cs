using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour.Classes
{
    public class User
    {
        private int id;
        private string namme;
        private string surname;
        private string otch;
        private string passport;
        private string visa;
        private string email;
        private string passwrd;
        private string number;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Namme
        {
            get { return namme; }
            set { namme = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Otch
        {
            get { return otch; }
            set { otch = value; }
        }

        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        public string Visa
        {
            get { return visa; }
            set { visa = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Passwrd
        {
            get { return passwrd; }
            set { passwrd = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public User() { }

        public User(int id, string namme, string surname, string otch, string passport, string visa, string email, string passwrd, string number)
        {
            this.id = id;
            this.namme = namme;
            this.surname = surname;
            this.otch = otch;
            this.passport = passport;
            this.visa = visa;
            this.email = email;
            this.passwrd = passwrd;
            this.number = number;
        }
    }
}
