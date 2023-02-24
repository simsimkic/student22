using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DrugsReportPage.xaml
    /// </summary>
    public partial class DrugsReportPage : Page
    {
        public static DateTime startDate;
        public static DateTime enddDate;
        public DrugsReportPage()
        {
            startDate = new DateTime();
            enddDate = new DateTime();
            InitializeComponent();
            this.DataContext = this;
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            start.SelectedDateFormat = DatePickerFormat.Short;
            end.SelectedDateFormat = DatePickerFormat.Short;
            Thread.CurrentThread.CurrentCulture = ci;
            start.DisplayDateEnd = DateTime.Now;
            start.DisplayDateStart = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            start.SelectedDate = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            end.DisplayDateStart = start.SelectedDate;
            end.DisplayDateEnd = DateTime.Now;
            end.SelectedDate = DateTime.Now;
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            startDate = (DateTime)start.SelectedDate;
            enddDate = (DateTime)end.SelectedDate;
            this.NavigationService.Navigate(new DrugsReportSelectDrugs());
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void setEndDate(object sender, RoutedEventArgs e)
        {
            end.DisplayDateStart = start.SelectedDate;
        }
    }
}
