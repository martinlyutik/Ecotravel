using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour.Classes
{
    public class Manager
    {
        private int id;
        private string fio;
        private string number;
        private string email;
        private string loginn;
        private string passwrd;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Fio
        {
            get { return fio; }
            set { fio = value; }
        }

        public string Number
        { 
            get { return number; }
            set { number = value; }
        }

        public string Email
        { 
            get { return email; }
            set { email = value; }
        }

        public string Login
        {
            get { return loginn; }
            set { loginn = value; }
        }

        public string Password
        { 
            get { return passwrd; }
            set { passwrd = value; }
        }

        public Manager() { }

        public Manager(int id, string fio, string number, string email, string loginn, string passwrd)
        {
            this.id = id;
            this.fio = fio;
            this.number = number;
            this.email = email;
            this.loginn = loginn;
            this.passwrd = passwrd;
        }
    }
}
