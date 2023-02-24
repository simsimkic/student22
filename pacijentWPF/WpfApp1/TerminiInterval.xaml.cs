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
    /// Interaction logic for TerminiInterval.xaml
    /// </summary>
    public partial class TerminiInterval : Window
    {
        public TerminiInterval()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Appointments interval";
                nazad.Content = "BACK";
                nedelja.Content = "NEXT WEEK";
                mesec.Content = "NEXT MONTH";
                danas.Content = "TODAY";
                helpL.Content = "HELP";
            }
        }

        private void Danas_Click(object sender, RoutedEventArgs e)
        {
            PrikazTermina pi = new PrikazTermina();
            pi.Show();
            this.Close();
        }

        private void Nedelja_Click(object sender, RoutedEventArgs e)
        {
            PrikazTermina pi = new PrikazTermina();
            pi.Show();
            this.Close();
        }

        private void Mesec_Click(object sender, RoutedEventArgs e)
        {
            PrikazTermina pi = new PrikazTermina();
            pi.Show();
            this.Close();
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
    }
}
