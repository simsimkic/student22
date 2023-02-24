using Model.Doctor;
using Model.Manager;
using Model.Users;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
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
using System.Windows.Shapes;
using Model.Util;
using Model.Patient;

namespace Sekretar_WPF_Project.Windows
{
    /// <summary>
    /// Interaction logic for LinkToPatientWindow.xaml
    /// </summary>

    public partial class LinkToPatientWindow : Window
    {
        Guest gue;
        public LinkToPatientWindow(Guest guest)
        {
            InitializeComponent();
            gue = guest;
            DataContext = ViewModel.getInstance();
            idlabel.Content = guest.IdNumber.ToString();
            namelabel.Content = guest.name;
            surnamelabel.Content = guest.surname;
            phonelabel.Content = guest.phoneNumber;
            emaillabel.Content = guest.email;


            if (Application.Current.MainWindow.Resources["Theme"].Equals(0)) // 1 => Dark Theme , 0 => Light
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.Black);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.White);
            }
            else
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.White);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.Black);
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            /*            try
                        {*/

                ViewModel.getInstance().Guests.Remove(gue);
                string id = (string)idlabel.Content.ToString();
                string name = (string)namelabel.Content;
                string surname = (string)surnamelabel.Content;
                string phone = (string)phonelabel.Content;
                string email = (string)emaillabel.Content;
                string _address = addresstextbox.Text;
                string birthdate = datepicker.Text;
                string gender = gendercombobox.Text;
                string parentname = parenttextbox.Text;
                string username = usernametextbox.Text;
                Address address = new Address();
                DateTime birthDate = new DateTime(DateTime.Parse(birthdate).Date.Year, DateTime.Parse(birthdate).Date.Month, DateTime.Parse(birthdate).Day);
                App app = (App)App.Current;
                Patient patient = app.patientController.Get(long.Parse(id));
                patient.birthDate = birthDate;
                patient.parentName = parentname;
                patient.username = username;
                if (gender.Equals("Male"))
                {
                    patient.gender = Gender.Male;
                }
                else
                {
                    patient.gender = Gender.Female;
                }
                patient.isGuest = false;

                
                ViewModel.getInstance().Patients.Add(patient);
                app.patientController.Update(patient);

/*            }
            catch
            {
                MessageBox.Show("Invalid input");
            }*/

            Close();
        }
    }
}
