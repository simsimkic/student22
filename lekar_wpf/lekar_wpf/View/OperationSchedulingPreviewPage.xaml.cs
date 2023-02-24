using lekar_wpf.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for OperationSchedulingPreviewPage.xaml
    /// </summary>
    public partial class OperationSchedulingPreviewPage : Page
    {
        public string currentDate { get; set; }
        public string currentTime { get; set; }
        public string operationDate { get; set; }
        public string operationTime { get; set; }
        public string room { get; set; } = "401";
        public Patient selectedPatient { get; set; }
        public OperationSchedulingPreviewPage()
        {
            this.DataContext = this;
            currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime = DateTime.Now.ToString("hh:mm");
            operationDate = OperationDateSchedulingPage.selectedDate;
            operationTime = OperationTimeSchedulingPage.selectedTime;
            if(OperationScheduling.room != null)
            {
                room = OperationScheduling.room;
            }
            //selectedPatient = PatientsPage.selectedPatient;
            InitializeComponent();
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            Appointment ap = new Appointment();
            ///ap.Doctor = DoctorsProfilePage.signedIn;
            //ap.Patient = PatientsPage.selectedPatient;
            ap.Room = room;
            string[] parts = operationDate.Split('/');
            string[] parts2 = operationTime.Split(':');
            ap.StartPoint = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]), int.Parse(parts2[0]), int.Parse(parts2[1]), 0);
            ap.EndPoint = ap.StartPoint.AddHours(OperationScheduling.Hours);
            ap.EndPoint = ap.EndPoint.AddMinutes(OperationScheduling.Minutes);
            ap.Type = "Operacija";
            int index = -1;
            foreach(Appointment a in MainWindow.appointments)
            {
                if(a.EndPoint.Ticks < ap.StartPoint.Ticks)
                {
                    continue;
                }
                else
                {
                    index = MainWindow.appointments.IndexOf(a);
                    break;
                }
            }
            if(index >= 0)
            {
                MainWindow.appointments.Insert(index, ap);
            }
            else
            {
                MainWindow.appointments.Add(ap);
            }
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new OperationDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                this.NavigationService.Navigate(new PatientsProfileGPViewPage());
            }
            else
            {
                this.NavigationService.Navigate(new PatientsProfilePage());
            }
        }
    }
}
