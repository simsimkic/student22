using lekar_wpf.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for WriteReportPage.xaml
    /// </summary>
    public partial class WriteReportPage : Page, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public static Report report { get; set; }
        public WriteReportPage()
        {
            InitializeComponent();
            this.DataContext = this;
            report = new Report();
            report.Date = DateTime.Now.ToString("dd/MM/yyyy");
            report.Doctor = DoctorsProfilePage.signedIn.name + " " + DoctorsProfilePage.signedIn.surname; 
            if(DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                report.Odeljenje = "Opsta praksa";
            } else
            {
                report.Odeljenje = "Kardiologija";
            }
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

        private void check(object sender, RoutedEventArgs e)
        {
            if (dijagnoza.Text == null || dijagnoza.Text.Equals(""))
            {
                isButtonEnabled = false;
            } else
            {
                isButtonEnabled = true;
            }
            OnPropertyChanged("isButtonEnabled");
        }
        private void nextStep(object sender, RoutedEventArgs e)
        {
            report.Diagnosis = dijagnoza.Text;
            report.Comment = nalaz.Text;
            this.NavigationService.Navigate(new WritingReportPreviewPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
