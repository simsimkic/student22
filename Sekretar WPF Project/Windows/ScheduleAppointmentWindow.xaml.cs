using Model.Doctor;
using Model.Manager;
using Model.Users;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model.Util;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sekretar_WPF_Project.Windows
{
    /// <summary>
    /// Interaction logic for ScheduleAppointmentWindow.xaml
    /// </summary>
    public partial class ScheduleAppointmentWindow : Window
    {
        MainWindow main;
        public ScheduleAppointmentWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            DataContext = ViewModel.getInstance();
            main = mainWindow;

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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = idtextbox.Text;
                string date = datepicker.Text;
                string start = timepickerstart.Text;
                string end = timepickerend.Text;
                Room room = (Room)roomcombobox.SelectedItem;
                Doctor doctor = (Doctor)doctorcombobox.SelectedItem;            
                App app = (App)App.Current;
                Patient patient = app.patientController.Get(long.Parse(id));
                Model.Util.Duration duration = new Model.Util.Duration();
                duration.StartTime = new DateTime(DateTime.Parse(date).Date.Year, DateTime.Parse(date).Date.Month, DateTime.Parse(date).Date.Day, DateTime.Parse(start).Hour, DateTime.Parse(start).Minute, 0);
                duration.EndTime = new DateTime(DateTime.Parse(date).Date.Year, DateTime.Parse(date).Date.Month, DateTime.Parse(date).Date.Day, DateTime.Parse(end).Hour, DateTime.Parse(end).Minute, 0);
                Appointment appointment = new Appointment(room, doctor, patient, duration);
                app.appointmentController.Create(appointment);
                ViewModel.getInstance().Appointments.Add(appointment);
                main.refreshRoomSchedule();
           }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
            Close();
        }
    }
}
