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
    /// Interaction logic for ExaminationSchedulingPage.xaml
    /// </summary>
    public partial class ExaminationSchedulingPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<string> Kardiologija { get; set; } = new ObservableCollection<string>();
        public static ObservableCollection<string> Neurologija { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Doctors { get; set; } = new ObservableCollection<string>();
        public static bool loaded { get; set; } = false;
        public bool isButtonEnabled { get; set; } = false;
        public static string selectedDoctorName { get; set; }
        public static string selectedOdeljenje { get; set; }
        public ExaminationSchedulingPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Doctors = new ObservableCollection<string>();

            if(!loaded)
            {
                Kardiologija.Add("Ivan Petrovic");
                Kardiologija.Add("Jovana Mirkovic");
                Kardiologija.Add(Data.specialist.FullName);
                Neurologija.Add("Jelena Todorovic");
                Neurologija.Add("Marko Markovic");
                
                loaded = true;
            }
            foreach (string s in Kardiologija)
            {
                Doctors.Add(s);
            }
            foreach (string s in Neurologija)
            {
                Doctors.Add(s);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void nextStep(object sender, RoutedEventArgs e)
        {
            selectedDoctorName = label.Content as string;
            bool chosen = false;
            foreach (string s in Kardiologija)
            {
                if(selectedDoctorName.Equals(s))
                {
                    selectedOdeljenje = "Kardiologija";
                    chosen = true;
                    break;
                }
            }
            if(!chosen)
            {
                foreach (string s in Neurologija)
                {
                    if (selectedDoctorName.Equals(s))
                    {
                        selectedOdeljenje = "Neurologija";
                        chosen = true;
                        break;
                    }
                }
            }
            this.NavigationService.Navigate(new ExaminationDateSchedulingPage());
        }

        private void show(object sender, RoutedEventArgs e)
        {
            if(comboboc.SelectedIndex == 0 || comboboc.SelectedIndex == -1)
            {
                Doctors = new ObservableCollection<string>();
                foreach (string s in Kardiologija)
                {
                    Doctors.Add(s);
                }
                foreach (string s in Neurologija)
                {
                    Doctors.Add(s);
                }
            } else if (comboboc.SelectedIndex == 1)
            {
                Doctors = Kardiologija;
            } else
            {
                Doctors = Neurologija;
            }
            OnPropertyChanged("Doctors");
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

        private void doctorSelected(object sender, RoutedEventArgs e)
        {
            if (!isButtonEnabled)
            {
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }
    }
}
