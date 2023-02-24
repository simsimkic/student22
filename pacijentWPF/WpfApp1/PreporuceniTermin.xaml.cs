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
    /// Interaction logic for PreporuceniTermin.xaml
    /// </summary>
    public partial class PreporuceniTermin : Window
    {
        public Preporuka p;
        public PreporuceniTermin(Preporuka p)
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "";
                nazad.Content = "BACK";
                da.Content = "YES";
                textL.Content = "Schedule appointment?";
            }
            da.Focus();
            this.p = p;
        }

        private void Da_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mm = new MainMenu();
            UspesnoZakazivanje uz = new UspesnoZakazivanje();
            mm.Show();
            uz.Show();
            p.Close();
            this.Close();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
