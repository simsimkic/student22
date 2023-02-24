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
    /// Interaction logic for Font.xaml
    /// </summary>
    public partial class Font : Window
    {
        public Font()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Font";
                nazad.Content = "BACK";
                font1.Content = "SERBIAN";
                font2.Content = "ENGLISH";
            }
            font1.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.FontFamilyProperty, new FontFamily("Segoe UI")));
            style.Setters.Add(new Setter(Window.BackgroundProperty, this.Background));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.FontFamilyProperty, new FontFamily("Times New Roman")));
            style.Setters.Add(new Setter(Window.BackgroundProperty, this.Background));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
