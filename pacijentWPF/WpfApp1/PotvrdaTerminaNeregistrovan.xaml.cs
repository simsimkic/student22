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
    /// Interaction logic for PotvrdaTerminaNeregistrovan.xaml
    /// </summary>
    public partial class PotvrdaTerminaNeregistrovan : Window
    {
        public OdabirTermina parent;
        public PotvrdaTerminaNeregistrovan(OdabirTermina parent)
        {
            this.parent = parent;
            InitializeComponent();
            da.Focus();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Da_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow lw = new LogInWindow();
            lw.Show();
            UspesnoZakazivanje uz = new UspesnoZakazivanje();
            uz.Show();
            parent.Close();
            this.Close();
        }
    }
}
