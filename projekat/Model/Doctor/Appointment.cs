/***********************************************************************
 * Module:  Appointment.cs
 * Purpose: Definition of the Class Model.Appointment
 ***********************************************************************/

using Model.Manager;
using Model.Util;
using ProjekatKlinika.Repository.Abstract;
using System;
using System.ComponentModel;

namespace Model.Doctor
{
   public class Appointment : INotifyPropertyChanged , IIdentifiable<long>
    {
        private long id;

        private Room room;

        private Model.Users.Doctor doctor;

        private Model.Users.Patient patient;

        private Duration duration;

        public Room Room
        {
            get => room; set
            {
                OnPropertyRaised("Room");
                room = value;
            }
        }

        public Users.Doctor Doctor
        {
            get => doctor; set
            {
                OnPropertyRaised("Doctor");
                doctor = value;
            }
        }
        public Users.Patient Patient
        {
            get => patient; set
            {
                OnPropertyRaised("Patient");
                patient = value;
            }
        }
        public Duration Duration
        {
            get => duration; set
            {
                OnPropertyRaised("Duration");
                duration = value;
            }
        }

        public Appointment(Room room, Users.Doctor doctor, Users.Patient patient, Duration duration)
        {
            this.Room = room;
            this.Doctor = doctor;
            this.Patient = patient;
            this.Duration = duration;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            this.id = id;
        }
    }
}