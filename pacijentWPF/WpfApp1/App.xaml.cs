using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model.Users;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using Repository;
using Service;

namespace HCI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string PATIENTS_FILE = "..\\..\\..\\..\\projekat\\Resources\\patients.json";
        private const string DOCTORS_FILE = "..\\..\\..\\..\\projekat\\Resources\\doctors.json";

        public PatientController patientController;
        public DoctorController doctorController;

        public App()
        {

            PatientRepository patientRepository = new PatientRepository(
                new JsonStream<Patient>(PATIENTS_FILE),
                new LongSequencer());
            PatientService patientService = new PatientService(patientRepository);
            patientController = new PatientController(patientService);

            
            DoctorRepository doctorRepository = new DoctorRepository(
               new JsonStream<Doctor>(DOCTORS_FILE),
               new LongSequencer());
            DoctorService doctorService = new DoctorService(doctorRepository);
            doctorController = new DoctorController(doctorService);

            /*
            Doctor doctor = new Doctor();
            doctor.email = "tamararankovic@gmail.com";
            doctor.password = "pera";
            doctor.name = "Tamara";
            doctor.surname = "Rankovic";
            doctorController.Create(doctor);
            */


            Patient patient = new Patient();
            patient.email = "milijana@gmail.com";
            patient.password = "pera";

            //patientController.Create(patient);
        }



    }
}
