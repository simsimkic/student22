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
    /// Interaction logic for ReviewSoftwareWindow.xaml
    /// </summary>
    public partial class ReviewSoftwareWindow : Window
    {
        public List<String> Grades { get; set; }
        public ReviewSoftwareWindow()
        {
            Grades = new List<String>();
            Grades.Add("10");
            Grades.Add("9");
            Grades.Add("8");
            Grades.Add("7");
            Grades.Add("6");
            Grades.Add("5");
            Grades.Add("4");
            Grades.Add("3");
            Grades.Add("2");
            Grades.Add("1");
            Grades.Add("0");

            InitializeComponent();
            if (Application.Current.MainWindow.Resources["Theme"].Equals(0)) // 1 => Dark Theme , 0 => Light
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.Black);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.White);
            }
            else
            {
                this.Resources["CustomLabelColor"] = new SolidColorBrush(Colors.White);
                this.Resources["CustomBackgroundColor"] = new SolidColorBrush(Colors.Black);
            }
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //review
            MessageBox.Show("Feedback noted.");
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
