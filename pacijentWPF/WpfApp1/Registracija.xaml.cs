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
using Controller;
using Model.Users;

namespace HCI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        private PatientController patientController;

        public Registracija()
        {
            var app = Application.Current as App;

            patientController = app.patientController;
            InitializeComponent();
            ime.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if (valid())
            {
                if (!patientExists())
                {
                    Patient patient = new Patient();
                    patient.name = ime.Text;
                    patient.surname = prezime.Text;
                    patient.password = passwordBox.Password;
                    patient.jmbg = jmbg.Text;
                    patient.phoneNumber = broj.Text;
                    patient.email = email.Text;

                    patientController.Create(patient);
                    LogInWindow lw = new LogInWindow();
                    lw.Show();
                    PotvrdaRegistracije pr = new PotvrdaRegistracije();
                    pr.Show();
                    this.Close();
                }
                else if (isGuest())
                {
                    Patient patient = patientController.getByJMBG(jmbg.Text);
                    patient.isGuest = false;
                    patient.name = ime.Text;
                    patient.surname = prezime.Text;
                    patient.password = passwordBox.Password;
                    patient.jmbg = jmbg.Text;
                    patient.phoneNumber = broj.Text;
                    patient.email = email.Text;

                    patientController.Update(patient);
                    LogInWindow lw = new LogInWindow();
                    lw.Show();
                    PotvrdaRegistracije pr = new PotvrdaRegistracije();
                    pr.Show();
                    this.Close();


                }
            }
            else
            {
                ime.BorderBrush = Brushes.Red;
                prezime.BorderBrush = Brushes.Red;
                email.BorderBrush = Brushes.Red;
                passwordBox.BorderBrush = Brushes.Red;
                jmbg.BorderBrush = Brushes.Red;
                broj.BorderBrush = Brushes.Red;

            }
            
        }

        private bool valid()
        {
            if (ime.Text != "" && prezime.Text != "" && email.Text != "" && passwordBox.Password != ""
                && jmbg.Text != "" && broj.Text != "" && dan.Text != "" && godina.Text != "" && mesec.Text != ""
                && email.Text.Contains("@") && email.Text.Contains("."))
            {
                return true;
            }
            else return false;
        }
        private bool patientExists()
        {
            if(patientController.getByJMBG(jmbg.Text) != null)
            {
                return true;
            }
            return false;
        }

        private bool isGuest()
        {
            Patient p = patientController.getByJMBG(jmbg.Text);
            if(p != null && p.isGuest)
            {
                return true;
            }
            return false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogInWindow lw = new LogInWindow();
            lw.Show();
            this.Close();
        }
    }
}
