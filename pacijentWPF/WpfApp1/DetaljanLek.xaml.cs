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
    /// Interaction logic for DetaljanLek.xaml
    /// </summary>
    public partial class DetaljanLek : Window
    {
        public DetaljanLek(Lek lek)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                this.Title = "Lek";
                nazad.Content = "NAZAD";
            }
            else
            {
                this.Title = "Medicine";
                nazad.Content = "BACK";
            }
            ime.Content = lek.Ime;
            datum.Content = lek.Datum;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
