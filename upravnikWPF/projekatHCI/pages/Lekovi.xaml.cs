using Controller;
using Model.Manager;
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
    /// Interaction logic for Lekovi.xaml
    /// </summary>
    public partial class Lekovi : Window
{
        //  public static string myValueFromBoxName;
        // public static int myNumberFromBox;
        // public static string myValueFromBoxSastav;

        private readonly DrugController drugController;
        public  static ObservableCollection<Drug> SviLekovi
        {
            get;
            set;
        }


        public Lekovi()
        {
            InitializeComponent();
            var app = Application.Current as App;
            drugController = app.drugController;

            SviLekovi = new ObservableCollection<Drug>(drugController.GetAll().ToList());
            /*
            SviLekovi = new ObservableCollection<Model.Lek>() {
            new Model.Lek() {Ime = "Aspirin",Kolicina=5, Sastav="sastav" },
            new Model.Lek() {Ime = "Panadol",Kolicina=84, Sastav="sastav" },
            new Model.Lek() {Ime = "Andol",Kolicina=55, Sastav="sastav" },
            new Model.Lek() {Ime = "Brufen",Kolicina=45, Sastav="sastav" }
            
        };*/

           SviLekovi.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Lekovi_CollectionChanged);
            this.DataContext = this;
        }

        void Lekovi_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                MessageBox.Show("Novi lek je dodat");


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

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Drug opremica = (sender as Button).DataContext as Drug;
            opremica.Quantity++;
            drugController.Update(opremica);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Drug opremica = (sender as Button).DataContext as Drug;
            opremica.Quantity--;
            drugController.Update(opremica);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UnosNoveVrsteLeka unosLeka = new UnosNoveVrsteLeka();
            unosLeka.Show();
            this.Close();
         //   myValueFromBoxName = UnosNoveVrsteLeka.myName;
           // myNumberFromBox = UnosNoveVrsteLeka.number;
            //myValueFromBoxSastav = UnosNoveVrsteLeka.mySastav;

            //SviLekovi.Add(new Model.Lek() { Ime = myValueFromBoxName, Kolicina = myNumberFromBox, Sastav = myValueFromBoxSastav });
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
