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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        //int resource;
        public MainMenu()
        {
            InitializeComponent();
            //this.Background = Brushes.SteelBlue;
            zakazi.Focus();
            //button7.IsEnabled = false;
            if (Jezik.jezik1 == 0)
            {
                zakazi.Content = "ZAKAZI";
                termini.Content = "MOJI TERMINI";
                terapije.Content = "MOJE TERAPIJE";
                UputiIzvestaji.Content = "UPUTI I IZVESTAJI";
                nalog.Content = "MOJ NALOG";
                oceni.Content = "OCENI";
                podesavanja.Content = "PODESAVANJA";
                blog.Content = "BLOG";
                obavestenja.Content = "OBAVESTENJA(0)";
                helpLabel.Content = "POMOC";
                exitLabel.Content = "Izlaz";
                logout.Content = "Odjavi se";
            }
            else
            {
                zakazi.Content = "SCHEDULE";
                termini.Content = "APPOINTMENTS";
                terapije.Content = "MEDICINE LIST";
                UputiIzvestaji.Content = "REFERRALS AND REPORTS";
                nalog.Content = "PROFILE";
                oceni.Content = "RATE";
                podesavanja.Content = "SETTINGS";
                blog.Content = "BLOG";
                obavestenja.Content = "NOTIFICATIONS(0)";
                helpLabel.Content = "HELP";
                exitLabel.Content = "Exit";
                logout.Content = "Log Out";

            }

        }

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeIzbor zi = new ZakazivanjeIzbor();
            zi.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc pomoc = new Pomoc();
            pomoc.Show();
        }
        private void UputiIzvestaji_Click(object sender, RoutedEventArgs e)
        {
            UputiIzvestaji ui = new UputiIzvestaji();
            ui.Show();
            this.Close();
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow lw = new LogInWindow();
            lw.Show();
            this.Close();

            
        }

        private void Button10_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Nalog_Click(object sender, RoutedEventArgs e)
        {
            Nalog n = new Nalog();
            n.Show();
            this.Close();

        }

        private void Podesavanja_Click(object sender, RoutedEventArgs e)
        {
            Podesavanja p = new Podesavanja();
            p.Show();
            this.Close();
        }

        private void Blog_Click(object sender, RoutedEventArgs e)
        {
            Blog b = new Blog();
            b.Show();
        }

        private void Terapije_Click(object sender, RoutedEventArgs e)
        {
            PrikazLekova pl = new PrikazLekova();
            pl.Show();
            this.Close();
        }

        private void Termini_Click(object sender, RoutedEventArgs e)
        {
            TerminiInterval ti = new TerminiInterval();
            ti.Show();
            this.Close();
        }

        private void Obavestenja_Click(object sender, RoutedEventArgs e)
        {
            Notifikacije n = new Notifikacije();
            n.Show();
        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            Oceni o = new Oceni();
            o.Show();
            this.Close();
        }
    }
}
