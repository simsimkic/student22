using Controller;
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

namespace HCI
{
    /// <summary>
    /// Interaction logic for IzmenaNaloga.xaml
    /// </summary>
    public partial class IzmenaNaloga : Window
    {
        Nalog roditelj;
        private readonly PatientController patientController;
        public IzmenaNaloga(Osoba o, Nalog roditelj)
        {
            this.roditelj = roditelj;
            InitializeComponent();
            var app = Application.Current as App;

            patientController = app.patientController;
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Edit profile";
                nazad.Content = "BACK";
                sacuvaj.Content = "SAVE";
                imeLabel.Content = "Name:";
                prezimeLabel.Content = "Surname:";
                brojLabel.Content = "Phone number:";
                datLabel.Content = "Date of birth:";
                polLabel.Content = "Sex:";
                promeni.Content = "Change password";
            }
            nazad.Focus();
            ime.Text = LogInWindow.ulogovaniPacijent.name;
            prezime.Text = LogInWindow.ulogovaniPacijent.surname;
            email.Text = LogInWindow.ulogovaniPacijent.email;
            broj.Text = LogInWindow.ulogovaniPacijent.phoneNumber;

            if (o.Pol == "ZENSKI")
            {
                zenski.IsSelected = true;
            }
            else muski.IsSelected = true;
        }
        

        private void PromeniLozinku(object sender, RoutedEventArgs e)
        {
            PromenaLozinke pl = new PromenaLozinke();
            pl.Show();
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            string ime1 = ime.Text;
            string prezime1 = prezime.Text;
            string datum1 = "11.09.1998.";           
            string broj1 = broj.Text;
            string email1 = email.Text;
            string pol1;
            if (zenski.IsSelected == true)
            {
                pol1 = "ZENSKI";
            } else
                pol1 = "MUSKI";

            Osoba o = new Osoba(ime1, prezime1, datum1, pol1, broj1, email1);
            LogInWindow.o = o;

            LogInWindow.ulogovaniPacijent.name = ime1;
            LogInWindow.ulogovaniPacijent.surname = prezime1;
            LogInWindow.ulogovaniPacijent.email = email1;
            LogInWindow.ulogovaniPacijent.phoneNumber = broj1;

            patientController.Update(LogInWindow.ulogovaniPacijent);

            this.roditelj.izmeniNalog(o);
            PotvrdaIzmenexaml pix = new PotvrdaIzmenexaml();
            pix.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
