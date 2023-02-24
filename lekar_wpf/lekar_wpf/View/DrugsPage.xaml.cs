using Controller;
using lekar_wpf.Model;
using Model.Manager;
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
    /// Interaction logic for DrugsPage.xaml
    /// </summary>
    public partial class DrugsPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<Drug> Drugs { get; set; }
        public static ObservableCollection<Drug> DrugsForApproval { get; set; }
        public static ObservableCollection<Drug> SearchedDrugs { get; set; }
        public ObservableCollection<Drug> PresentedDrugs { get; set; }
        public static bool lastApproved { get; set; } = true;
        public static DrugController drugController { get; set; }
        public DrugsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = App.Current as App;
            drugController = app.drugController;
            loadDrugs();
            PresentedDrugs = Drugs;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void viewProfile(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DoctorsProfilePage());
        }

        private void viewPatients(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsPage());
        }

        private void viewDrugs(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void viewSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }

        private void viewBlog(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BlogPage());
        }

        private void searchDrugs(object sender, RoutedEventArgs e)
        {
            SearchedDrugs = PresentedDrugs;
            var dialog = new SearchDrugsDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
            PresentedDrugs = SearchedDrugs;
            OnPropertyChanged("PresentedDrugs");
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Drugs != null && DrugsForApproval != null)
            {
                if (comboBox.SelectedIndex == 1)
                {
                    PresentedDrugs = DrugsForApproval;
                    lastApproved = false;
                }
                else
                {
                    PresentedDrugs = Drugs;
                    lastApproved = true;
                }
                OnPropertyChanged("PresentedDrugs");
            }
            
        }

        private void loadDrugs()
        {
            var app = App.Current as App;
            drugController = app.drugController;
            Drugs = new ObservableCollection<Drug>(drugController.GetAll().Where(drug => drug.Approved == true));
            DrugsForApproval = new ObservableCollection<Drug>(drugController.GetAll().Where(drug => drug.Approved == false));
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void generateDrugsReport(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsReportPage());
        }

        private void viewDrugInfo(object sender, RoutedEventArgs e)
        {
            if(datagrid.SelectedIndex >= 0)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    var dialog = new DrugInfoDialog(datagrid.SelectedIndex);
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                    drugController.Update(Drugs[datagrid.SelectedIndex]);
                    OnPropertyChanged();
                    comboBox.SelectedIndex = 0;
                }
                else
                {
                    var dialog = new DrugsForApprovalInfoDialog(datagrid.SelectedIndex);
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                    OnPropertyChanged();
                    comboBox.SelectedIndex = 1;
                }
            }
        }

        public void OnPropertyChanged(string name = null)
        {
            loadDrugs();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
