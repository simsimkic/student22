using Controller;
using Model.Users;
using ProjekatKlinika.Controller;
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
    /// Interaction logic for Osoblje.xaml
    /// </summary>
    public partial class Osoblje : Window
    {
        public static string zanimanjeOsobe;
        public static string specijalizacijaO;
        public static string jmbgO;
        public static string mejlO;
        public static string imeO;
        public static string prezimeO;

        private readonly SecretaryController secretaryController;
        private readonly DoctorController doctorController;
        public static ObservableCollection<Secretary> OsobeLista
        {
            get;
            set;
        }
        public Osoblje()
        {
            InitializeComponent();

            var app = Application.Current as App;
            secretaryController = app.secretaryController;
            doctorController = app.doctorController;
            /* OsobeLista = new ObservableCollection<Model.Osoba>()
             {
                 new Model.Osoba() { Ime = "Emina", Prezime = "Turkovic", Jmbg= "0254103545",Mejl="ems@gmail.com" ,Zanimanje = "Lekar", Specijalizacija = "Kardiolog"  },
                 new Model.Osoba() { Ime = "Tamara", Prezime = "Rankovic", Jmbg= "0254103545",Mejl="tam@gmail.com" ,Zanimanje = "Sekretar", Specijalizacija = ""  },
                 new Model.Osoba() { Ime = "Milijana", Prezime = "Djordjevic", Jmbg= "0254103545",Mejl="ems@gmail.com" ,Zanimanje = "Lekar", Specijalizacija = "Kardiolog"  },

             };*/
            OsobeLista = new ObservableCollection<Secretary>( secretaryController.GetAll().ToList());

            OsobeLista.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Opreme_CollectionChanged);
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

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new PrikazOsoblja();
            s.Show();
        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = new Specijalizacije();
            s.Show();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new Registruj();
            s.Show();
            this.Close();
        }
        
       
        
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedItem = listView.SelectedItem;

             
             specijalizacijaO = selectedItem.Specijalizacija;
             jmbgO = selectedItem.Jmbg;
             imeO = selectedItem.Ime;
             prezimeO = selectedItem.Prezime;
             mejlO = selectedItem.Mejl;

            if (zanimanjeOsobe == "Lekar" || zanimanjeOsobe == "lekar")
            {

                var s = new PrikazOsoblja();

                s.lekarZanimanje.Text = zanimanjeOsobe;
                s.spec.Text = specijalizacijaO;
                s.jmbg.Text = jmbgO;
                s.ime.Text = imeO;
                s.prezime.Text = prezimeO;
                s.mejl.Text = mejlO;

                s.ShowDialog();

            }
            else if(zanimanjeOsobe=="Sekretar" || zanimanjeOsobe=="sekretar")
            {
                var s = new PrikazOsobljaSekretar();

                s.zanimanje.Text = zanimanjeOsobe;
                s.ime.Text = imeO;
                s.prezime.Text = prezimeO;
                s.mejl.Text = mejlO;
                s.jmbg.Text = jmbgO;

                s.ShowDialog();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Blog();
            s.ShowDialog();
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
    }
}
