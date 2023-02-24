using Controller;
using Model.Users;
using Repository;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public static DoctorController doctorController { get; set; }
        public static Doctor signedIn { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = App.Current as App;
            doctorController = app.doctorController;
        }

        private void check(object sender, RoutedEventArgs e)
        {
            if(username.Text.Length > 49)
            {
                username.BorderBrush = Brushes.Red;
            }
            else
            {
                username.BorderBrush = Brushes.LightBlue;
            }
            if (password.Password.Length > 49)
            {
                password.BorderBrush = Brushes.Red;
            }
            else
            {
                password.BorderBrush = Brushes.LightBlue;
            }
        }

        private void nextPage(object sender, RoutedEventArgs e)
        {
            Doctor d;
            d = doctorController.LogIn(username.Text, password.Password);
            if (d == null)
            {
                poruka2.Visibility = Visibility.Visible;
                poruka1.Visibility = Visibility.Hidden;
            }
            else
            {
                poruka1.Visibility = Visibility.Hidden;
                poruka2.Visibility = Visibility.Hidden;
                signedIn = d;
                this.NavigationService.Navigate(new WizardPatients());
            }
        }
    }
}
