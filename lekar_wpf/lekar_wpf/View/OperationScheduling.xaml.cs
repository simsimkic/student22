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
    /// Interaction logic for OperationScheduling.xaml
    /// </summary>
    public partial class OperationScheduling : Page, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public static int Hours { get; set; }
        public static int Minutes { get; set; }
        public static string room { get; set; }
        public OperationScheduling()
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
            Hours = int.Parse(hours.Text);
            Minutes = int.Parse(minutes.Text);
            if(combobox.SelectedIndex >= 0)
            {
                room = combobox.SelectedValue.ToString().Split(':')[1].Substring(1);
            } else
            {
                room = null;
            }
            this.NavigationService.Navigate(new OperationDateSchedulingPage());
        }

        private void check(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            string hoursStr = hours.Text;
            Regex regex = new Regex("(^[0-9]$)|(^[0-3][0-9]$)");
            if(!regex.IsMatch(hoursStr))
            {
                hours.BorderBrush = System.Windows.Media.Brushes.Red;
                hours.BorderThickness = new Thickness(1);
                valid = false;
            } else
            {
                hours.BorderBrush = System.Windows.Media.Brushes.LightBlue;  
            }
            string minutesStr = minutes.Text;
            Regex regex2 = new Regex("(^[0-9]$)|([0-5][0-9])");
            if (!regex2.IsMatch(minutesStr))
            {
                minutes.BorderBrush = System.Windows.Media.Brushes.Red;
                minutes.BorderThickness = new Thickness(1);
                valid = false;
            }
            else
            {
                minutes.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if(hoursStr.Equals("0") || hoursStr.Equals("00"))
            {
                if(minutesStr.Equals("0") || minutesStr.Equals("00"))
                {
                    hours.BorderBrush = System.Windows.Media.Brushes.Red;
                    hours.BorderThickness = new Thickness(1);
                    minutes.BorderBrush = System.Windows.Media.Brushes.Red;
                    minutes.BorderThickness = new Thickness(1);
                    valid = false;
                }
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
