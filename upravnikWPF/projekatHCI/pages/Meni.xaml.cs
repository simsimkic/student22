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
    /// Interaction logic for Meni.xaml
    /// </summary>
    public partial class Meni : Window
    {
        public Meni()
        {
            InitializeComponent();
        }

        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Upravnik();
            s.Show();
            this.Close();
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
           // var s = new Meni();
            //s.Show();
        }

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new MainWindow();
            s.Show();
            this.Close();
        }

       

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var s = new EvidentiranjeOpreme();
            s.ShowDialog();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new EvidentiranjeOpreme();
            s.ShowDialog();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Sobe();
            s.ShowDialog();
        }

        private void Label_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            var s = new Lekovi();
            s.ShowDialog();
        }

        private void Label_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            var s = new Osoblje();
            s.ShowDialog();
        }

        private void Label_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            var s = new OsobljeLekar();
        s.ShowDialog();

        }

        private void Label_MouseDown_5(object sender, MouseButtonEventArgs e)
        {
       //     var s = new RadnoVremeLekara();
         //   s.ShowDialog();
        }

        private void Label_MouseDown_6(object sender, MouseButtonEventArgs e)
        {

            var s = new Specijalizacije();
            s.ShowDialog();
        }

        private void Label_MouseDown_7(object sender, MouseButtonEventArgs e)
        {
            var s = new Renoviranje();
            s.ShowDialog();
        }

        private void Label_MouseDown_8(object sender, MouseButtonEventArgs e)
        {
            var s = new Izvestaj();
            s.ShowDialog();
        }

        private void Label_MouseDown_9(object sender, MouseButtonEventArgs e)
        {
            var s = new StatistickiPodaci();
            s.ShowDialog();
        }

        private void Label_MouseDown_10(object sender, MouseButtonEventArgs e)
        {
            var s = new PremestanjeOpreme();
            s.ShowDialog();
        }

        private void image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            var s = new Blog();
            s.ShowDialog();
            
        }

        private void image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.LemonChiffon));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void image9_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.White));

            Application.Current.Resources["MyStyle"] = style;
        }
    }
}
