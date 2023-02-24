using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for DecreaseDrugQuantityDialog.xaml
    /// </summary>
    public partial class DecreaseDrugQuantityDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public DecreaseDrugQuantityDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void leave(object sender, RoutedEventArgs e)
        {
            var dialog = new DrugInfoDialog(DrugsPage.Drugs.IndexOf(DrugInfoDialog.selectedDrug));
            dialog.Owner = this.Owner;
            this.Close();
            dialog.ShowDialog();
        }

        private void decrease(object sender, RoutedEventArgs e)
        {
            int.TryParse(textBox.Text, out int i);
            DrugInfoDialog.selectedDrug.Quantity -= i;
            var dialog = new DrugInfoDialog(DrugsPage.Drugs.IndexOf(DrugInfoDialog.selectedDrug));
            dialog.Owner = this.Owner;
            this.Close();
            dialog.ShowDialog();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            string text = textBox.Text;
            Regex regex = new Regex("^[0-9]+$");
            if(!regex.IsMatch(text))
            {
                poruka1.Visibility = Visibility.Visible;
                poruka2.Visibility = Visibility.Hidden;
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
                return;
            }
            Double.TryParse(text, out double d);
            if (DrugInfoDialog.selectedDrug.Quantity < d) {
                poruka1.Visibility = Visibility.Hidden;
                poruka2.Visibility = Visibility.Visible;
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
                return;
            }
            poruka1.Visibility = Visibility.Hidden;
            poruka2.Visibility = Visibility.Hidden;
            isButtonEnabled = true;
            OnPropertyChanged("isButtonEnabled");

        }
    }
}
