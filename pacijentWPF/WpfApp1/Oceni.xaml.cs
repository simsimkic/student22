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
    /// Interaction logic for Oceni.xaml
    /// </summary>
    public partial class Oceni : Window
    {
        public Oceni()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Rate";
                nazad.Content = "BACK";
                doktori.Content = "RATE DOCTOR";
                softver.Content = "RATE SOFTWARE";
                helpL.Content = "HELP";
            }
            doktori.Focus();
        }

        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            OceniLekaraIzbor oli = new OceniLekaraIzbor();
            oli.Show();
            this.Close();
        }

        private void Softver_Click(object sender, RoutedEventArgs e)
        {
            OcenjivanjeForma of = new OcenjivanjeForma();
            of.Show();
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
