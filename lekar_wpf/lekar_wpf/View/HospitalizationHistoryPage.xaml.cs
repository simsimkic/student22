
using Model.Users;
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
    /// Interaction logic for HospitalizationHistoryPage.xaml
    /// </summary>
    public partial class HospitalizationHistoryPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<string> diagnosisCodes { get; set; } = new ObservableCollection<string>();
        public static ObservableCollection<string> procedureCodes { get; set; } = new ObservableCollection<string>();
        public static bool loaded { get; set; } = false;
        public Patient selectedPatient { get; set; }
        public string EndOfHospitalization { get; set; }
        public HospitalizationHistoryPage()
        {
            InitializeComponent();
            this.DataContext = this;
            selectedPatient = PatientsPage.selectedPatient;
            //EndOfHospitalization = selectedPatient.EndOfHospitalization.ToString("dd/MM/yyyy");
            if(!loaded)
            {
                diagnosisCodes.Add("sifra1");
                diagnosisCodes.Add("sifra2");
                diagnosisCodes.Add("sifra3");
                procedureCodes.Add("sifra1");
                procedureCodes.Add("sifra2");
                procedureCodes.Add("sifra3");
                loaded = true;
            }
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HospitalizedPatientsProfilePage());
        }

        private void addProcedureCode(object sender, RoutedEventArgs e)
        {
            var dialog = new AddProcedureCodeDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void addDiagnosisCode(object sender, RoutedEventArgs e)
        {
            var dialog = new AddDiagnosisCodeDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void editHospitalizationEndDate(object sender, RoutedEventArgs e)
        {
            var dialog = new EditHospitalizationEndDateDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
            //EndOfHospitalization = selectedPatient.EndOfHospitalization.ToString("dd/MM/yyyy");
            OnPropertyChanged("EndOfHospitalization");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
