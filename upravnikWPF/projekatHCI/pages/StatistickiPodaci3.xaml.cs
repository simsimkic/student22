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

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for StatistickiPodaci3.xaml
    /// </summary>
    public partial class StatistickiPodaci3 : Window
    {
        public StatistickiPodaci3()
        {
            InitializeComponent();
            imeSobe.Text = StatistickiPodaci2.selektovanaSoba;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new Meni();
            s.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
