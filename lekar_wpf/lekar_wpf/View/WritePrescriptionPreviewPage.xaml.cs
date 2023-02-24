
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
    /// Interaction logic for WritePrescriptionPreviewPage.xaml
    /// </summary>
    public partial class WritePrescriptionPreviewPage : Page
    {
        public string Diagnosis { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Times { get; set; }
        public int Perday { get; set; }
        public Patient selectedPatient { get; set; }
        public string Recept { get; set; }
        public WritePrescriptionPreviewPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Diagnosis = WritePrescriptionPage.Diagnosis;
            Comment = WritePrescriptionPage.Comment;
            Name = WritePrescriptionPage.Name;
            Code = WritePrescriptionPage.Code;
            Times = WritePrescriptionPage.Times;
            Perday = WritePrescriptionPage.Perday;
            selectedPatient = PatientsPage.selectedPatient;
            Recept = "Piti lek " + Times + " puta na " + Perday + "dana. Napoemna: " + Comment; 
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsProfilePage());
            var dialog = new PrescriptionDialog();
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
