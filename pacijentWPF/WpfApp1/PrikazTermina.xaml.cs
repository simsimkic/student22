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

namespace HCI
{
    /// <summary>
    /// Interaction logic for PrikazTermina.xaml
    /// </summary>
    public partial class PrikazTermina : Window
    {
        public int colNum = 0;
        public static ObservableCollection<Pregled> Pregledi
        {
            get;
            set;
        }
        public PrikazTermina()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Appointments";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            this.DataContext = this;
            //Pregledi = new ObservableCollection<Pregled>();
            nazad.Focus();
            //Pregledi.Add(new Pregled("pregled", "01.06.2020", "08:00", "Ime Prezime"));
            //Pregledi.Add(new Pregled("operacija", "02.06.2020", "09:00", "Ime Prezime"));
            //Pregledi.Add(new Pregled("pregled", "03.06.2020", "12:00", "Ime Prezime"));
            //Pregledi.Add(new Pregled("pregled", "04.06.2020", "10:00", "Ime Prezime"));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            TerminiInterval ti = new TerminiInterval();
            ti.Show();
            this.Close();
        }
        

        /*public static void addPregled()
        {
            Pregledi.Add(new Pregled("PREGLED", "01.01.01", "08:00", "Ime Prezime"));
        }*/

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
        public void refresh()
        {
            DataGridPregledi.ItemsSource = null;
            DataGridPregledi.ItemsSource = Pregledi;
        }

        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 4)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DataGridPregledi_Selected(object sender, RoutedEventArgs e)
        {
            Pregled pregled1 = (Pregled)DataGridPregledi.SelectedItem;
            DetaljanPregledOP dp = new DetaljanPregledOP(pregled1, this);
            dp.Show();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Pregled pregled1 = (Pregled)DataGridPregledi.SelectedItem;
                DetaljanPregledOP dp = new DetaljanPregledOP(pregled1, this);
                dp.Show();
            }
        }
    }
}
