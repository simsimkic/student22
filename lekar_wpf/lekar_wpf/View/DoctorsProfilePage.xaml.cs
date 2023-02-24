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
    /// Interaction logic for DoctorsProfilePage.xaml
    /// </summary>
    public partial class DoctorsProfilePage : Page
    {
        public static Doctor signedIn { get; set; }
        public string BirthDate { get; set; }
        public DoctorsProfilePage()
        {
            InitializeComponent();
            signedIn = LoginPage.signedIn;
            this.DataContext = this;
            BirthDate = signedIn.birthDate.ToString("dd/MM/yyyy");
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

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void logOut(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void viewHelpPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HelpPage());
        }

        private void viewSettingsPage(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage());
        }
    }
}
