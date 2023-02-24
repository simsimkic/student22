using Model.Manager;
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

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for DrugInfoDialog.xaml
    /// </summary>
    public partial class DrugInfoDialog : Window
    {
        public static Drug selectedDrug { get; set; }
        public DrugInfoDialog(int index)
        {
            InitializeComponent();
            this.DataContext = this;
            selectedDrug = DrugsPage.Drugs[index];
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void decreaseQuantity(object sender, RoutedEventArgs e)
        {
            var dialog = new DecreaseDrugQuantityDialog();
            dialog.Owner = this.Owner;
            this.Close();
            dialog.ShowDialog();
        }
    }
}
