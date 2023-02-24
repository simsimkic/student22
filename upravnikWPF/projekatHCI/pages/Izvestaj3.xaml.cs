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
    /// Interaction logic for Izvestaj3.xaml
    /// </summary>
    public partial class Izvestaj3 : Window
    {

        public static ObservableCollection<Model.Osoba> OsobeLista
        {
            get;
            set;
        }
        public Izvestaj3()
        {
            InitializeComponent();
            OsobeLista = new ObservableCollection<Model.Osoba>()
            {
                new Model.Osoba() { Ime =Izvestaj2.ime, Prezime = Izvestaj2.prezime, Jmbg= Izvestaj2.jmbg,Mejl=Izvestaj2.mejl,Zanimanje = Izvestaj2.zanimanje, Specijalizacija = Izvestaj2.specijalizacija  },
                  new Model.Osoba() { Ime = "Milijana", Prezime = "Djordjevic", Jmbg= "0254103545",Mejl="ems@gmail.com" ,Zanimanje = "Lekar", Specijalizacija = "Kardiolog"  }

            };
            this.DataContext = this;
            pocetni.Text = Izvestaj.datum;
            krajnji.Text = Izvestaj.datum2;
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
            var s = new Izvestaj4();
            s.ShowDialog();
        }
    }
}
