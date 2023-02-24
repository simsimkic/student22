
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
    /// Interaction logic for WriteLaboratoryReferralPreviewPage.xaml
    /// </summary>
    public partial class WriteLaboratoryReferralPreviewPage : Page
    {
        public string diagnosis { get; set; }
        public string text { get; set; }
        public string currentDate { get; set; }
        public string currentTime { get; set; }
        public Patient selected { get; set; }
        public string docName { get; set; }
        public WriteLaboratoryReferralPreviewPage()
        {
            InitializeComponent();
            this.DataContext = this;
            diagnosis = WriteLaboratoryReferral.Diagnosis;
            text = WriteLaboratoryReferral.Text;
            currentDate = DateTime.Now.ToString("dd/MM/yyyy");
            currentTime = DateTime.Now.ToString("hh:mm");
            selected = PatientsPage.selectedPatient;
            docName = DoctorsProfilePage.signedIn.name + " " + DoctorsProfilePage.signedIn.surname;
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new LaboratoryReferralDialog();
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
