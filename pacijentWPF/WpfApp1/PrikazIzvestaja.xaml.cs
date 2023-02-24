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
using Controller;
using Model.Patient;

namespace HCI
{
    /// <summary>
    /// Interaction logic for PrikazIzvestaja.xaml
    /// </summary>
    public partial class PrikazIzvestaja : Window
    {
        public int colNum = 0;
        public Izvestaj iz = new Izvestaj("Ime Prezime 5", "05.06.2020.");
        private readonly PatientController patientController;
        public ObservableCollection<Report> Izvestaji
        {
            get;
            set;
        }
        public PrikazIzvestaja()
        {
            InitializeComponent();
            var app = Application.Current as App;

            patientController = app.patientController;
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Reports";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }

            nazad.Focus();
            this.DataContext = this;
            Izvestaji = new ObservableCollection<Report>();
            List<Report> reports = patientController.Get(LogInWindow.ulogovaniPacijent.IdNumber).medicalRecord.reports;
            foreach (Report report in reports)
            {
                Izvestaji.Add(report);
            }
        }
        public void addIzvestaj()
        {
            //Izvestaji.Add(new Izvestaj("TIP", "02.06.2020."));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            IzvestajiInterval ii = new IzvestajiInterval();
            ii.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 1)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
            else if (colNum == 2)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                e.Column.Visibility = Visibility.Collapsed;
            }
            else if (colNum > 2)
                e.Column.Visibility = Visibility.Collapsed;
        }

        private void DataGridIzvestaji_Selected(object sender, RoutedEventArgs e)
        {
            Izvestaj izvestaj1 = iz;
            Detaljanizvestaj di = new Detaljanizvestaj(izvestaj1);
            DataGridIzvestaji.UnselectAll();
            nazad.Focus();
            di.Show();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Izvestaj izvestaj1 = iz;
                Detaljanizvestaj di = new Detaljanizvestaj(izvestaj1);
                DataGridIzvestaji.UnselectAll();
                nazad.Focus();
                di.Show();
            }
        }
    }
}
