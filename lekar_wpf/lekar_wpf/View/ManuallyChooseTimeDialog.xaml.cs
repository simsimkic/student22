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
    /// Interaction logic for ManuallyChooseTimeDialog.xaml
    /// </summary>
    public partial class ManuallyChooseTimeDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public ManuallyChooseTimeDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void increaseHour(object sender, RoutedEventArgs e)
        {
            if (int.Parse(hours.Text) != 23)
                hours.Text = (int.Parse(hours.Text) + 1).ToString();
            if (int.Parse(hours.Text) != 23)
                increaseHourButton.Content = (int.Parse(hours.Text) + 1).ToString();
            if (int.Parse(hours.Text) != 0)
                decreaseHourButton.Content = (int.Parse(hours.Text) - 1).ToString();
        }

        private void decreaseHour(object sender, RoutedEventArgs e)
        {
            if (int.Parse(hours.Text) != 0)
                hours.Text = (int.Parse(hours.Text) - 1).ToString();
            if (int.Parse(hours.Text) != 0)
                decreaseHourButton.Content = (int.Parse(hours.Text) - 1).ToString();
            if (int.Parse(hours.Text) != 23)
                increaseHourButton.Content = (int.Parse(hours.Text) + 1).ToString();
        }

        private void increaseMinute(object sender, RoutedEventArgs e)
        {
            if (int.Parse(minutes.Text) != 59)
                minutes.Text = (int.Parse(minutes.Text) + 1).ToString();
            if (int.Parse(minutes.Text) != 59)
                increaseMinuteButton.Content = (int.Parse(minutes.Text) + 1).ToString();
            if (int.Parse(minutes.Text) != 0)
                decreaseMinuteButton.Content = (int.Parse(minutes.Text) - 1).ToString();
        }

        private void decreaseMinute(object sender, RoutedEventArgs e)
        {
            if (int.Parse(minutes.Text) != 0)
                minutes.Text = (int.Parse(minutes.Text) - 1).ToString();
            if (int.Parse(minutes.Text) != 0)
                decreaseMinuteButton.Content = (int.Parse(minutes.Text) - 1).ToString();
            if (int.Parse(minutes.Text) != 59)
                increaseMinuteButton.Content = (int.Parse(minutes.Text) + 1).ToString();
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void check(object sender, RoutedEventArgs e)
        {
            if(minutes != null)
            {
                if (int.TryParse(minutes.Text, out int m))
                {
                    if (hours.Text != "10" || (m < 0 || m > 15))
                    {
                        if(poruka != null)
                        {
                            poruka.Visibility = Visibility.Visible;
                            isButtonEnabled = false;
                        }
                    }
                    else
                    {
                        if(poruka != null)
                        {
                            poruka.Visibility = Visibility.Hidden;
                            isButtonEnabled = true;
                        }
                    }
                    OnPropertyChanged("isButtonEnabled");
                }
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            ExaminationTimeSchedulingPage.Appointments.Add(hours.Text + ":" + minutes.Text);
            OperationTimeSchedulingPage.Appointments.Add(hours.Text + ":" + minutes.Text);
            this.Close();
        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
