using Controller;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<Patient> allPatients { get; set; } = new ObservableCollection<Patient>();
        public ObservableCollection<Patient> patients { get; set; }
        public static Patient selectedPatient { get; set; }
        public PatientController patientController { get; set; }
        public PatientsPage()
        {
            InitializeComponent();
            var app = App.Current as App;
            patientController = app.patientController;
            allPatients = new ObservableCollection<Patient>(patientController.GetAll().ToList());
            patients = allPatients;
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void viewPatientsProfile(object sender, RoutedEventArgs e)
        {
            selectedPatient = patients[datagrid.SelectedIndex];
            if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                this.NavigationService.Navigate(new PatientsProfileGPViewPage());
            }
            else
            {
                this.NavigationService.Navigate(new PatientsProfilePage());
            }
        }

        private void searchPatients(object sender, RoutedEventArgs e)
        {
            var dialog = new SearchPatientsDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
            OnPropertyChanged("patients");
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
