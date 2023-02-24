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
    /// Interaction logic for Nalog.xaml
    /// </summary>
    public partial class Nalog : Window
    {
        public Nalog()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Profile";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
                izmeni.Content = "EDIT";
                brojKarLabel.Content = "Pacient ID:";
                datLabel.Content = "Date of birth:";
                polLabel.Content = "Sex:";
                brojLabel.Content = "Phone number:";
            }
            imeLabel.Content = LogInWindow.ulogovaniPacijent.name;
            prezimeLabel.Content = LogInWindow.ulogovaniPacijent.surname;
            emailLabel1.Content = LogInWindow.ulogovaniPacijent.email;
            brojLabel1.Content = LogInWindow.ulogovaniPacijent.phoneNumber;
            brojKarLabel1.Content = LogInWindow.ulogovaniPacijent.IdNumber;
            jmbgLabel1.Content = LogInWindow.ulogovaniPacijent.jmbg;
            polLabel1.Content = LogInWindow.o.Pol;
            nazad.Focus();
        }
        public void izmeniNalog(Osoba o)
        {
            imeLabel.Content = o.Ime;
            prezimeLabel.Content = o.Prezime;
            emailLabel1.Content = o.Email;
            brojLabel1.Content = o.Broj;
            polLabel1.Content = o.Pol;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Pomoc P = new Pomoc();
            P.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            string ime = (string)imeLabel.Content;
            string prezime = (string)prezimeLabel.Content;
            string datum = (string)datLabel1.Content;
            string pol = (string)polLabel1.Content;
            string broj = (string)brojLabel1.Content;
            string email = (string)emailLabel1.Content;

            Osoba o = new Osoba(ime, prezime, datum, pol, broj, email);
            IzmenaNaloga izn = new IzmenaNaloga(o, this);
            izn.Show();
        }
    }
}
