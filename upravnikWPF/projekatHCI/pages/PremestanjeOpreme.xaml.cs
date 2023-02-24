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
    /// Interaction logic for PremestanjeOpreme.xaml
    /// </summary>
    public partial class PremestanjeOpreme : Window
    {
        public static string selektovanaSoba="";

        public static ObservableCollection<Model.Soba> SobeLista
        {
            get;
            set;
        }
        public PremestanjeOpreme()
        {
            InitializeComponent();
           
            SobeLista = new ObservableCollection<Model.Soba>()
            {
                new Model.Soba() { Ime = "Soba broj 1" },
                new Model.Soba() {Ime="Soba broj 2" }

            };
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (selektovanaSoba != "")
            {
                var s = new PremestanjeOpreme2();
                s.ShowDialog();
            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic selectedItem = listView.SelectedItem;
            selektovanaSoba = selectedItem.Ime;
        }
    }
}
