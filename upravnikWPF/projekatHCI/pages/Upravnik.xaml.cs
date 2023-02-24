using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using System.ComponentModel;

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for Upravnik.xaml
    /// </summary>
    public partial class Upravnik : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _mejl;

        public string Mejl
        {
            get
            {
                return _mejl;
            }
            set
            {
                if (value != _mejl)
                {
                    _mejl = value;
                    OnPropertyChanged("Mejl");
                }
            }
        }
        public Upravnik()
        {
            InitializeComponent();
            this.DataContext = this;
            Mejl = "eminaturkovic600@gmail.com";
        }

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Meni();
            s.Show();
            this.Close();
        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
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

        private void image5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Blog();
            s.ShowDialog();
        }
    }
}
