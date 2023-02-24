using Model.Patient;
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
    /// Interaction logic for WritingReportPreviewPage.xaml
    /// </summary>
    public partial class WritingReportPreviewPage : Page
    {
        public string currentTime { get; set; }
        public string currentDate { get; set; }
        public Patient selectedPatient { get; set; }
        public Report report { get; set; }
        public WritingReportPreviewPage()
        {
            InitializeComponent();
            this.DataContext = this;
            currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime = DateTime.Now.ToString("hh:mm");
            selectedPatient = PatientsPage.selectedPatient;
            //report = WriteReportPage.report;
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            //selectedPatient.Reports.Insert(0, report);
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new ReportDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
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
