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

namespace lekar_wpf
{
    /// <summary>
    /// Interaction logic for WizardBlog.xaml
    /// </summary>
    public partial class WizardBlog : Page
    {
        public WizardBlog()
        {
            InitializeComponent();
        }

        private void next(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new View.DoctorsProfilePage());
        }
    }
}
