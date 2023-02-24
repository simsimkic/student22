using Model.Manager;
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
    /// Interaction logic for ChangeDrugInfoDialog.xaml
    /// </summary>
    public partial class ChangeDrugInfoDialog : Window, INotifyPropertyChanged
    {
        public Drug selectedDrug { get; set; }
        public bool isButtonEnabled { get; set; } = true;
        public ChangeDrugInfoDialog(Drug selected)
        {
            InitializeComponent();
            this.DataContext = this;
            selectedDrug = selected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            bool enabled = true;
            if(name.Text == null || name.Text.Equals(""))
            {
                name.BorderBrush = System.Windows.Media.Brushes.Red;
                name.BorderThickness = new Thickness(1, 1, 1, 1);
                enabled = false;
            } else
            {
                name.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if (manufacturer.Text == null || manufacturer.Text.Equals(""))
            {
                manufacturer.BorderBrush = System.Windows.Media.Brushes.Red;
                manufacturer.BorderThickness = new Thickness(1, 1, 1, 1);
                enabled = false;
            }
            else
            {
                manufacturer.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            Regex regex = new Regex("^[1-9]([0-9]{1,2})?$");
            if (quantity.Text == null || quantity.Text.Equals("") || !regex.IsMatch(quantity.Text))
            {
                quantity.BorderBrush = System.Windows.Media.Brushes.Red;
                quantity.BorderThickness = new Thickness(1, 1, 1, 1);
                enabled = false;
            }
            else
            {
                quantity.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            isButtonEnabled = enabled;
            OnPropertyChanged("isButtonEnabled");
        }

        private void changeIngridient(object sender, RoutedEventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            int index = datagrid.SelectedIndex;
            selectedDrug.Ingredients[index] = senderTextBox.Text;
        }

        private void approve(object sender, RoutedEventArgs e)
        {
            selectedDrug.Name = name.Text;
            selectedDrug.Manufacturer = manufacturer.Text;
            if (int.TryParse(quantity.Text, out int i))
                selectedDrug.Quantity = i;
            DrugsPage.Drugs.Add(selectedDrug);
            DrugsPage.DrugsForApproval.Remove(selectedDrug);
            this.Close();
        }
    }
}
