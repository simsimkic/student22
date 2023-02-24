using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekretar_WPF_Project.TestModel
{
    public class Guest : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set {
                OnPropertyRaised("id");
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
        private List<Appointment> appointments;
/*        public List<Appointment> Appointments
        {
            get { return appointments; }
            set
            {
                OnPropertyRaised("Appointments");
                appointments = value;
            }
        }*/
        public List<Appointment> getAppointments()
        {
            return appointments;
        }
        public Guest(int id,string name,string surname,string phone,string email, Appointment appointment)
        {
            this.name = name;
            this.surname = surname;
            this.phone = phone;
            this.email = email;
            this.appointments = new List<Appointment>();
            this.id = id;
            this.appointments.Add(appointment);
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
