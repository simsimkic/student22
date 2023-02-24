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
    /// Interaction logic for Jezik.xaml
    /// </summary>
    public partial class Jezik : Window
    {
        public static int jezik1;
        public Podesavanja p;

        public Jezik(Podesavanja p)
        {
            this.p = p;
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Language";
                nazad.Content = "BACK";
                srpski.Content = "SERBIAN";
                engleski.Content = "ENGLISH";
            }
            srpski.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            jezik1 = 0;
            srpski.Content = "SRPSKI";
            engleski.Content = "ENGLESKI";
            nazad.Content = "NAZAD";
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            Podesavanja po = new Podesavanja();
            po.Show();
            p.Close();
            this.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            jezik1 = 1;
            srpski.Content = "SERBIAN";
            engleski.Content = "ENGLISH";
            nazad.Content = "BACK";
        }
    }
}
