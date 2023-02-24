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
    /// Interaction logic for ExaminationSchedulingPreviewPage.xaml
    /// </summary>
    public partial class ExaminationSchedulingPreviewPage : Page
    {
        public string originalnoOdeljenje { get; set; }
        public string currentDate { get; set; }
        public string currentTime
        {
            get; set;

        }
        public Patient selectedPatient
        {
            set; get;
        }
        public string Odeljenje { get; set; }
        public string DoctorName { get; set; }
        public string Diagnosis
        {
            get; set;
        }
        public string Date { get; set; }
        public string Time { get; set; }
        public ExaminationSchedulingPreviewPage()
        {
            this.DataContext = this;
            if(DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                originalnoOdeljenje = "Opsta praksa";
            } else
            {
                originalnoOdeljenje = "Kardiologija";
            }
            currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime = DateTime.Now.ToString("hh:mm");
            //selectedPatient = PatientsPage.selectedPatient;
            Odeljenje = ExaminationSchedulingPage.selectedOdeljenje;
            DoctorName = ExaminationSchedulingPage.selectedDoctorName;
            Diagnosis = ExaminationSchedulingDiagnosisPage.Diagnosis;
            Date = ExaminationDateSchedulingPage.selectedDate;
            Time = ExaminationTimeSchedulingPage.selectedTime;
            InitializeComponent();
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            if(DoctorName.Equals(Data.specialist.FullName))
            {
                Appointment ap = new Appointment();
                //ap.Doctor = DoctorsProfilePage.signedIn;
                //ap.Patient = PatientsPage.selectedPatient;
                ap.Room = "307";
                string[] parts = Date.Split('/');
                string[] parts2 = Time.Split(':');
                ap.StartPoint = new DateTime(int.Parse(parts[2]), int.Parse(parts[1]), int.Parse(parts[0]), int.Parse(parts2[0]), int.Parse(parts2[1]), 0);
                ap.EndPoint = ap.StartPoint.AddMinutes(20);
                ap.Type = "Pregled";
                int index = -1;
                foreach (Appointment a in MainWindow.appointments)
                {
                    if (a.EndPoint.Ticks < ap.StartPoint.Ticks)
                    {
                        continue;
                    }
                    else
                    {
                        index = MainWindow.appointments.IndexOf(a);
                        break;
                    }
                }
                if (index >= 0)
                {
                    MainWindow.appointments.Insert(index, ap);
                }
                else
                {
                    MainWindow.appointments.Add(ap);
                }
            }
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new ExaminationSchedulingDialog();
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
