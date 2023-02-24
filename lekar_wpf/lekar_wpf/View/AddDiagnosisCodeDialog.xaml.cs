using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for AddDiagnosisCodeDialog.xaml
    /// </summary>
    public partial class AddDiagnosisCodeDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public AddDiagnosisCodeDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            HospitalizationHistoryPage.diagnosisCodes.Add(diagnosis.Text);
            this.Close();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            if (diagnosis.Text.Equals("") || diagnosis.Text.Length > 10)
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.Red;
                diagnosis.BorderThickness = new Thickness(1);
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            }
            else
            {
                diagnosis.BorderBrush = System.Windows.Media.Brushes.LightBlue;
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
