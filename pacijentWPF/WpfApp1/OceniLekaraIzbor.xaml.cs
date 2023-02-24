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
    /// Interaction logic for OceniLekaraIzbor.xaml
    /// </summary>
    public partial class OceniLekaraIzbor : Window
    {
        public int colNum = 0;
        public ObservableCollection<Lekar> Lekari
        {
            get;
            set;
        }

        public OceniLekaraIzbor()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Select doctor";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            this.DataContext = this;
            Lekari = new ObservableCollection<Lekar>();
            Lekari.Add(new Lekar("Nikola Nikolic", 10));
            Lekari.Add(new Lekar("Marko Markovic", 9.5));
            Lekari.Add(new Lekar("Petar Petrovic", 9));
            Lekari.Add(new Lekar("Ivan Ivanovic", 8.2));
            Lekari.Add(new Lekar("Jovan Jovanovic", 8));
            Lekari.Add(new Lekar("Lazar Lazarevic", 7.8));
        }

        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum > 2 || colNum == 0)
                e.Column.Width = new DataGridLength(0, DataGridLengthUnitType.Pixel);
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Oceni o = new Oceni();
            o.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }

        private void DataGridLekari_Selected(object sender, RoutedEventArgs e)
        {
            OcenjivanjeForma of = new OcenjivanjeForma();
            of.Show();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                OcenjivanjeForma of = new OcenjivanjeForma();
                DataGridLekari.UnselectAll();
                nazad.Focus();
                of.Show();
            }               
        }
    }
}