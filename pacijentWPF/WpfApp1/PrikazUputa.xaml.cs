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
    /// Interaction logic for PrikazUputa.xaml
    /// </summary>
    public partial class PrikazUputa : Window
    {
        public int colNum = 0;
        public ObservableCollection<Uput> Uputi
        {
            get;
            set;
        }
        public PrikazUputa()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Referrals";
                nazad.Content = "BACK";
                helpL.Content = "HELP";
            }
            nazad.Focus();
            this.DataContext = this;
            Uputi = new ObservableCollection<Uput>();
            Uputi.Add(new Uput("Ime Prezime 1", "01.06.2020."));
            Uputi.Add(new Uput("Ime Prezime 2", "02.06.2020."));
            Uputi.Add(new Uput("Ime Prezime 3", "03.06.2020."));
            Uputi.Add(new Uput("Ime Prezime 4", "04.06.2020."));
            Uputi.Add(new Uput("Ime Prezime 5", "05.06.2020."));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            UputiInterval ui = new UputiInterval();
            ui.Show();
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

        private void DataGridUputi_Selected(object sender, RoutedEventArgs e)
        {
            Uput uput1 = (Uput)DataGridUputi.SelectedItem;
            DetaljanUput du = new DetaljanUput(uput1);
            DataGridUputi.UnselectAll();
            nazad.Focus();
            du.Show();
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                Uput uput1 = (Uput)DataGridUputi.SelectedItem;
                DetaljanUput du = new DetaljanUput(uput1);
                DataGridUputi.UnselectAll();
                nazad.Focus();
                du.Show();
            }
        }
    }
}
