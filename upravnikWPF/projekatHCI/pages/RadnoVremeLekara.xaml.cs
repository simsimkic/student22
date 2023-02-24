using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RadnoVremeLekara.xaml
    /// </summary>
    public partial class RadnoVremeLekara : Window
    {
        public static string polje1;

        public RadnoVremeLekara()
        {
            InitializeComponent();
            ime.Text = Osoblje.imeO;
            prezime.Text = Osoblje.prezimeO;
        }
        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new Upravnik();
            s.Show();
            this.Close();
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim() == "")
            {
                toolTipTextBlock.Text = tb.Text;
                ((ToolTip)tb.ToolTip).Visibility = Visibility.Visible;
            }
            else
            {
               
                ((ToolTip)tb.ToolTip).Visibility = Visibility.Hidden;
            }
        }

        

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Text.Trim() == "")
            {
                toolTipTextBlock2.Text = tb.Text;
                ((ToolTip)tb.ToolTip).Visibility = Visibility.Visible;
            }
            else
            {

                ((ToolTip)tb.ToolTip).Visibility = Visibility.Hidden;
            }
           


        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            

            
                this.Close();
            
        }

       

        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var s = new Blog();
            s.ShowDialog();
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

        private void image10_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.LemonChiffon));

            Application.Current.Resources["MyStyle"] = style;
        }

      

       

        private void pliz_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";
            

            if (!Regex.IsMatch(pliz.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                pliz.Text = "";
            }


        }

        private void jedan_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(jedan.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                jedan.Text = "";
            }

        }

        private void nesto_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(nesto.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                nesto.Text = "";
            }

        }

        private void j_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(j.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                j.Text = "";
            }

        }

        private void myTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(myTextBox.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                myTextBox.Text = "";
            }

        }

        private void ll_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(ll.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                ll.Text = "";
            }
        }

        private void s_LostFocus(object sender, RoutedEventArgs e)
        {
            var regex = @"^([0-1]?[0-9]|2[0-3])-[0-5][0-9]$";


            if (!Regex.IsMatch(s.Text, regex))
            {
                MessageBox.Show("Neispravan unos");
                s.Text = "";
            }
        }
    }
}
