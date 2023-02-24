using Model.Doctor;
using Model.Manager;
using Model.Users;
using Guest = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using System;
using System.Windows.Media;
using Model.Patient;
using Model.Util;
using System.Windows;

namespace Sekretar_WPF_Project
{
    /// <summary>
    /// Interaction logic for AddGuestWindow.xaml
    /// </summary>
    public partial class AddGuestWindow : Window
    {
       
        public AddGuestWindow()
        {
            
            InitializeComponent();
            DataContext = ViewModel.getInstance();

            if (Application.Current.MainWindow.Resources["Theme"].Equals(0)) // 1 => Dark Theme , 0 => Light
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.Black);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.White);
            }
            else
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.White);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.Black);
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = this.idtextbox.Text;
                string name = this.name.Text;
                string surname = this.surname.Text;
                string phone = this.phone.Text;
                string email = this.email.Text;
                string date = this.datepicker.Text;
                string start = this.timepickerstart.Text;
                string end = this.timepickerend.Text;

                Room room = (Room)this.roompicker.SelectedItem;
                Doctor doctor = (Doctor)this.doctorpicker.SelectedItem;
                Address address = new Address();
                Patient patient = new Patient();
                patient.medicalRecord = new MedicalRecord();
                patient.name = name;
                patient.surname = surname;
                patient.phoneNumber = phone;
                patient.email = email;
                patient.address = address;
                patient.jmbg = id;
                patient.birthDate = new DateTime();
                patient.username = "Username_Guest";
                patient.password = "Password_Guest";
                patient.isGuest = true;                                                                         
                Model.Util.Duration duration = new Model.Util.Duration();
                duration.StartTime = new DateTime(DateTime.Parse(date).Date.Year, DateTime.Parse(date).Date.Month, DateTime.Parse(date).Date.Day, DateTime.Parse(start).Hour, DateTime.Parse(start).Minute, 0);
                duration.EndTime = new DateTime(DateTime.Parse(date).Date.Year, DateTime.Parse(date).Date.Month, DateTime.Parse(date).Date.Day, DateTime.Parse(end).Hour, DateTime.Parse(end).Minute, 0);
                Appointment appointment = new Appointment(room,doctor,patient,duration);
                
                ViewModel.getInstance().Guests.Add(patient);
                ViewModel.getInstance().Appointments.Add(appointment);
                App app = (App)App.Current;
                app.patientController.Create(patient);
                app.appointmentController.Create(appointment);
                }
                catch
                {
                    MessageBox.Show("Invalid Input");
                }

                Close();
        }
    }
}
