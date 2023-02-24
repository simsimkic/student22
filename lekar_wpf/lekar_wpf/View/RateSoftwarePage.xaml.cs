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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for RateSoftwarePage.xaml
    /// </summary>
    public partial class RateSoftwarePage : Page
    {
        public RateSoftwarePage()
        {
            InitializeComponent();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HelpPage());
        }

        private void rate(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HelpPage());
            var dialog = new SoftwareRatedDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }
    }
}
