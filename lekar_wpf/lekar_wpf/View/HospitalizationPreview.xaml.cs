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
    /// Interaction logic for HospitalizationPreview.xaml
    /// </summary>
    public partial class HospitalizationPreview : Page
    {
        public string currentDate { get; set;}
        public string currentTime { get; set; }
        public string startDate
        {
            get; set;
        }
        public string endDate { get; set; }
        public Patient selectedPatient { get; set; }
        public string diagnosis { get; set; }
        public string room
        {
            get; set;
        }
        public HospitalizationPreview()
        {
            InitializeComponent();
            this.DataContext = this;
            currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime = DateTime.Now.ToString("hh:mm");
            startDate = HospitalizationPage.startDate;
            endDate = HospitalizationPage.endDate;
            diagnosis = HospitalizationDiagnosisPage.Diagnosis;
            room = HospitalizationRoomSelectionPage.selectedRoom;
            //selectedPatient = PatientsPage.selectedPatient;
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new HospitalizationDialog();
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
