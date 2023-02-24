using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for HospitalizationPage.xaml
    /// </summary>
    public partial class HospitalizationPage : Page
    {
        public static string startDate { get; set; }
        public static string endDate { get; set; }
        public HospitalizationPage()
        {
            InitializeComponent();
            this.DataContext = this;
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            datepicker1.SelectedDateFormat = DatePickerFormat.Short;
            datepicker2.SelectedDateFormat = DatePickerFormat.Short;
            datepicker1.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now.AddDays(-1)));
            datepicker1.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(30), DateTime.MaxValue));
            datepicker1.SelectedDate = DateTime.Now;
            datepicker2.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now));
            datepicker2.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(31), DateTime.MaxValue));
            datepicker2.SelectedDate = DateTime.Now.AddDays(1);

        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            startDate = ((DateTime)datepicker1.SelectedDate).ToString("dd/MM/yyyy");
            endDate = ((DateTime)datepicker2.SelectedDate).ToString("dd/MM/yyyy");
            this.NavigationService.Navigate(new HospitalizationRoomSelectionPage());
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

        private void changeEndDates(object sender, RoutedEventArgs e)
        {
            datepicker2.SelectedDate = null;
            datepicker2.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, (DateTime)datepicker1.SelectedDate));
            datepicker2.SelectedDate = ((DateTime)datepicker1.SelectedDate).AddDays(1);
        }
    }
}
