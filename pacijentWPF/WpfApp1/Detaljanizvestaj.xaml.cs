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

namespace HCI
{
    /// <summary>
    /// Interaction logic for Detaljanizvestaj.xaml
    /// </summary>
    public partial class Detaljanizvestaj : Window
    {
        public Detaljanizvestaj(Izvestaj izvestaj)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                this.Title = "Izvestaj";
                nazad.Content = "NAZAD";
            }
            else
            {
                this.Title = "Report";
                nazad.Content = "BACK";
            }
            ime.Content = izvestaj.Lekar;
            datum.Content = izvestaj.Datum;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
