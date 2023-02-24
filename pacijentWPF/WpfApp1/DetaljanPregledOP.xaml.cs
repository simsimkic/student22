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
    /// Interaction logic for DetaljanPregledOP.xaml
    /// </summary>
    public partial class DetaljanPregledOP : Window
    {
        public Pregled pregled;
        public PrikazTermina pt;
        public DetaljanPregledOP(Pregled pregled, PrikazTermina pt)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                this.Title = "Pregled";
                nazad.Content = "NAZAD";
                izmeni.Content = "IZMENI";
            }
            else
            {
                this.Title = "Appointment";
                nazad.Content = "BACK";
                izmeni.Content = "EDIT";
            }
            this.pregled = pregled;
            this.pt = pt;
            nazad.Focus();
            ime.Content = pregled.Lekar;
            datum.Content = pregled.Datum;
            vreme.Content = pregled.Vreme;
            tip.Content = pregled.Tip;

            if (pregled.Tip != "pregled")
            {
                izmeni.IsEnabled = false;
            }

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            IzmenaPregleda ip = new IzmenaPregleda(this.pregled, this.pt);
            ip.Show();
            this.Close();
        }
    }
}
