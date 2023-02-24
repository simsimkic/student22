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
using Model.Patient;
using Model.Util;

namespace Sekretar_WPF_Project
{
    /// <summary>
    /// Interaction logic for AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        public AddPatientWindow()
        {
            InitializeComponent();
            DataContext = ViewModel.getInstance();

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

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            try
            {
            string id = idtextbox.Text;
            string name = nametextbox.Text;
            string surname = surnametextbox.Text;
            string phone = phonetextbox.Text;
            string email = emailtextbox.Text;
            string _address = addresstextbox.Text;
            string birth = birthdatepicker.Text;
            string gender = gendercombobox.Text;
            string parent = parenttextbox.Text;
            string username = usernametextbox.Text;
            Address address = new Address();
            DateTime birthDate = new DateTime(DateTime.Parse(birth).Date.Year, DateTime.Parse(birth).Date.Month, DateTime.Parse(birth).Day);
            Patient patient = new Patient();
            patient.medicalRecord = new MedicalRecord();
            patient.name = name;
            patient.surname = surname;
            patient.phoneNumber = phone;
            patient.email = email;
            patient.address = address;
            patient.jmbg = id;
            patient.birthDate = birthDate;
            patient.username = username;
            patient.password = "default password";
            patient.parentName = parent;
            if (gender.Equals("Male"))
            {
                patient.gender = Gender.Male;
            } else
            {
                patient.gender = Gender.Female;
            }
            
                ViewModel.getInstance().Patients.Add(patient);
                App app = (App)App.Current;
                app.patientController.Create(patient);
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
            Close();
        }
    }
}


