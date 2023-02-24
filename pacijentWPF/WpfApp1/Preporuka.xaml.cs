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
    /// Interaction logic for Preporuka.xaml
    /// </summary>
    public partial class Preporuka : Window
    {
        public Preporuka()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Smart schedule";
                nazad.Content = "BACK";
                od.Content = "Start:";
                doL.Content = "End:";
                preporuka.Content = "APPOINTMENT";
                helpL.Content = "HELP";
                prioritet.Content = "Priority:";
                doctor.Content = "Doctor";
                time.Content = "Time";
            }
            dan1.Focus();
        }

        private void Preporuka_Click(object sender, RoutedEventArgs e)
        {
            PreporuceniTermin pt = new PreporuceniTermin(this);
            pt.Show();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            PreporukaLekari pl = new PreporukaLekari();
            pl.Show();
            this.Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            Pomoc p = new Pomoc();
            p.Show();
        }
    }
}
