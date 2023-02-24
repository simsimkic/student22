using Model.Manager;
using Model.Users;
using Room = Model.Manager.Room;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Model.Patient;
using Model.Util;
using System.Linq;

namespace Sekretar_WPF_Project.VM
{
    public class ViewModel
    {
        private static ViewModel instance = new ViewModel();
        public ObservableCollection<Guest> Guests { get; set; }
        public ObservableCollection<Patient> Patients { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<Appointment> Appointments { get; set; }
        public ObservableCollection<Room> Rooms { get; set; }
        public ObservableCollection<String> Genders { get; set; }

        private ViewModel()
        {
            Guests = new ObservableCollection<Guest> { };
            AddGuestsFromRepo();

            Patients = new ObservableCollection<Patient> { };
            AddPatientsFromRepo();

            Doctors = new ObservableCollection<Doctor> { };
            AddDoctorsFromRepo();

            Rooms = new ObservableCollection<Room> { };
            AddRoomFromRepo();

            Appointments = new ObservableCollection<Appointment> { };
            AddAppointmentFromRepo();

            Genders = new ObservableCollection<String> { };
            Genders.Add("Male");
            Genders.Add("Female");
        }

        public static ViewModel getInstance()
        {
            return instance;
        }

        App app = (App)App.Current;

        void AddGuestsFromRepo()
        {
            foreach (Guest guest in (List<Patient>)app.patientController.GetAll())
            {
                if (guest.isGuest)
                {
                    Guests.Add(guest);
                }
            }
        }
        void AddPatientsFromRepo()
        {
            foreach (Patient patient in (List<Patient>)app.patientController.GetAll())
            {
                if (!patient.isGuest)
                {
                    Patients.Add(patient);
                }
            }
        }
        void AddDoctorsFromRepo()
        {
            foreach (Doctor doc in (List<Doctor>)app.doctorController.GetAll())
            {
                Doctors.Add(doc);
            }
        }
        void AddAppointmentFromRepo()
        {
            foreach (Appointment app in (List<Appointment>)app.appointmentController.GetAll())
            {
                Appointments.Add(app);
            }
        }
        void AddRoomFromRepo()
        {
            foreach (Room room in (List<Room>)app.roomController.GetAll())
            {
                Rooms.Add(room);
            }
        }

        public ObservableCollection<Appointment> getAppointmentsForGuest(Guest guest) 
        {
            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>(); 
            foreach(Appointment app in Appointments)
            {
                if (app.Patient != null)
                {
                    if (app.Patient.IdNumber.Equals(guest.IdNumber))
                        apps.Add(app);
                }
            }
            return apps;
        }
        public ObservableCollection<Appointment> getAppointmentsForPatient(Patient patient)
        {
            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>();
            foreach (Appointment app in Appointments)
            {
                if (app.Patient != null)
                {
                    if (app.Patient.IdNumber.Equals(patient.IdNumber))
                        apps.Add(app);
                }
            }
            return apps;
        }
        public ObservableCollection<Appointment> getAppointmentsForDoctor(Doctor doctor)
        {
            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>();
            foreach (Appointment app in Appointments)
            {
                if (app.Doctor != null)
                {
                    if (app.Doctor.LicenseNumber.Equals(doctor.LicenseNumber))
                        apps.Add(app);
                }
            }
            return apps;
        }

        public ObservableCollection<Appointment> getAppointmentsForRoom(Room room)
        {
            if (room == null)
                return null;
            ObservableCollection<Appointment> apps = new ObservableCollection<Appointment>();
            foreach (Appointment app in Appointments)
            {
                if (app.Room != null)
                {
                    if (app.Room.RoomNumber.Equals(room.RoomNumber))
                        apps.Add(app);
                }
            }
            return apps;
        }

    }
}
