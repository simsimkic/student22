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
    /// Interaction logic for DrugsForApprovalInfoDialog.xaml
    /// </summary>
    public partial class DrugsForApprovalInfoDialog : Window
    {
        public static Drug selectedDrug { get; set; }
        public DrugsForApprovalInfoDialog(int index)
        {
            InitializeComponent();
            this.DataContext = this;
            if (index >= 0)
                selectedDrug = DrugsPage.DrugsForApproval[index];
        }

        private void approve(object sender, RoutedEventArgs e)
        {
            selectedDrug.Approved = true;
            DrugsPage.drugController.Update(selectedDrug);
            this.Close();
        }

        private void refuse(object sender, RoutedEventArgs e)
        {
            var dialog = new ChangeDrugInfoDialog(selectedDrug);
            dialog.Owner = this.Owner;
            this.Close();
            dialog.ShowDialog();
        }
    }
}
