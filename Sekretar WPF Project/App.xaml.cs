using Sekretar_WPF_Project.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model.Users;
using Repository;
using ProjekatKlinika.Repository.JSON.Stream;
using ProjekatKlinika.Repository.Sequencer;
using Model.Doctor;
using Model.Manager;
using Service;
using ProjekatKlinika.Controller;
using ProjekatKlinika.Repository;

namespace Sekretar_WPF_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string PATIENTS_FILE = "D:/Software/Git/projekat_klinika/projekat/Resources/patients.json";
        private const string APPOINTMENTS_FILE = "D:/Software/Git/projekat_klinika/projekat/Resources/appointments.json";
        private const string DOCTORS_FILE = "D:/Software/Git/projekat_klinika/projekat/Resources/doctors.json";
        private const string ROOMS_FILE = "D:/Software/Git/projekat_klinika/projekat/Resources/rooms.json";
        private const string SECRETARIES_FILE = "D:/Software/Git/projekat_klinika/projekat/Resources/secretaries.json";

        public PatientController patientController = new PatientController(new PatientService(new PatientRepository(
        new JsonStream<Patient>(PATIENTS_FILE),
        new LongSequencer())));

        public AppointmentController appointmentController = new AppointmentController(new AppointmentService(new AppointmentRepository(
        new JsonStream<Appointment>(APPOINTMENTS_FILE),
        new LongSequencer())));

        public DoctorController doctorController = new DoctorController(new DoctorService(new DoctorRepository(
        new JsonStream<Doctor>(DOCTORS_FILE),
        new LongSequencer())));

        public RoomController roomController = new RoomController(new RoomService(new RoomRepository(
        new JsonStream<Room>(ROOMS_FILE),
        new LongSequencer())));

        public SecretaryController secretaryController = new SecretaryController(new SecretaryService(new SecretaryRepository(
        new JsonStream<Secretary>(SECRETARIES_FILE),
        new LongSequencer())));

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
