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
    /// Interaction logic for UputiIzvestaji.xaml
    /// </summary>
    public partial class UputiIzvestaji : Window
    {
        public UputiIzvestaji()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Referrals and Reports";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
                uputi.Content = "REFERRALS";
                izvestaji.Content = "REPORTS";
            }
            uputi.Focus();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void Uputi_Click(object sender, RoutedEventArgs e)
        {
            UputiInterval u = new UputiInterval();
            u.Show();
            this.Close();
        }

        private void Izvestaji_Click(object sender, RoutedEventArgs e)
        {
            IzvestajiInterval ii = new IzvestajiInterval();
            ii.Show();
            this.Close();
        }
    }
}
