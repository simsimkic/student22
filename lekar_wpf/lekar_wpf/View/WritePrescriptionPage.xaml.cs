using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for WritePrescriptionPage.xaml
    /// </summary>
    public partial class WritePrescriptionPage : Page, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public static string Diagnosis { get; set; }
        public static string Comment { get; set; }
        public static string Name { get; set; }
        public static string Code { get; set; }
        public static int Times { get; set; }
        public static int Perday { get; set; }
        public WritePrescriptionPage()
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

        private void nextStep(object sender, RoutedEventArgs e)
        {
            Diagnosis = diagnosis.Text;
            Name = name.Text;
            Code = code.Text;
            Times = int.Parse(times.Text);
            Perday = int.Parse(perday.Text);
            Comment = comment.Text;
            this.NavigationService.Navigate(new WritePrescriptionPreviewPage());
        }

        private void check(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            if(diagnosis.Text.Equals(""))
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.Red;
                diagnosis.BorderThickness = new Thickness(1, 1, 1, 1);
                isButtonEnabled = false;
                valid = false;
            } else
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if (name.Text.Equals(""))
            {
                name.BorderBrush = System.Windows.Media.Brushes.Red;
                name.BorderThickness = new Thickness(1, 1, 1, 1);
                isButtonEnabled = false;
                valid = false;
            }
            else
            {
                name.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if (code.Text.Equals(""))
            {
                code.BorderBrush = System.Windows.Media.Brushes.Red;
                code.BorderThickness = new Thickness(1, 1, 1, 1);
                isButtonEnabled = false;
                valid = false;
            }
            else
            {
                code.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            Regex regex = new Regex("^[1-9]([0-9])?$");
            if(!regex.IsMatch(times.Text))
            {
                times.BorderBrush = System.Windows.Media.Brushes.Red;
                times.BorderThickness = new Thickness(1, 1, 1, 1);
                isButtonEnabled = false;
                valid = false;
            }
            else
            {
                times.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if (!regex.IsMatch(perday.Text))
            {
                perday.BorderBrush = System.Windows.Media.Brushes.Red;
                perday.BorderThickness = new Thickness(1, 1, 1, 1);
                isButtonEnabled = false;
                valid = false;
            }
            else
            {
                perday.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            isButtonEnabled = valid;
            OnPropertyChanged("isButtonEnabled");
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
