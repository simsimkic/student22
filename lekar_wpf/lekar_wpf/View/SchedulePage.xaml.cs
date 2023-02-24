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
    /// Interaction logic for SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page, INotifyPropertyChanged
    {
        public string currentDate { get; set; }
        public ObservableCollection<Appointment> appointments { get; set; }
        public int shifted { get; set; } = 0;
        public static Appointment selectedAppointment { get; set; }
        public bool isButtonEnabled { get; set; }
        public string workingHours { get; set; }
        public SchedulePage(int s=0)
        {
            InitializeComponent();
            this.DataContext = this;
            shifted += s;
            appointments = new ObservableCollection<Appointment>();
            currentDate = DateTime.Now.AddDays(shifted).ToString("dd/MM/yyyy");
            foreach(Appointment ap in MainWindow.appointments)
            {
                if(ap.StartPoint.ToString("dd/MM/yyyy").Equals(currentDate))
                {
                    if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
                    {
                        if (ap.Type.Equals("Pregled"))
                        {
                            ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                            appointments.Add(ap);
                        }
                    }
                    else
                    {
                        ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                        appointments.Add(ap);
                    }
                }
            }
            OnPropertyChanged("appointments");
            if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                isButtonEnabled = false;
            } else
            {
                isButtonEnabled = true;
            }
            OnPropertyChanged("isButtonEnabled");
            if (DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Saturday || DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Sunday)
            {
                workingHours = "Radno vreme: Neradan dan";
            }
            else
            {
                workingHours = "Radno vreme: 08:00-16:00";
            }
            OnPropertyChanged("workingHours");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void viewProfile(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DoctorsProfilePage());
        }

        private void viewPatients(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PatientsPage());
        }

        private void viewDrugs(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DrugsPage());
        }

        private void viewSchedule(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SchedulePage());
        }

        private void viewBlog(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BlogPage());
        }

        private void viewPatientsProfile(object sender, RoutedEventArgs e)
        {
            //PatientsPage.selectedPatient = appointments[datagrid.SelectedIndex].Patient;
            selectedAppointment = appointments[datagrid.SelectedIndex];
            if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
            {
                this.NavigationService.Navigate(new PatientsProfileGPViewPage());
            }
            else
            {
                this.NavigationService.Navigate(new PatientsProfilePage());
            }
        }

        private void viewReferral(object sender, RoutedEventArgs e)
        {
            if(isButtonEnabled)
            {
                //PatientsPage.selectedPatient = appointments[datagrid.SelectedIndex].Patient;
                selectedAppointment = appointments[datagrid.SelectedIndex];
                this.NavigationService.Navigate(new ScheduleViewReferralPage());
            }
        }

        private void viewMonthlySchedule(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 1)
                this.NavigationService.Navigate(new MonthlySchedulePage());
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void shiftForward(object sender, RoutedEventArgs e)
        {
            if(shifted <= 29)
            {
                shifted++;
                currentDate = DateTime.Now.AddDays(shifted).ToString("dd/MM/yyyy");
                OnPropertyChanged("currentDate");
                appointments.Clear();
                foreach (Appointment ap in MainWindow.appointments)
                {
                    if (ap.StartPoint.ToString("dd/MM/yyyy").Equals(currentDate))
                    {
                        if (DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
                        {
                            if (ap.Type.Equals("Pregled"))
                            {
                                ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                                appointments.Add(ap);
                            }
                        }
                        else
                        {
                            ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                            appointments.Add(ap);
                        }
                    }
                }
                OnPropertyChanged("appointments");
                if (DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Saturday || DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Sunday)
                {
                    workingHours = "Radno vreme: Neradan dan";
                }
                else
                {
                    workingHours = "Radno vreme: 08:00-16:00";
                }
                OnPropertyChanged("workingHours");
            }
        }

        private void shiftBackward(object sender, RoutedEventArgs e)
        {
            if (shifted > 0)
            {
                shifted--;
                currentDate = DateTime.Now.AddDays(shifted).ToString("dd/MM/yyyy");
                OnPropertyChanged("currentDate");
                appointments.Clear();
                foreach (Appointment ap in MainWindow.appointments)
                {
                    if (ap.StartPoint.ToString("dd/MM/yyyy").Equals(currentDate))
                    {
                        if(DoctorsProfilePage.signedIn.Specialization.Equals("Lekar opste prakse"))
                        {
                            if(ap.Type.Equals("Pregled"))
                            {
                                ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                                appointments.Add(ap);
                            }
                        }
                        else
                        {
                            ap.Inter = ap.StartPoint.ToString("hh:mm") + "-" + ap.EndPoint.ToString("hh:mm");
                            appointments.Add(ap);
                        }
                    }
                    OnPropertyChanged("appointments");
                }
                if (DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Saturday || DateTime.Now.AddDays(shifted).DayOfWeek == DayOfWeek.Sunday)
                {
                    workingHours = "Radno vreme: Neradan dan";
                }
                else
                {
                    workingHours = "Radno vreme: 08:00-16:00";
                }
                OnPropertyChanged("workingHours");
            }
        }
    }
}
