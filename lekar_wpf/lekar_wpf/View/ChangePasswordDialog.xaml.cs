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
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public bool first { get; set; } = false;
        public bool second { get; set; } = false;
        public bool third { get; set; } = false;
        public ChangePasswordDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void change(object sender, RoutedEventArgs e)
        {
            SettingsPage.current.password = newPass.Password;
            this.Close();
        }

        private void checkCurrentPassword(object sender, RoutedEventArgs e)
        {
            if(current.Password.Equals(Data.signedIn.Password))
            {
                poruka1.Visibility = Visibility.Hidden;
                first = true;
                if (first && second && third)
                {
                    isButtonEnabled = true;
                    OnPropertyChanged("isButtonEnabled");
                }
                else
                {
                    isButtonEnabled = false;
                    OnPropertyChanged("isButtonEnabled");
                }
            } else
            {
                poruka1.Visibility = Visibility.Visible;
                first = false;
                
            }
        }

        private void checkNewassword(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9!#$]{8,}$");
            if (regex.IsMatch(newPass.Password))
            {
                poruka2.Visibility = Visibility.Hidden;
                second = true;
                if (first && second && third)
                {
                    isButtonEnabled = true;
                    OnPropertyChanged("isButtonEnabled");
                }
                else
                {
                    isButtonEnabled = false;
                    OnPropertyChanged("isButtonEnabled");
                }
            }
            else
            {
                poruka2.Visibility = Visibility.Visible;
                second = false; ;
                
            }
        }

        private void checkNewassword2(object sender, RoutedEventArgs e)
        {
            if (newPass.Password.Equals(newPass2.Password))
            {
                poruka3.Visibility = Visibility.Hidden;
                third = true;
                if(first && second && third)
                {
                    isButtonEnabled = true;
                    OnPropertyChanged("isButtonEnabled");
                }
                else
                {
                    isButtonEnabled = false;
                    OnPropertyChanged("isButtonEnabled");
                }
            }
            else
            {
                poruka3.Visibility = Visibility.Visible;
                third = false;
                
            }
        }
    }
}
