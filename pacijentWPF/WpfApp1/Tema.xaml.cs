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
    /// Interaction logic for Tema.xaml
    /// </summary>
    public partial class Tema : Window
    {
        public Tema()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Language";
                nazad.Content = "BACK";
                svetla.Content = "LIGHT";
                tamna.Content = "DARK";
            }
            svetla.Focus();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Svetla_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.White));
            style.Setters.Add(new Setter(Window.FontFamilyProperty, this.FontFamily));

            Application.Current.Resources["MyStyle"] = style;
        }

        private void Tamna_Click(object sender, RoutedEventArgs e)
        {
            Style style = new Style
            {
                TargetType = typeof(Window)
            };

            style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.DarkCyan));
            style.Setters.Add(new Setter(Window.FontFamilyProperty, this.FontFamily));
            //style.Setters.Add(new Setter(Window.BackgroundProperty, Brushes.SteelBlue));

            Application.Current.Resources["MyStyle"] = style;
        }
    }
}
