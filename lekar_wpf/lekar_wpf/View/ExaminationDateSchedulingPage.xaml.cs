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
    /// Interaction logic for ExaminationDateSchedulingPage.xaml
    /// </summary>
    public partial class ExaminationDateSchedulingPage : Page
    {
        public static string selectedDate { get; set; }
        public ExaminationDateSchedulingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now.AddDays(-1)));
            calendar.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddMonths(6), DateTime.MaxValue));
            calendar.SelectedDate = DateTime.Now;
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            selectedDate = ((DateTime)calendar.SelectedDate).ToString("dd/MM/yyyy");
            this.NavigationService.Navigate(new ExaminationTimeSchedulingPage());
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
