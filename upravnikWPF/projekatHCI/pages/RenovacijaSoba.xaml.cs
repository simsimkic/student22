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
    /// Interaction logic for RenovacijaSoba.xaml
    /// </summary>
    public partial class RenovacijaSoba : Window
    {
        public static ObservableCollection<Model.Renoviranje> Renoviranja
        {
            get;
            set;
        }

        public RenovacijaSoba()
        {
            InitializeComponent();
            Renoviranja = new ObservableCollection<Model.Renoviranje>()
            {
                new Model.Renoviranje() {Ime="Soba 13", PocetniD="10.06.2020", KrajnjiD="08.07.2020" },
                new Model.Renoviranje() {Ime="Soba 43", PocetniD="12.06.2020", KrajnjiD="09.07.2020" },
                new Model.Renoviranje() {Ime="Soba 15", PocetniD="15.06.2020", KrajnjiD="07.07.2020" },
                new Model.Renoviranje() {Ime="Soba 17", PocetniD="15.06.2020", KrajnjiD="07.07.2020" }
            };
            this.DataContext = this;
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
