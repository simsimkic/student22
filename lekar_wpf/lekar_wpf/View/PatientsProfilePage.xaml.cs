
using Model.Users;
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
    /// Interaction logic for PatientsProfilePage.xaml
    /// </summary>
    public partial class PatientsProfilePage : Page
    {
        public Patient selectedPatient { get; set; }
        public PatientsProfilePage()
        {
            InitializeComponent();
            selectedPatient = PatientsPage.selectedPatient;
            this.DataContext = this;
        }

        private void viewProfile(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DoctorsProfilePage());
        }

        private void viewPatients(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsPage());
        }

        private void viewDrugs(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void viewSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }

        private void viewBlog(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BlogPage());
        }

        private void viewReports(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReportsPage());
        }

        private void scheduleExamination(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ExaminationSchedulingPage());
        }

        private void viewMedicalRecord(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MedicalRecordPage());
        }

        private void writeReport(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WriteReportPage());
        }

        private void writeLaboratoryReferral(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WriteLaboratoryReferral());
        }

        private void writePrescription(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WritePrescriptionPage());
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void scheduleOperation(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OperationScheduling());
        }

        private void hospitalize(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HospitalizationPage());
        }
    }
}
