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
    /// Interaction logic for ZakazivanjeIzbor.xaml
    /// </summary>
    public partial class ZakazivanjeIzbor : Window
    {
        public ZakazivanjeIzbor()
        {
            InitializeComponent();
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Language";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
                preporuka.Content = "SMART SCHEDULE";
                obicno.Content = "SCHEDULE";
            }
        }

        private void Preporuka_Click(object sender, RoutedEventArgs e)
        {
            PreporukaLekari pl = new PreporukaLekari();
            pl.Show();
            this.Close();

        }

        private void Obicno_Click(object sender, RoutedEventArgs e)
        {
            Zakazi z = new Zakazi(1, null);
            z.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();
        }
    }
}
