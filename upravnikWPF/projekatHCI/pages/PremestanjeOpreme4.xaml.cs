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
    /// Interaction logic for PremestanjeOpreme4.xaml
    /// </summary>
    /// 
    public partial class PremestanjeOpreme4 : Window
    {
        public static ObservableCollection<Model.Oprema> Opreme
        {
            get;
            set;
        }

        public PremestanjeOpreme4()
        {
            InitializeComponent();
            Opreme = new ObservableCollection<Model.Oprema>() {
            new Model.Oprema() {Ime =PremestanjeOpreme2.selektovanoIme ,Kolicina=PremestanjeOpreme2.selektovanaKolicina }
           
           
        };
            prvaSoba.Text = PremestanjeOpreme.selektovanaSoba;
            DrugaSoba.Text = PremestanjeOpreme3.selektovanaSoba;

            this.DataContext = this;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
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
            
            

            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new Meni();
            s.Show();
            this.Close();
        }
    }
}
