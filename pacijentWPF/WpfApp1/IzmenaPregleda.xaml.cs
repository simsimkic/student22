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
    /// Interaction logic for IzmenaPregleda.xaml
    /// </summary>
    public partial class IzmenaPregleda : Window
    {
        public Pregled pregled;
        public PrikazTermina pt;
        public IzmenaPregleda(Pregled pregled, PrikazTermina pt)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Edit appointment";
                nazad.Content = "BACK";
                termin.Content = "CHANGE TIME";
                lekar.Content = "CHANGE DOCTOR";
                brisanje.Content = "CANCEL APPOINTMENT";
            }
            this.pregled = pregled;
            this.pt = pt;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Termin_Click(object sender, RoutedEventArgs e)
        {
            OdabirTermina ot = new OdabirTermina(2, pregled, null);
            ot.Show();
            this.Close();
            pt.Close();

        }

        private void Lekar_Click(object sender, RoutedEventArgs e)
        {
            Zakazi z = new Zakazi(3, pregled);
            z.Show();
            this.Close();
            pt.Close();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            OtkaziIzborxaml oi = new OtkaziIzborxaml(pregled, this);
            oi.Show();
            
        }
    }
}
