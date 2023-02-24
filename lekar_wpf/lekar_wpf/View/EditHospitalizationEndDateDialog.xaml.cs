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
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for EditHospitalizationEndDateDialog.xaml
    /// </summary>
    public partial class EditHospitalizationEndDateDialog : Window
    {
        public EditHospitalizationEndDateDialog()
        {
            InitializeComponent();
            this.DataContext = this;
            datepicker.BlackoutDates.Add(new CalendarDateRange(DateTime.MinValue, DateTime.Now.AddDays(-1)));
            datepicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddMonths(1), DateTime.MaxValue));
            //datepicker.SelectedDate = PatientsPage.selectedPatient.EndOfHospitalization;
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void change(object sender, RoutedEventArgs e)
        {
            //PatientsPage.selectedPatient.EndOfHospitalization = (DateTime)datepicker.SelectedDate;
            this.Close();
        }
    }
}
