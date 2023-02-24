using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lekar_wpf.Model
{
    public class Doctor : INotifyPropertyChanged
    {
        private string fullName;
        private string birthDate;
        private string specialization;
        private double rating;
        private string phoneNumber;
        private string email;
        private string address;
        private string jmbg;
        private string licenceNumber;
        private string password;

        public string  FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public  string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string LicenceNumber
        {
            get { return licenceNumber; }
            set { licenceNumber = value; }
        }

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public string BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
