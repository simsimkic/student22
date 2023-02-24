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

namespace HCI
{
    /// <summary>
    /// Interaction logic for PrikazLekova.xaml
    /// </summary>
    public partial class PrikazLekova : Window
    {
        public int colNum = 0;
        public ObservableCollection<Lek> Lekovi
        {
            get;
            set;
        }
        public PrikazLekova()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Medicine list";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            nazad.Focus();
            this.DataContext = this;
            Lekovi = new ObservableCollection<Lek>();
            Lekovi.Add(new Lek("LEK1", "01.06.2020."));
            Lekovi.Add(new Lek("LEK2", "02.06.2020."));
            Lekovi.Add(new Lek("LEK3", "03.06.2020."));
            Lekovi.Add(new Lek("LEK4", "04.06.2020."));
            Lekovi.Add(new Lek("LEK5", "05.06.2020."));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            mm.Show();
            this.Close();

        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 2)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DataGridLekovi_Selected(object sender, RoutedEventArgs e)
        {
            Lek lek1 = (Lek)DataGridLekovi.SelectedItem;
            DetaljanLek dl = new DetaljanLek(lek1);
            DataGridLekovi.UnselectAll();
            nazad.Focus();
            dl.Show();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Lek lek1 = (Lek)DataGridLekovi.SelectedItem;
                DetaljanLek dl = new DetaljanLek(lek1);
                DataGridLekovi.UnselectAll();
                nazad.Focus();
                dl.Show();
            }
        }
    }
}
