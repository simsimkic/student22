
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
    /// Interaction logic for HospitalizedPatientsProfilePage.xaml
    /// </summary>
    public partial class HospitalizedPatientsProfilePage : Page
    {
        public Patient selectedPatient { get; set; }
        public HospitalizedPatientsProfilePage()
        {
            InitializeComponent();
            this.DataContext = this;
            selectedPatient = PatientsPage.selectedPatient;
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

        private void viewMedicalRecord(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MedicalRecordPage());
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void scheduleOperation(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OperationScheduling());
        }

        private void viewHospitalizationHistory(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HospitalizationHistoryPage());
        }
    }
}
