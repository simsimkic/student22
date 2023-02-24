using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for DrugsReportSelectDrugs.xaml
    /// </summary>
    public partial class DrugsReportSelectDrugs : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<string> Drugs { get; set; } = new ObservableCollection<string>();
        public static ObservableCollection<string> SelectedDrugs { get; set; } = new ObservableCollection<string>();
        public bool isButtonEnabled { get; set; } = false;
        public DrugsReportSelectDrugs()
        {
            InitializeComponent();
            this.DataContext = this;

            Drugs.Clear();
            SelectedDrugs.Clear();

            Drugs.Add("Brufen");
            Drugs.Add("Panklav");
            Drugs.Add("Defrinol");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void nextStep(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsReportPreviewPage());
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void addDrug(object sender, RoutedEventArgs e)
        {
            int selectedIndex = datagrid.SelectedIndex;
            SelectedDrugs.Add(Drugs[selectedIndex]);
            Drugs.Remove(Drugs[selectedIndex]);
            OnPropertyChanged("Drugs");
            OnPropertyChanged("SelectedDrugs");

            if(!isButtonEnabled)
            {
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        private void removeDrug(object sender, RoutedEventArgs e)
        {
            int selectedIndex = datagridSelected.SelectedIndex;
            Drugs.Add(SelectedDrugs[selectedIndex]);
            SelectedDrugs.Remove(SelectedDrugs[selectedIndex]);
            OnPropertyChanged("Drugs");
            OnPropertyChanged("SelectedDrugs");

            if(isButtonEnabled && SelectedDrugs.Count == 0)
            {
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        private void addAllDrugs(object sender, RoutedEventArgs e)
        {
            foreach(string drug in Drugs)
            {
                SelectedDrugs.Add(drug);
            }
            Drugs.Clear();
            OnPropertyChanged("Drugs");
            OnPropertyChanged("SelectedDrugs");

            if (!isButtonEnabled)
            {
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        private void removeAllDrugs(object sender, RoutedEventArgs e)
        {
            foreach(string drug in SelectedDrugs)
            {
                Drugs.Add(drug);
            }
            SelectedDrugs.Clear();
            OnPropertyChanged("Drugs");
            OnPropertyChanged("SelectedDrugs");

            if (isButtonEnabled)
            {
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
