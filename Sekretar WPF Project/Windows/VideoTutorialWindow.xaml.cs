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
using System.Windows.Threading;

namespace Sekretar_WPF_Project.Windows
{
	/// <summary>
	/// Interaction logic for VideoTutorialWindow.xaml
	/// </summary>
	public partial class VideoTutorialWindow : Window
	{
		public VideoTutorialWindow()
		{
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

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			if (mePlayer.Source != null)
			{
				if (mePlayer.NaturalDuration.HasTimeSpan)
					lblStatus.Content = String.Format("{0} / {1}", mePlayer.Position.ToString(@"mm\:ss"), mePlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
			}
			else
				lblStatus.Content = "No file selected...";
		}

		private void btnPlay_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Play();
		}

		private void btnPause_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Pause();
		}

		private void btnStop_Click(object sender, RoutedEventArgs e)
		{
			mePlayer.Stop();
		}
	}
}
