using Model.Users;
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

namespace Sekretar_WPF_Project.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            App app = (App)App.Current;
            //foreach(Secretary secretary in (List<Secretary>)app.secretaryController.GetAll())
            {
                /*secretary.username = "username";
                secretary.password = "password";
                app.secretaryController.Update(secretary);*/                

                //  if (passwordbox.Password.Equals(secretary.password) && usernametextbox.Text.Equals(secretary.username))
                {
                    Application.Current.MainWindow.Show();
                    Close();
                }
            }

        }

    }
}
