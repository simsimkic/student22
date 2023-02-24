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
    /// Interaction logic for Specijalizacije.xaml
    /// </summary>
    public partial class Specijalizacije : Window
    {
        public static ObservableCollection<Model.Specijalizacija> Specijalizacijee
        {
            get;
            set;
        }
        public Specijalizacije()
        {
            InitializeComponent();
            Specijalizacijee = new ObservableCollection<Model.Specijalizacija>()
            {
                new Model.Specijalizacija() {Naziv="Opsta praksa" },
                 new Model.Specijalizacija() {Naziv="Kardiolog" },
                  new Model.Specijalizacija() {Naziv="Otorinolaringolog" }

            };


            Specijalizacijee.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Specijalizacijee_CollectionChanged);
            this.DataContext = this;
        }
        void Specijalizacijee_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajSpecijalizaciju add = new DodajSpecijalizaciju();
            add.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
