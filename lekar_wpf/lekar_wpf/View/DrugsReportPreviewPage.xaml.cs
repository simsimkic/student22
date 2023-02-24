using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DrugsReportPreviewPage.xaml
    /// </summary>
    public partial class DrugsReportPreviewPage : Page
    {
        public ObservableCollection<string> Drugs { get; set; }

        public string interval { get; set; }
        public DrugsReportPreviewPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Drugs = DrugsReportSelectDrugs.SelectedDrugs;
            interval = DrugsReportPage.startDate.ToString("dd/MM/yyyy") + " - " + DrugsReportPage.enddDate.ToString("dd/MM/yyyy");
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsReportGenerated());
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }
    }
}
