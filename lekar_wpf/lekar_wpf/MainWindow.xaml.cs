using lekar_wpf.Model;
using lekar_wpf.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace lekar_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static Data data;
        public static ObservableCollection<BlogArticle> articles;
        public static ObservableCollection<Patient> patients;
        public static ObservableCollection<Appointment> appointments;
        public MainWindow()
        {
            InitializeComponent();
            data = new Data();
            articles = new ObservableCollection<BlogArticle>();
            patients = new ObservableCollection<Patient>();
            appointments = new ObservableCollection<Appointment>();
            BlogArticle a1 = new BlogArticle();
            a1.Category = "GLOBALNO ZDRAVLJE";
            a1.Heading = "Risk of pneumococcal bacteremia in Kenyan children with glucose-6-phosphate dehydrogenase deficiency";
            a1.Text = "Glucose-6-phosphate dehydrogenase (G6PD) deficiency is the most common enzyme deficiency state in humans. The clinical phenotype is variable and includes asymptomatic individuals, episodic hemolysis induced by oxidative stress, and chronic hemolysis. G6PD deficiency is common in malaria-endemic regions, an observation hypothesized to be due to balancing selection at the G6PD locus driven by malaria. G6PD deficiency increases risk of severe malarial anemia, a key determinant of invasive bacterial disease in malaria-endemic settings. The pneumococcus is a leading cause of invasive bacterial infection and death in African children. The effect of G6PD deficiency on risk of pneumococcal disease is undefined. We hypothesized that G6PD deficiency increases pneumococcal disease risk and that this effect is dependent upon malaria.";
            a1.Author = "Petar Jovanovic";
            DateTime d1 = new DateTime(2020, 5, 10);
            a1.Date = d1.ToString("dd/MM/yyyy");
            BlogArticle a2 = new BlogArticle();
            a2.Category = "VAKCINACIJA";
            a2.Heading = "Estimating the contribution of different age strata to vaccine serotype pneumococcal transmission in the pre vaccine era: a modelling study";
            a2.Text = "Glucose-6-phosphate dehydrogenase (G6PD) deficiency is the most common enzyme deficiency state in humans. The clinical phenotype is variable and includes asymptomatic individuals, episodic hemolysis induced by oxidative stress, and chronic hemolysis. G6PD deficiency is common in malaria-endemic regions, an observation hypothesized to be due to balancing selection at the G6PD locus driven by malaria. G6PD deficiency increases risk of severe malarial anemia, a key determinant of invasive bacterial disease in malaria-endemic settings. The pneumococcus is a leading cause of invasive bacterial infection and death in African children. The effect of G6PD deficiency on risk of pneumococcal disease is undefined. We hypothesized that G6PD deficiency increases pneumococcal disease risk and that this effect is dependent upon malaria.";
            a2.Author = "Marija Mitrovic";
            DateTime d2 = new DateTime(2020, 3, 13);
            a2.Date = d2.ToString("dd/MM/yyyy");
            BlogArticle a3 = new BlogArticle();
            a3.Category = "KARDIOLOGIJA";
            a3.Heading = "Risk of pneumococcal bacteremia in Kenyan children with glucose-6-phosphate dehydrogenase deficiency";
            a3.Text = "Glucose-6-phosphate dehydrogenase (G6PD) deficiency is the most common enzyme deficiency state in humans. The clinical phenotype is variable and includes asymptomatic individuals, episodic hemolysis induced by oxidative stress, and chronic hemolysis. G6PD deficiency is common in malaria-endemic regions, an observation hypothesized to be due to balancing selection at the G6PD locus driven by malaria. G6PD deficiency increases risk of severe malarial anemia, a key determinant of invasive bacterial disease in malaria-endemic settings. The pneumococcus is a leading cause of invasive bacterial infection and death in African children. The effect of G6PD deficiency on risk of pneumococcal disease is undefined. We hypothesized that G6PD deficiency increases pneumococcal disease risk and that this effect is dependent upon malaria.";
            a3.Author = "Jovana Peric";
            DateTime d3 = new DateTime(2020, 1, 26);
            a3.Date = d3.ToString("dd/MM/yyyy");
            MainFrame.Navigate(new LoginPage());
            articles.Add(a1);
            articles.Add(a2);
            articles.Add(a3);
            Patient regular = new Patient();
            regular.FullName = "Stefan Markovic";
            regular.CardNumber = "835722";
            regular.Address = "Bulevar Cara Lazara, 5";
            DateTime d = new DateTime(1973, 8, 12);
            regular.BirthDate = d.ToString("dd/MM/yyyy");
            regular.Jmbg = "12081973772034";
            regular.PhoneNumber = "0623892150";
            regular.RecordNumber = "8142/17";
            regular.City = "Novi Sad, Novi Sad";
            regular.Hospitalized = false;
            regular.Gender = "Muski";
            Report rep1 = new Report();
            rep1.Date = DateTime.Now.AddDays(-15).ToString("dd/MM/yyyy");
            rep1.Doctor = "Jovan Ivanovic";
            rep1.Diagnosis = "Pneumonia";
            rep1.Comment = "Pacijent ima problema sa disanjem.";
            rep1.Odeljenje = "Pulmologija";
            Appointment ap1 = new Appointment();
            ap1.Patient = regular;
            //ap1.Doctor = DoctorsProfilePage.signedIn;
            ap1.Room = "204";
            ap1.StartPoint = DateTime.Now.AddDays(2);
            ap1.EndPoint = DateTime.Now.AddDays(2).AddMinutes(20);
            ap1.Type = "Pregled";
            Appointment ap2 = new Appointment();
            ap2.Patient = regular;
            //ap2.Doctor = DoctorsProfilePage.signedIn;
            ap2.Room = "204";
            ap2.StartPoint = DateTime.Now.AddDays(7);
            ap2.EndPoint = DateTime.Now.AddDays(7).AddMinutes(20);
            ap2.Type = "Pregled";
            
            Report r1 = new Report();
            r1.Doctor = "Petar Kostic";
            r1.Diagnosis = "Pneumonia";
            r1.Comment = "Pacijent je u dobrom stanju i oporavlja se u odnosu na prethodnu kontrolu.";
            r1.Date = d1.ToString("dd/MM/yyyy");
            r1.Odeljenje = "Pulmologija";
            Report r2 = new Report();
            r2.Doctor = "Luka Vasic";
            r2.Diagnosis = "Meningitis";
            r2.Comment = "Pacijent se upucuje na bolnicko lecenje radi pracenja njegovog stanja.";
            r2.Date = d2.ToString("dd/MM/yyyy");
            r2.Doctor = "Lidija Pajic";
            r2.Odeljenje = "Neurologija";
            regular.Reports = new ObservableCollection<Report>();
            regular.Reports.Add(r1);
            regular.Reports.Add(r2);
            regular.Reports.Add(rep1);
            Patient hospitalized = new Patient();
            hospitalized.FullName = "Ana Jankovic";
            hospitalized.CardNumber = "302749";
            hospitalized.Address = "Sremska 12";
            DateTime dd = new DateTime(1967, 4, 22);
            hospitalized.BirthDate = dd.ToString("dd/MM/yyyy");
            hospitalized.Jmbg = "22041967777028";
            hospitalized.PhoneNumber = "0604829433";
            hospitalized.RecordNumber = "3819/13";
            hospitalized.City = "Novi Sad, Novi Sad";
            hospitalized.Hospitalized = true;
            hospitalized.Gender = "Zenski";
            hospitalized.EndOfHospitalization = new DateTime(2020, 7, 5);
            hospitalized.Reports = new ObservableCollection<Report>();
            hospitalized.Reports.Add(r1);
            hospitalized.Reports.Add(r2);
            Appointment ap4 = new Appointment();
            ap4.Patient = hospitalized;
            //ap4.Doctor = DoctorsProfilePage.signedIn;
            ap4.Room = "117";
            ap4.StartPoint = DateTime.Now.AddDays(2).AddHours(3);
            ap4.EndPoint = DateTime.Now.AddDays(2).AddHours(3).AddMinutes(120);
            ap4.Type = "Operacija";
            Appointment ap3 = new Appointment();
            ap3.Patient = hospitalized;
            //ap3.Doctor = DoctorsProfilePage.signedIn;
            ap3.Room = "130";
            ap3.StartPoint = DateTime.Now.AddDays(7).AddHours(2);
            ap3.EndPoint = DateTime.Now.AddDays(7).AddHours(2).AddMinutes(20);
            ap3.Type = "Pregled";
            patients.Add(regular);
            patients.Add(hospitalized);
            patients.Add(regular);
            patients.Add(hospitalized);
            appointments.Add(ap1);
            appointments.Add(ap4);
            appointments.Add(ap2);
            appointments.Add(ap3);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
