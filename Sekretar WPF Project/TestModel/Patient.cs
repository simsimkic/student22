using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekretar_WPF_Project.TestModel
{
    public class Patient
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                OnPropertyRaised("Id");
                id = value;
            }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                OnPropertyRaised("Name");
                name = value;
            }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                OnPropertyRaised("Surname");
                surname = value;
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                OnPropertyRaised("Phone");
                phone = value;
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                OnPropertyRaised("Email");
                email = value;
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                OnPropertyRaised("Address");
                address = value;
            }
        }
        
        private string birthdate;
        public string Birthdate
        {
            get { return birthdate; }
            set
            {
                OnPropertyRaised("Birthdate");
                birthdate = value;
            }
        }
        private string gender;
        public string Gender
        {
            get { return gender; }
            set
            {
                OnPropertyRaised("Gender");
                gender = value;
            }
        }
        private string parentName;
        public string ParentName
        {
            get { return parentName; }
            set
            {
                OnPropertyRaised("ParentName");
                parentName = value;
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                OnPropertyRaised("Username");
                username = value;
            }
        }

        public Patient(string id, string name, string surname, string phone, string email ,string address, string birthdate, string gender, string parentname, string username)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.birthdate = birthdate;
            this.gender = gender;
            this.parentName = parentname;
            this.username = username;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
