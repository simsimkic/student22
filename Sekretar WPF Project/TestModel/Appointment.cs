using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekretar_WPF_Project.TestModel
{
    public class Appointment : INotifyPropertyChanged
    {
        private string patientID;
        public string PatientId
        {
            get { return patientID; }
            set
            {
                OnPropertyRaised("PatientID");
                patientID = value;
            }
        }

        private string date;
        public string Date
        {
            get { return date; }
            set
            {
                OnPropertyRaised("Date");
                date = value;
            }
        }
        private string timestart;
        public string Timestart
        {
            get { return timestart; }
            set
            {
                OnPropertyRaised("timestart");
                timestart = value;
            }
        }
        private string timeend;
        public string Timeend
        {
            get { return timeend; }
            set
            {
                OnPropertyRaised("timeend");
                timeend = value;
            }
        }
        private Room room;
        public Room getRoom()
        {
            return room;
        }
        public string Room
        {
            get { return room.name; }
        }

        private Doctor doctor;
        public Doctor getDoctor()
        {
            return doctor;
            /*get { return doctor; }
            set
            {
                OnPropertyRaised("Doctor");
                doctor = value;
            }*/
        }

        public string Doctor
        {
            get { return doctor.Name+" "+doctor.Surname; }
        }

        public Appointment(string patientID, string date, string start, string end, Room room, Doctor doctor)
        {
            this.PatientId = patientID;
            this.date = date;
            this.timestart = start;
            this.timeend = end;
            this.room = room;
            this.doctor = doctor;
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
