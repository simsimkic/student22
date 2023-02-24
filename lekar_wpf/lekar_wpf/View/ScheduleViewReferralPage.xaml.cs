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
    /// Interaction logic for ScheduleViewReferralPage.xaml
    /// </summary>
    public partial class ScheduleViewReferralPage : Page
    {
        public Appointment selectedAppointment { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public ScheduleViewReferralPage()
        {
            InitializeComponent();
            this.DataContext = this;
            selectedAppointment = SchedulePage.selectedAppointment;
            date = selectedAppointment.StartPoint.ToString("dd/MM/yyyy");
            time = selectedAppointment.StartPoint.ToString("hh:mm");
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
