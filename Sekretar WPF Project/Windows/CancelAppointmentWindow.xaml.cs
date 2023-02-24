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
    /// Interaction logic for CancelAppointmentWindow.xaml
    /// </summary>
    public partial class CancelAppointmentWindow : Window
    {
        Appointment appointment;
        MainWindow main;
        public CancelAppointmentWindow(Appointment appointment, MainWindow mainwindow)
        {
            this.appointment = appointment;
            main = mainwindow;
            InitializeComponent();
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

        private void Button_ConfirmDelete(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            app.appointmentController.Delete(appointment);
            ViewModel.getInstance().Appointments.Remove(appointment);
            main.refreshRoomSchedule();
            Close();
        }
    }
}
