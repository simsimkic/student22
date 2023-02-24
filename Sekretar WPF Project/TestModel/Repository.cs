using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sekretar_WPF_Project.TestModel
{
    public class Repository
    {
        /*        private static Repository instance = new Repository();
                private List<Guest> guests = new List<Guest>();
                private List<Patient> patients = new List<Patient>();
                private List<Doctor> doctors = new List<Doctor>();
                private List<Appointment> appointments = new List<Appointment>();
                private List<Room> rooms = new List<Room>();*/

        private Repository()
        {
            /*Doctor doc1 = new Doctor(0,"doctorname0", "doctorsurname0","not a surgeon");
            Doctor doc2 = new Doctor(1, "somedoctorname", "somedoctorsurname567", "surgeon4"); //paziti da license numberi ne budu isti

            Room room1 = new Room("soba1");
            Room room2 = new Room("soba2");
            Room room3 = new Room("soba3");
            Appointment app1 = new Appointment("1","12.4.2021", "12:00", "15:00", room1, doc1);
            Appointment app2 = new Appointment("23", "1.1.2020", "14:00", "14:30", room3, doc2);
            Appointment app3 = new Appointment("1232", "1.2.2019", "10:00", "13:00", room3, doc2);

            Guest guest = new Guest(0,"defaultname", "defaultsurname", "123321", "defaultemail", app1);
            Guest guest2 = new Guest(1, "defaultname", "defaultsurname", "124354", "defaultemail", app3);
            Patient patient = new Patient("123","patname","patsurname","123123","email@email","adress nr.5","1.1.1998","Male","patientparentname","username");

            doctors.Add(doc1);
            doctors.Add(doc2);
            patients.Add(patient);
            guests.Add(guest);
            guests.Add(guest2);
            appointments.Add(app1);
            appointments.Add(app2);
            appointments.Add(app3);
            rooms.Add(room1);
            rooms.Add(room2);
            rooms.Add(room3);

        }

        public static Repository getInstance()
        {
            return instance;
        }

        public List<Guest> Guests { get => guests; set => guests = value; }
        public List<Patient> Patients { get => patients; set => patients = value; }
        public List<Doctor> Doctors { get => doctors; set => doctors = value; }
        public List<Appointment> Appointments { get => appointments; set => appointments = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

        public List<Appointment> getAppointmentsForGuest(Guest guest)
        {
            List<Appointment> apps = new List<Appointment>();
            foreach (Appointment app in Appointments)
            {
                if (app.PatientId.Equals(guest.Id.ToString()))
                    apps.Add(app);
            }
            return apps;
        }*/

        }
    }
}
