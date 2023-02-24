
using Model.Users;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SearchPatientsDialog.xaml
    /// </summary>
    public partial class SearchPatientsDialog : Window
    {
        public static ObservableCollection<Patient> patients { get; set; }
        public SearchPatientsDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void beginSearch(object sender, RoutedEventArgs e)
        {
            patients = new ObservableCollection<Patient>();
            foreach(Patient p in PatientsPage.allPatients)
            {
                patients.Add(p);
            }
            Regex regex = new Regex("^ *$");
            if(regex.IsMatch(name.Text) && regex.IsMatch(surname.Text) && regex.IsMatch(jmbg.Text) && regex.IsMatch(recordNumber.Text))
            {
                if(!hospitalized.IsChecked.Value)
                {
                    this.Close();
                    return;
                }
            }
            if(name.Text != "")
            {
                foreach(Patient p in PatientsPage.allPatients)
                {
                    if(!p.name.Split(' ')[0].Equals(name.Text))
                    {
                        patients.Remove(p);
                    }
                }
            }
            if (surname.Text != "")
            {
                foreach (Patient p in PatientsPage.allPatients)
                {
                    if(p.name.Split(' ').Length > 1)
                    {
                        if (!p.name.Split(' ')[1].Equals(surname.Text))
                        {
                            patients.Remove(p);
                        }
                    }
                    else
                    {
                        patients.Remove(p);
                    }
                }
            }
            if (jmbg.Text != "")
            {
                foreach (Patient p in PatientsPage.allPatients)
                {
                    if (!p.jmbg.Equals(jmbg.Text))
                    {
                        patients.Remove(p);
                    }
                }
            }
            if (recordNumber.Text != "")
            {

            }
            this.Close();
        }
    }
}
