using Controller;
using System;
using System.Collections.Generic;
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

namespace HCI
{
    /// <summary>
    /// Interaction logic for PromenaLozinke.xaml
    /// </summary>
    public partial class PromenaLozinke : Window
    {
        private readonly PatientController patientController;
        public PromenaLozinke()
        {
            InitializeComponent();
            var app = Application.Current as App;

            patientController = app.patientController;
            if (Jezik.jezik1 == 0)
            {
            }
            else
            {
                this.Title = "Change password";
                nazad.Content = "BACK";
                saveB.Content = "SAVE";
                staraLabel.Content = "Old password:";
                novaLabel.Content = "New password";
            }
            stara.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(stara.Password.Equals(LogInWindow.ulogovaniPacijent.password) && nova.Password != "")
            {
                LogInWindow.ulogovaniPacijent.password = nova.Password;
                patientController.Update(LogInWindow.ulogovaniPacijent);

                PotvrdaPromeneLozinke ppl = new PotvrdaPromeneLozinke();
                ppl.Show();
                this.Close();
            }
            else
            {
                stara.BorderBrush = Brushes.Red;
                nova.BorderBrush = Brushes.Red;
                nova.Password = "";
                stara.Password = "";
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
