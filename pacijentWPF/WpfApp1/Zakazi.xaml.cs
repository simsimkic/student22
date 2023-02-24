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
using System.Collections.ObjectModel;
using Model.Users;
using Controller;

namespace HCI
{
    /// <summary>
    /// Interaction logic for Zakazi.xaml
    /// </summary>
    public partial class Zakazi : Window
    {
        public int reg;
        public Lekar l = new Lekar("Nikola Nikolic", 10);
        public int colNum = 0;
        public Pregled pregled;
        private readonly DoctorController doctorController;
        public ObservableCollection<Doctor> Doctors
        {
            get;
            set;
        }

        public Zakazi(int reg, Pregled pregled)
        {
            InitializeComponent();
            var app = Application.Current as App;

            doctorController = app.doctorController;
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Schedule";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            this.DataContext = this;
            this.reg = reg;
            this.pregled = pregled;
            Doctors = new ObservableCollection<Doctor>();
            List<Doctor> doctorsList = doctorController.GetAll().ToList();
            foreach (Doctor d in doctorsList)
            {
                Doctors.Add(d);
            }


            /*
            Lekari.Add(new Lekar("Nikola Nikolic", 10));
            Lekari.Add(new Lekar("Petar Petrovic", 9));
            Lekari.Add(new Lekar("Jovan Jovanovic", 8));
            Lekari.Add(new Lekar("Lazar Lazarevic", 7.8));   
            */
        }

        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum > 5 || colNum < 4)
                e.Column.Visibility = Visibility.Collapsed;
            if (colNum == 4)
            {
                e.Column.Header = "Ime lekara";
            }
            if (colNum == 5)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                e.Column.Header = "Prezime lekara";
            }
               
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            if (reg == 1)
            {
                ZakazivanjeIzbor zi = new ZakazivanjeIzbor();
                zi.Show();
            }
            else if (reg == 0)
            {
                LogInWindow lw = new LogInWindow();
                lw.Show();
            }
            else if (reg == 3)
            {
                PrikazTermina pt = new PrikazTermina();
                pt.Show();
            }
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void DataGridLekari_Selected(object sender, RoutedEventArgs e)
        {
            OdabirTermina ot;
            if (reg == 3)
            {
                ot = new OdabirTermina(this.reg, pregled, l);
            }
            else
            {
                ot = new OdabirTermina(this.reg, null, l);
            }
            DataGridLekari.UnselectAll();
            nazad.Focus();
            ot.Show();
            this.Close();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                OdabirTermina ot;
                if (reg == 3)
                {
                    ot = new OdabirTermina(this.reg, pregled, l);
                }
                else
                {
                    ot = new OdabirTermina(this.reg, null, l);
                }
                DataGridLekari.UnselectAll();
                nazad.Focus();
                ot.Show();
                this.Close();
            }               
        }
    }
}
