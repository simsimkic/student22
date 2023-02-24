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
    /// Interaction logic for BezNaloga.xaml
    /// </summary>
    public partial class BezNaloga : Window
    {
        public BezNaloga()
        {
            InitializeComponent();
            ime.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zakazi z = new Zakazi(0, null);
            z.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LogInWindow lw = new LogInWindow();
            lw.Show();
            this.Close();
        }
    }
}
