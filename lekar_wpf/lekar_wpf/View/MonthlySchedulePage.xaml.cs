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
    /// Interaction logic for MonthlySchedulePage.xaml
    /// </summary>
    public partial class MonthlySchedulePage : Page
    {
        public static bool opened = false;
        public MonthlySchedulePage()
        {
            InitializeComponent();
            this.DataContext = this;
            calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now.AddDays(-1)));
            calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(30), DateTime.MaxValue));
            calendar.SelectedDate = DateTime.Now;
            calendar.FirstDayOfWeek = DayOfWeek.Monday;
            opened = false;
        }

        private void showDaily(object sender, SelectionChangedEventArgs e)
        {
            if(opened)
            {
                opened = false;
                int difference = ((DateTime)calendar.SelectedDate).DayOfYear - DateTime.Now.DayOfYear;
                this.NavigationService.Navigate(new SchedulePage(difference));
            } else
            {
                opened = true;
            }
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

        private void viewDailySchedule(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
                this.NavigationService.Navigate(new SchedulePage());
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }
    }
}
