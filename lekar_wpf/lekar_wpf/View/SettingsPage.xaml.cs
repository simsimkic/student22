using Controller;
using Model.Users;
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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page, INotifyPropertyChanged
    {
        public static Doctor signedIn { get; set; }
        public static Doctor current { get; set; }
        public static bool enabled { get; set; } = false;
        public static bool fullNameEnabled { get; set; } = true;
        public static bool phoneNumberEnabled { get; set; } = true;
        public static bool emailEnabled { get; set; } = true;
        public static bool addressEnabled { get; set; } = true;
        public static bool licenceNumberEnabled { get; set; } = true;
        public static bool jmbgEnabled { get; set; } = true;
        public static bool birthDateEnabled { get; set; } = true;
        public string BirthDate { get; set; }
        public bool isButtonEnabled { get; set; }
        public DoctorController doctorController;
        public SettingsPage()
        {
            InitializeComponent();
            signedIn = LoginPage.signedIn;
            this.DataContext = this;
            current = new Doctor();
            current.address = signedIn.address;
            current.birthDate = signedIn.birthDate;
            current.email = signedIn.email;
            current.name = signedIn.name;
            current.surname = signedIn.surname;
            current.jmbg = signedIn.jmbg;
            current.LicenseNumber = signedIn.LicenseNumber;
            current.password = signedIn.password;
            current.phoneNumber = signedIn.phoneNumber;
            current.Specialization = signedIn.Specialization;
            BirthDate = signedIn.birthDate.ToString("dd/MM/yyyy");
            var app = App.Current as App;
            doctorController = app.doctorController;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void leave(object sender, RoutedEventArgs e)
        {
            string[] tokens = BirthDate.Split('/');
            signedIn.birthDate = new DateTime(int.Parse(tokens[2]), int.Parse(tokens[1]), int.Parse(tokens[0]));
            signedIn.address = current.address;
            signedIn.email = current.email;
            signedIn.name = current.name.Split(' ')[0];
            if (current.name.Split(' ').Length > 1)
                signedIn.surname = current.name.Split(' ')[1];
            signedIn.jmbg = current.jmbg;
            signedIn.LicenseNumber = current.LicenseNumber;
            signedIn.phoneNumber = current.phoneNumber;
            this.NavigationService.Navigate(new DoctorsProfilePage());
        }

        private void change(object sender, RoutedEventArgs e)
        {
            signedIn.password = current.password;
            doctorController.Update(signedIn);
            this.NavigationService.Navigate(new DoctorsProfilePage());
        }

        private void edited(object sender, RoutedEventArgs e)
        {
            isButtonEnabled = enabled;
            OnPropertyChanged("isButtonEnabled");
        }
        private void changePassword(object sender, RoutedEventArgs e)
        {
            var dialog = new ChangePasswordDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
