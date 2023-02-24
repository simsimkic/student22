using lekar_wpf.Model;
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
    /// Interaction logic for ReportsPage.xaml
    /// </summary>
    public partial class ReportsPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Report> reports { get; set; } = new ObservableCollection<Report>();
        public Patient selectedPatient { get; set; }
        public ReportsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            //selectedPatient = PatientsPage.selectedPatient;
            reports.Clear();
            foreach(Report r in selectedPatient.Reports)
            {
                reports.Add(r);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void check(object sender, RoutedEventArgs e)
        {
            reports.Clear();
            if (combobox.SelectedIndex == 0 || combobox.SelectedIndex == -1)
            {
                foreach (Report r in selectedPatient.Reports)
                {
                    reports.Add(r);
                }
            } else if (combobox.SelectedIndex == 1)
            {
                foreach (Report r in selectedPatient.Reports)
                {
                    if (r.Odeljenje.Equals("Kardiologija"))
                    {
                        reports.Add(r);
                    }
                }
            } else if (combobox.SelectedIndex == 2)
            {
                foreach (Report r in selectedPatient.Reports)
                {
                    if (r.Odeljenje.Equals("Neurologija"))
                    {
                        reports.Add(r);
                    }
                }
            } else if (combobox.SelectedIndex == 3)
            {
                foreach (Report r in selectedPatient.Reports)
                {
                    if (r.Odeljenje.Equals("Pulmologija"))
                    {
                        reports.Add(r);
                    }
                }
            } else
            {
                foreach (Report r in selectedPatient.Reports)
                {
                    if (r.Odeljenje.Equals("Opsta praksa"))
                    {
                        reports.Add(r);
                    }
                }
            }
            OnPropertyChanged("reports");
        }
    }
}
