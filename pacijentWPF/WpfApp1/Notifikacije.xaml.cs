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
    /// Interaction logic for Notifikacije.xaml
    /// </summary>
    public partial class Notifikacije : Window
    {
        public int colNum = 0;
        public ObservableCollection<Obavestenje> Obavestenja
        {
            get;
            set;
        }
        public Notifikacije()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Notifications";
                nazad.Content = "BACK";
            }
            nazad.Focus();
            this.DataContext = this;
            Obavestenja = new ObservableCollection<Obavestenje>();
            Obavestenja.Add(new Obavestenje("Tekst obavestenja"));
            Obavestenja.Add(new Obavestenje("Tekst obavestenja"));
            Obavestenja.Add(new Obavestenje("Tekst obavestenja"));

        }
        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 1)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
