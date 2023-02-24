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
    /// Interaction logic for IzmenaPregledaPotvrda.xaml
    /// </summary>
    public partial class IzmenaPregledaPotvrda : Window
    {
        public Termin t;
        public OdabirTermina ot;
        public Pregled p;
        public Lekar l;

        public IzmenaPregledaPotvrda(Termin t, OdabirTermina ot, Pregled p, Lekar l)
        {
            InitializeComponent();
            this.t = t;
            this.p = p;
            this.ot = ot;
            this.l = l;
        }

        private void Da_Click(object sender, RoutedEventArgs e)
        {
            if (l == null)
            {
                foreach (Pregled pregled in PrikazTermina.Pregledi)
                {
                    if (pregled.Lekar == p.Lekar && pregled.Datum == p.Datum && p.Tip == pregled.Tip && pregled.Vreme == p.Vreme)
                    {
                        pregled.Vreme = t.Vreme;
                        pregled.Datum = t.Datum;
                    }
                }
            } else
            {
                foreach (Pregled pregled in PrikazTermina.Pregledi)
                {
                    if (pregled.Lekar == p.Lekar && pregled.Datum == p.Datum && p.Tip == pregled.Tip && pregled.Vreme == p.Vreme)
                    {
                        pregled.Vreme = t.Vreme;
                        pregled.Datum = t.Datum;
                        pregled.Lekar = l.Doktor;
                    }
                }
            }

            PrikazTermina pt = new PrikazTermina();
            pt.Show();
            this.Close();
            ot.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
