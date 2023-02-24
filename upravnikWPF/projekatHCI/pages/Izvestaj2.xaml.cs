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
    /// Interaction logic for Izvestaj2.xaml
    /// </summary>
    public partial class Izvestaj2 : Window
    {
        public static string ime;
        public static string prezime;
        public static string jmbg;
        public static string zanimanje;
        public static string mejl;
        public static string specijalizacija;

        public static string ime2;
        public static string prezime2;
        public static string jmbg2;
        public static string zanimanje2;
        public static string mejl2;
        public static string specijalizacija2;

        public static Model.Osoba selekcija;


        public static ObservableCollection<Model.Osoba> OsobeLista
        {
            get;
            set;
        }
        public Izvestaj2()
        {
            InitializeComponent();

            OsobeLista = new ObservableCollection<Model.Osoba>()
            {
                new Model.Osoba() { Ime = "Emina", Prezime = "Turkovic", Jmbg= "0254103545",Mejl="ems@gmail.com" ,Zanimanje = "Lekar", Specijalizacija = "Kardiolog"  },
                  new Model.Osoba() { Ime = "Milijana", Prezime = "Djordjevic", Jmbg= "0254103545",Mejl="ems@gmail.com" ,Zanimanje = "Lekar", Specijalizacija = "Kardiolog"  }

            };
            this.DataContext = this;
        }
        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Upravnik();
            s.Show();
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Meni();
            s.Show();
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
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selekcija != null)
            {
                var s = new Izvestaj3();
                s.ShowDialog();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selektovaniElement = listView.SelectedItems[0];
            selekcija = selektovaniElement;
            ime = selektovaniElement.Ime;
            prezime = selektovaniElement.Prezime;
            mejl = selektovaniElement.Mejl;
            specijalizacija = selektovaniElement.Specijalizacija;
            zanimanje = selektovaniElement.Zanimanje;
            jmbg = selektovaniElement.Jmbg;



        }
    }
}
