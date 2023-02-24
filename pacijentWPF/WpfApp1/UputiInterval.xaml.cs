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
    /// Interaction logic for UputiInterval.xaml
    /// </summary>
    public partial class UputiInterval : Window
    {
        public UputiInterval()
        {
            InitializeComponent();
            nedelja.Focus();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Interval";
                nazad.Content = "BACK";
                nedelja.Content = "THIS WEEK";
                mesec.Content = "THIS MONTH";
                svi.Content = "ALL";
                helpL.Content = "HELP";
            }
        }

        private void Nedelja_Click(object sender, RoutedEventArgs e)
        {
            PrikazUputa pu = new PrikazUputa();
            pu.Show();
            this.Close();
        }

        private void Mesec_Click(object sender, RoutedEventArgs e)
        {
            PrikazUputa pu = new PrikazUputa();
            pu.Show();
            this.Close();
        }

        private void Svi_Click(object sender, RoutedEventArgs e)
        {
            PrikazUputa pu = new PrikazUputa();
            pu.Show();
            this.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            UputiIzvestaji ui = new UputiIzvestaji();
            ui.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
    }
}
