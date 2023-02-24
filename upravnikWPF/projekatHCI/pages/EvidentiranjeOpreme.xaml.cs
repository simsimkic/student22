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
using System.Dynamic;

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for EvidentiranjeOpreme.xaml
    /// </summary>
    /// 
    public partial class EvidentiranjeOpreme : Window
    {
      
       

        public static ObservableCollection <Model.Oprema> Opreme
        {
            get;
            set;
        }

        public EvidentiranjeOpreme()
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
            
               Opreme.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Opreme_CollectionChanged);

                this.DataContext = this;
          
        }
        
        void Opreme_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    MessageBox.Show("Novi red je dodat");


                }
            
        }

        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new Upravnik();
            s.Show();
            this.Close();
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void Button_Nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Model.Oprema opremica= (sender as Button).DataContext as Model.Oprema;
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
            
           
            UnosOpreme unosOpreme = new UnosOpreme();
            unosOpreme.ShowDialog();

             

           
            
           

        }

        private void image9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.White));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.LemonChiffon));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Blog();
            s.ShowDialog();
        }
    }
}
