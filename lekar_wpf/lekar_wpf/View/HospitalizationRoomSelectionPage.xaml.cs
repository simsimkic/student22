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
    /// Interaction logic for HospitalizationRoomSelectionPage.xaml
    /// </summary>
    public partial class HospitalizationRoomSelectionPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<string> Rooms { get; set; } = new ObservableCollection<string>();
        public static bool loaded { get; set; } = false;
        public bool isButtonEnabled { get; set; } = false;
        public static string selectedRoom { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public HospitalizationRoomSelectionPage()
        {
            InitializeComponent();
            this.DataContext = this;

            if (!loaded)
            {
                Rooms.Add("102");
                Rooms.Add("304");
                Rooms.Add("216");
                loaded = true;
            }
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            selectedRoom = label.Content as string;
            this.NavigationService.Navigate(new HospitalizationDiagnosisPage());
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                this.NavigationService.Navigate(new PatientsProfileGPViewPage());
            }
            else
            {
                this.NavigationService.Navigate(new PatientsProfilePage());
            }
        }

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void roomSelected(object sender, RoutedEventArgs e)
        {
            if (!isButtonEnabled)
            {
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }
    }
}
