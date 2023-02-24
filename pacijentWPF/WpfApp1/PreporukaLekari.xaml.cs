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
using System.Collections.ObjectModel;

namespace HCI
{
    /// <summary>
    /// Interaction logic for PreporukaLekari.xaml
    /// </summary>
    public partial class PreporukaLekari : Window
    {
        public int colNum = 0;
        public ObservableCollection<Lekar> Lekari
        {
            get;
            set;
        }

        public PreporukaLekari()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Smart schedule";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            this.DataContext = this;
            Lekari = new ObservableCollection<Lekar>();
            Lekari.Add(new Lekar("Ime Prezime", 10));
            Lekari.Add(new Lekar("Ime Prezime", 9));
            Lekari.Add(new Lekar("Ime Prezime", 8));
            Lekari.Add(new Lekar("Ime Prezime", 7.8));

        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeIzbor zi = new ZakazivanjeIzbor();
            zi.Show();
            this.Close();
        }

        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 2)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DataGridLekari_Selected(object sender, RoutedEventArgs e)
        {
            Preporuka p = new Preporuka();
            p.Show();
            this.Close();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Preporuka p = new Preporuka();
                p.Show();
                this.Close();
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
    }
}
