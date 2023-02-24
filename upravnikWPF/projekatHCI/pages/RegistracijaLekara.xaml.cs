using Controller;
using Model.Doctor;
using Model.Users;
using ProjekatKlinika.Controller;
using System;
using System.Collections.Generic;
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

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for Registruj.xaml
    /// </summary>
    public partial class RegistracijaLekara : Window
    {
        public static string imeIzBoxa;
        public static string prezimeIzBoxa; 
        public static string jmbgIzBoxa;
        public static string mejlIzBoxa;
        public static string zanimanjeIzBoxa;
        public static string specijalizacijaIzBoxa;

        
        private readonly DoctorController doctorController;
        public RegistracijaLekara()
        {
            InitializeComponent();
            var app = Application.Current as App;
          
            doctorController = app.doctorController;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            imeIzBoxa = ime.Text;
            prezimeIzBoxa = prezime.Text;
            jmbgIzBoxa = jmbg.Text;
            mejlIzBoxa = mejl.Text;
            
            specijalizacijaIzBoxa = specijalizacija.Text;

            
            Doctor doctor = new Doctor();
            doctor.name = imeIzBoxa;
            doctor.surname = prezimeIzBoxa;
            doctor.jmbg = jmbgIzBoxa;
            doctor.email = mejlIzBoxa;
            
      
            doctorController.Create(doctor);

            var s = new OsobljeLekar();
            s.Show();
            this.Close();





            /*
            if (imeIzBoxa != "" && prezimeIzBoxa != "" && zanimanjeIzBoxa != "")
            {
                if (zanimanjeIzBoxa == "Sekretar" || zanimanjeIzBoxa == "sekretar")
                {
                    Secretary secretary = new Secretary();
                    secretary.name = imeIzBoxa;
                    secretary.surname = prezimeIzBoxa;
                    secretary.jmbg = jmbgIzBoxa;
                    secretary.email = mejlIzBoxa;

                    secretaryController.Create(secretary);
                   // Osoblje.OsobeLista.Add(new Model.Osoba() { Ime = imeIzBoxa, Prezime = prezimeIzBoxa, Jmbg = jmbgIzBoxa, Mejl = mejlIzBoxa, Zanimanje = zanimanjeIzBoxa, Specijalizacija = "" });

                }
                else

                {
                    if (specijalizacijaIzBoxa == "")
                    {
                        Doctor doctor = new Doctor();
                        doctor.name = imeIzBoxa;
                        doctor.surname = prezimeIzBoxa;
                        doctor.jmbg = jmbgIzBoxa;
                        doctor.email = mejlIzBoxa;
                        doctorController.Create(doctor);
                    }
                    else
                    {
                        DoctorSpecialist doctor = new DoctorSpecialist();
                        doctor.name = imeIzBoxa;
                        doctor.surname = prezimeIzBoxa;
                        doctor.jmbg = jmbgIzBoxa;
                        doctor.email = mejlIzBoxa;
                        doctor.Specialization.Name = specijalizacijaIzBoxa;
                        doctorController.Create(doctor);
                    }
                    //Osoblje.OsobeLista.Add(new Model.Osoba() { Ime = imeIzBoxa, Prezime = prezimeIzBoxa, Jmbg = jmbgIzBoxa, Mejl = mejlIzBoxa, Zanimanje = zanimanjeIzBoxa, Specijalizacija = specijalizacijaIzBoxa });
                }
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(ime.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }

        private void prezime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(prezime.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }
    }
}
