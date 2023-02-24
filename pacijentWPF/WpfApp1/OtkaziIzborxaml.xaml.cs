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
    /// Interaction logic for OtkaziIzborxaml.xaml
    /// </summary>
    public partial class OtkaziIzborxaml : Window
    {
        public Pregled p;
        public IzmenaPregleda iz;

        public OtkaziIzborxaml(Pregled p, IzmenaPregleda iz)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                nazad.Content = "NO";
                da.Content = "YES";
                textL.Content = "Cancel appointment?";
            }
            this.p = p;
            this.iz = iz;
        }

        private void Da_Click(object sender, RoutedEventArgs e)
        {
            PrikazTermina.Pregledi.Remove(p);
            this.Close();
            iz.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
