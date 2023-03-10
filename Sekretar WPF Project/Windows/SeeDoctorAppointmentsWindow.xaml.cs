using Model.Doctor;
using Model.Manager;
using Model.Users;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SeeDoctorAppointmentsWindow.xaml
    /// </summary>
    public partial class SeeDoctorAppointmentsWindow : Window
    {
        Doctor doc;
        ViewModel vm = ViewModel.getInstance();
        public SeeDoctorAppointmentsWindow(Doctor doctor)
        {
            InitializeComponent();
            doc = doctor;            
            dgDoctorAppointments.ItemsSource = vm.getAppointmentsForDoctor(doctor);
            dgDoctorAppointments.DataContext = vm;
            namesurnamelabel.Content = "Dr " + doctor.name + " " + doctor.surname;
            if(doctor is DoctorSpecialist)
            {
                DoctorSpecialist d = (DoctorSpecialist)doctor;
                specializationlabel.Content = "Spec: " + d.Specialization;
            }
            else
            {
                specializationlabel.Content = "General practitioner";
            }


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
        }

        private void Button_Apply(object sender, RoutedEventArgs e)
        {
            string timestartstring = timepickerstart.Text;
            string timeendstring = timepickerend.Text;
            string datestartstring = datepickerstart.Text;
            string dateendstring = datepickerend.Text;

            DateTime myDateStart;
            if (!DateTime.TryParse(datestartstring, out myDateStart))
            {
                // handle parse failure
            }
            DateTime myDateEnd;
            if (!DateTime.TryParse(dateendstring, out myDateEnd))
            {
                // handle parse failure
            }

            bool vremeselektovano = false;
            bool datumselektovan = false;
            ObservableCollection<Appointment> itemsource = vm.getAppointmentsForDoctor(doc);
            ObservableCollection<Appointment> newtimeitemsource = new ObservableCollection<Appointment>();
            ObservableCollection<Appointment> newdateitemsource = new ObservableCollection<Appointment>();

            if (timestartstring != null && !timestartstring.Equals("") && timeendstring != null && !timeendstring.Equals(""))
            {
                vremeselektovano = true;

                string[] timestartparts = timestartstring.Split(':');
                int timestart = int.Parse(timestartparts[0] + timestartparts[1]);
                string[] timeendparts = timeendstring.Split(':');
                int timeend = int.Parse(timeendparts[0] + timeendparts[1]);

                foreach (Appointment appointment in itemsource)
                {
                    int appointmenttimestart = appointment.Duration.StartTime.Hour * 100 + appointment.Duration.StartTime.Minute;
                    int appointmenttimeend = appointment.Duration.EndTime.Hour * 100 + appointment.Duration.EndTime.Minute;

                    if ((timestart <= appointmenttimestart) && (timeend >= appointmenttimeend))
                    {
                        newtimeitemsource.Add(appointment);
                    }
                }

            }
            if (datestartstring != null && !datestartstring.Equals("") && dateendstring != null && !dateendstring.Equals(""))
            {
                string[] datestartparts = datestartstring.Split('.');
                string[] dateendparts = dateendstring.Split('.');
                datumselektovan = true;
                foreach (Appointment appointment in itemsource)
                {
                    DateTime appointmentDate = appointment.Duration.StartTime.Date;
                   
                    if ((myDateStart <= appointmentDate) && (myDateEnd >= appointmentDate))
                    {
                        newdateitemsource.Add(appointment);
                    }
                }

            }
                if (vremeselektovano && !datumselektovan)
                {
                    dgDoctorAppointments.ItemsSource = newtimeitemsource;
                    dgDoctorAppointments.DataContext = vm;
                }
                if (!vremeselektovano && datumselektovan)
                {
                    dgDoctorAppointments.ItemsSource = newdateitemsource;
                    dgDoctorAppointments.DataContext = vm;
                }
                if (datumselektovan && vremeselektovano)
                {
                    ObservableCollection<Appointment> intersecteditemsource = new ObservableCollection<Appointment>();
                    foreach (Appointment app1 in newtimeitemsource)
                    {
                        foreach (Appointment app2 in newdateitemsource)
                        {
                            if (app1.Equals(app2))
                            {
                                intersecteditemsource.Add(app2);
                            }
                        }
                    }
                    dgDoctorAppointments.ItemsSource = intersecteditemsource;
                    dgDoctorAppointments.DataContext = vm;
                
                }
        }
        
        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            timepickerstart.Text = "";
            timepickerend.Text = "";
            datepickerstart.Text = "";
            datepickerend.Text = "";
            dgDoctorAppointments.ItemsSource = vm.getAppointmentsForDoctor(doc);
            dgDoctorAppointments.DataContext = vm;
        }
    }
}
