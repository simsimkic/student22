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
    /// Interaction logic for ExaminationSchedulingDiagnosisPage.xaml
    /// </summary>
    public partial class ExaminationSchedulingDiagnosisPage : Page, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; }
        public static string Diagnosis { get; set; }
        public ExaminationSchedulingDiagnosisPage()
        {
            InitializeComponent();
            this.DataContext = this;
            isButtonEnabled = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void nextStep(object sender, RoutedEventArgs e)
        {
            Diagnosis = diagnosis.Text;
            this.NavigationService.Navigate(new ExaminationSchedulingPreviewPage());
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
            if (diagnosis.Text.Equals("") || diagnosis.Text.Length > 200)
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.Red;
                diagnosis.BorderThickness = new Thickness(1);
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            }
            else
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.LightBlue;
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
