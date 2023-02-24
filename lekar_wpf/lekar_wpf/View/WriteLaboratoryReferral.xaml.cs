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
    /// Interaction logic for WriteLaboratoryReferral.xaml
    /// </summary>
    public partial class WriteLaboratoryReferral : Page, INotifyPropertyChanged
    {
        public static string Diagnosis {get; set;}
        public static string Text { get; set; }
        public bool isButtonEnabled { get; set; } = false;
        public WriteLaboratoryReferral()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
            bool valid = true;
            if(diagnosis.Text.Equals(""))
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.Red;
                diagnosis.BorderThickness = new Thickness(1, 1, 1, 1);
                valid = false;
            }
            else
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if(text.Text.Equals(""))
            {
                text.BorderBrush = System.Windows.Media.Brushes.Red;
                text.BorderThickness = new Thickness(1, 1, 1, 1);
                valid = false;
            }
            else
            {
                text.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            isButtonEnabled = valid;
            OnPropertyChanged("isButtonEnabled");
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            Diagnosis = diagnosis.Text;
            Text = text.Text;
            this.NavigationService.Navigate(new WriteLaboratoryReferralPreviewPage());
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
