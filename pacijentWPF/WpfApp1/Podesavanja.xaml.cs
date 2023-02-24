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
    /// Interaction logic for Podesavanja.xaml
    /// </summary>
    public partial class Podesavanja : Window
    {
        public Podesavanja()
        {
            InitializeComponent();
            izmenaNaloga.Focus();
            if (Jezik.jezik1 == 0)
            {
                izmenaNaloga.Content = "IZMENI NALOG";
                tema.Content = "TEMA";
                jezik.Content = "JEZIK";
                nazad.Content = "NAZAD";
                helpLabel.Content = "POMOC";
                this.Title = "Podesavanja";
            }
            else
            {
                izmenaNaloga.Content = "EDIT PROFILE";
                tema.Content = "THEME";
                jezik.Content = "LANGUAGE";
                nazad.Content = "BACK";
                helpLabel.Content = "HELP";
                this.Title = "Settings";

            }
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

        private void Izmena_Click(object sender, RoutedEventArgs e)
        {
            Nalog izm = new Nalog();
            izm.Show();
            this.Close();
        }

        private void Jezik_Click(object sender, RoutedEventArgs e)
        {
            Jezik j = new Jezik(this);
            j.Show();
        }

        private void Tema_Click(object sender, RoutedEventArgs e)
        {
            Tema t = new Tema();
            t.Show();
        }

        private void Font_Click(object sender, RoutedEventArgs e)
        {
            Font f = new Font();
            f.Show();
        }
    }
}
