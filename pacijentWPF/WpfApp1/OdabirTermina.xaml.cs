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
    /// Interaction logic for OdabirTermina.xaml
    /// </summary>
    public partial class OdabirTermina : Window
    {
        public int reg;
        public Pregled t;
        public Lekar l;
        public int colNum = 0;
        public ObservableCollection<Termin> Termini
        {
            get;
            set;
        }
        public OdabirTermina(int reg, Pregled t, Lekar lekar)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Select time";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            this.DataContext = this;
            this.reg = reg;
            this.l = lekar;
            if (reg == 2 || reg == 3)
            {
                this.t = t;
            }
            Termini = new ObservableCollection<Termin>();
            Termini.Add(new Termin("15.06.2020.", "08:00"));
            Termini.Add(new Termin("16.06.2020.", "12:30"));
            Termini.Add(new Termin("17.06.2020.", "11:00"));
            Termini.Add(new Termin("17.06.2020.", "15:30"));
            Termini.Add(new Termin("17.06.2020.", "16:00"));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            if (this.reg == 2)
            {
                PrikazTermina pt = new PrikazTermina();
                pt.Show();
                this.Close();
            }
            else if (this.reg == 3)
            {
                Zakazi z = new Zakazi(reg, t);
                z.Show();
                this.Close();
            }
            else
            {
                Zakazi z = new Zakazi(reg, null);
                z.Show();
                this.Close();
            }

        }

        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 2)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DataGridTermini_Selected(object sender, RoutedEventArgs e)
        {
            if (this.reg == 1)
            {
                Termin termin = (Termin)DataGridTermini.SelectedItem;
                Pregled pregled12 = new Pregled("pregled", termin.Datum, termin.Vreme, l.Doktor);
                PrikazTermina.Pregledi.Add(pregled12);
                PotvrdaTermina pt = new PotvrdaTermina(this);
                DataGridTermini.UnselectAll();
                nazad.Focus();
                pt.Show();
            }
            else if (this.reg == 0)
            {
                PotvrdaTerminaNeregistrovan pt = new PotvrdaTerminaNeregistrovan(this);
                DataGridTermini.UnselectAll();
                nazad.Focus();
                pt.Show();
            }
            else if (this.reg == 2)
            {
                Termin termin = (Termin)DataGridTermini.SelectedItem;
                IzmenaPregledaPotvrda ipp = new IzmenaPregledaPotvrda(termin, this, t, null);
                DataGridTermini.UnselectAll();
                nazad.Focus();
                ipp.Show();
            }
            else
            {
                Termin termin = (Termin)DataGridTermini.SelectedItem;
                IzmenaPregledaPotvrda ipp = new IzmenaPregledaPotvrda(termin, this, t, this.l);
                DataGridTermini.UnselectAll();
                nazad.Focus();
                ipp.Show();
            }
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (this.reg == 1)
                {
                    Termin termin = (Termin)DataGridTermini.SelectedItem;
                    Pregled pregled12 = new Pregled("pregled", termin.Datum, termin.Vreme, l.Doktor);
                    PrikazTermina.Pregledi.Add(pregled12);
                    PotvrdaTermina pt = new PotvrdaTermina(this);
                    DataGridTermini.UnselectAll();
                    nazad.Focus();
                    pt.Show();
                }
                else if (this.reg == 0)
                {
                    PotvrdaTerminaNeregistrovan pt = new PotvrdaTerminaNeregistrovan(this);
                    DataGridTermini.UnselectAll();
                    nazad.Focus();
                    pt.Show();
                }
                else if (this.reg == 2)
                {
                    Termin termin = (Termin)DataGridTermini.SelectedItem;
                    IzmenaPregledaPotvrda ipp = new IzmenaPregledaPotvrda(termin, this, t, null);
                    DataGridTermini.UnselectAll();
                    nazad.Focus();
                    ipp.Show();
                } else
                {
                    Termin termin = (Termin)DataGridTermini.SelectedItem;
                    IzmenaPregledaPotvrda ipp = new IzmenaPregledaPotvrda(termin, this, t, this.l);
                    DataGridTermini.UnselectAll();
                    nazad.Focus();
                    ipp.Show();
                }
            }
        }
    }
}
