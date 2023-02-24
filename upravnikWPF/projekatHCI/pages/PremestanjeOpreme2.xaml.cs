using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for PremestanjeOpreme2.xaml
    /// </summary>
    public partial class PremestanjeOpreme2 : Window
    {
        public static string selektovanoIme = "";
        public static int selektovanaKolicina = 0;
        public static Model.Oprema selekcija=null;

        public static ObservableCollection<Model.Oprema> Opreme
        {
            get;
            set;
        }

        public PremestanjeOpreme2()
        {
            InitializeComponent();
            Opreme = new ObservableCollection<Model.Oprema>() {
            new Model.Oprema() {Ime = "Flasteri",Kolicina=5 },
            new Model.Oprema() { Ime = "Medicinski aparati", Kolicina = 8 },
            new Model.Oprema() { Ime = "Stolice", Kolicina = 15 },
            new Model.Oprema() { Ime = "Stolovi", Kolicina = 157 },
            new Model.Oprema() { Ime = "Kreveti", Kolicina = 555 },
            new Model.Oprema() { Ime = "Zavoji", Kolicina = 45 }
        };
            this.DataContext = this;

        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Oprema opremica = (sender as Button).DataContext as Model.Oprema;
            opremica.Kolicina++;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Model.Oprema opremica = (sender as Button).DataContext as Model.Oprema;
            if (opremica.Kolicina >= 1)
            {
                opremica.Kolicina--;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (selekcija != null)
            {
                var s = new PremestanjeOpreme3();
                s.ShowDialog();
            }
        }

        private void dataGridOprema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedItem = dataGridOprema.SelectedItem;
            selekcija = selectedItem;
            selektovanaKolicina = selectedItem.Kolicina;
            selektovanoIme = selectedItem.Ime;
        }
    }
}
