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
    /// Interaction logic for ExaminationTimeSchedulingPage.xaml
    /// </summary>
    public partial class ExaminationTimeSchedulingPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<string> Appointments { get; set; } = new ObservableCollection<string>();
        public static bool loaded { get; set; } = false;
        public bool isButtonEnabled { get; set; } = false;
        public string selectedAppointment { get; set; } = "";
        public static string selectedTime
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ExaminationTimeSchedulingPage()
        {
            InitializeComponent();
            this.DataContext = this;

            if(!loaded)
            {
                Appointments.Add("10:10");
                Appointments.Add("10:30");
                Appointments.Add("11:15");
                loaded = true;
            }
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            selectedTime = selectedAppointment;
            this.NavigationService.Navigate(new ExaminationSchedulingDiagnosisPage());
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

        private void selectDifferentTime(object sender, RoutedEventArgs e)
        {
            var dialog = new ManuallyChooseTimeDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void appointmentSelected(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (string)datagrid.SelectedItem;
            OnPropertyChanged("selectedAppointment");
            if(!isButtonEnabled)
            {
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
