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
    /// Interaction logic for OcenjivanjeForma.xaml
    /// </summary>
    public partial class OcenjivanjeForma : Window
    {
        public OcenjivanjeForma()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Rate";
                Nazad.Content = "BACK";
                Oceni.Content = "RATE";
                imeLabel.Content = "Grade";
                prezimeLabel.Content = "Comment";
            }
            ocena.Focus();
        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            PotvrdaOcenjivanjaLekara po = new PotvrdaOcenjivanjaLekara();
            po.Show();
            this.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
