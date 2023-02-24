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
using System.Collections.ObjectModel;
using Controller;
using Model.Users;
using Model.Patient;

namespace HCI
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public static Osoba o;

        private readonly PatientController patientController;
        public static Patient ulogovaniPacijent;
        public LogInWindow()
        {
            InitializeComponent();
            var app = Application.Current as App;

            patientController = app.patientController;

            checkBox.IsChecked = true;
            email.Focus();
            PrikazTermina.Pregledi = new ObservableCollection<Pregled>();
            PrikazTermina.Pregledi.Add(new Pregled("pregled", "11.06.2020", "14:00", "Petar Petrovic"));
            PrikazTermina.Pregledi.Add(new Pregled("operacija", "12.06.2020", "09:00", "Ivan Ivanovic"));
            PrikazTermina.Pregledi.Add(new Pregled("pregled", "13.06.2020", "12:00", "Jovan Jovanovic"));
            PrikazTermina.Pregledi.Add(new Pregled("specijalizacija", "14.06.2020", "10:00", "Marko Markovic"));


            o = new Osoba("Milijana", "Djordjevic", "11.09.1998", "ZENSKI", "0611993536", "email@gmail.com");
            Jezik.jezik1 = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (valid() && isPatient(email.Text, passwordBox.Password) != null)
            {
                ulogovaniPacijent = isPatient(email.Text, passwordBox.Password);

                /*
                ulogovaniPacijent.medicalRecord = new MedicalRecord();
                ulogovaniPacijent.medicalRecord.reports = new List<Report>();

                Report report = new Report();
                report.doctor = new Doctor();
                report.doctor.name = "Tamara Rankovic";
                report.Opinion = "Izvestaj1";
                
                ulogovaniPacijent.medicalRecord.reports.Add(report);
                patientController.Update(ulogovaniPacijent);
                */

                MainMenu mm = new MainMenu();
                mm.Show();
                this.Close();

                
            } else
            {
                passwordBox.Password = "";
                passwordBox.BorderBrush = Brushes.Red;
                email.BorderBrush = Brushes.Red;
            }
        }

        private Patient isPatient(String email, String password)
        {
            return patientController.LogIn(email, password);
        }

        private bool valid()
        {
            if (email.Text == "" || !email.Text.Contains("@") || !email.Text.Contains("."))
            {
                return false;
            }
            if (passwordBox.Password == "")
            {
                return false;
            }
            return true;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registracija r = new Registracija();
            r.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BezNaloga bn = new BezNaloga();
            bn.Show();
            this.Close();
        }
    }
}
