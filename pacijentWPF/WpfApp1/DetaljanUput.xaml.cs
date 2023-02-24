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
    /// Interaction logic for DetaljanUput.xaml
    /// </summary>
    public partial class DetaljanUput : Window
    {
        public DetaljanUput(Uput uput)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                this.Title = "Uput";
                nazad.Content = "NAZAD";
            }
            else
            {
                this.Title = "Referral";
                nazad.Content = "BACK";
            }
            ime.Content = uput.Lekar;
            datum.Content = uput.Datum;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
