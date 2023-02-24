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
    /// Interaction logic for Sobe.xaml
    /// </summary>
    public partial class Sobe : Window
    {
        private readonly RoomController roomController;
        public static Room selectedRoom;
        public static ObservableCollection<Room> SobeLista
        {
            get;
            set;
        }
        public Sobe()
        {
            InitializeComponent();
            var app = Application.Current as App;
            roomController = app.roomController;

            SobeLista = new ObservableCollection<Room>(roomController.GetAll().ToList());
            /*  SobeLista = new ObservableCollection<Model.Soba>()
              {
                  new Model.Soba() { Ime = "Soba broj 1" },
                  new Model.Soba() {Ime="Soba broj 2" }

              };*/
            this.DataContext = this;
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

        

      

        private void listView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedItem = listView.SelectedItem;

            var imeSobe = selectedItem.RoomNumber;
            selectedRoom = roomController.Get(selectedItem.IdNumber);

            var s = new Soba2();

            s.naziv.Text = imeSobe.ToString();

            s.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new UnosNoveSobe();
            s.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void image5_MouseEnter(object sender, MouseEventArgs e)
        {
            listView.Style = this.Resources["baseStyle"] as Style;

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
