using Model.Doctor;
using Model.Manager;
using Model.Users;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    /// Interaction logic for RescheduleAppointmentWindow.xaml
    /// </summary>
    public partial class RescheduleAppointmentWindow : Window
    {
        Appointment appointment;
        MainWindow main;
        public RescheduleAppointmentWindow(Appointment appointment, MainWindow mainWindow)
        {   
            InitializeComponent();
            this.appointment = appointment;
            DataContext = ViewModel.getInstance();
            main = mainWindow;
            try {
                this.appointment = appointment;
                this.idtextbox.Text = appointment.Patient.IdNumber.ToString();
                this.datepicker.SelectedDate = appointment.Duration.StartTime.Date;
                this.startimepicker.Text = appointment.Duration.StartTime.Hour+":"+appointment.Duration.StartTime.Minute;
                this.endtimepicker.Text = appointment.Duration.EndTime.Hour + ":" + appointment.Duration.EndTime.Minute;
                this.roomcombobox.SelectedItem = appointment.Room;
                this.doctorcombobox.SelectedItem = appointment.Doctor;
            }
            catch
            {
                MessageBox.Show("Cannot parse data to show in textboxes");
            }

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
            Appointment a = appointment;
            try
            {
                string id = idtextbox.Text;
                string date = datepicker.Text;
                string start = startimepicker.Text;
                string end = endtimepicker.Text;
                Room room = (Room)this.roomcombobox.SelectedItem;
                Doctor doctor = (Doctor)this.doctorcombobox.SelectedItem;

                App app = (App)App.Current;
                Appointment appointment1 = app.appointmentController.Get(a.GetId());
                app.appointmentController.Delete(appointment1);
                ViewModel.getInstance().Appointments.Remove(a);
            
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
