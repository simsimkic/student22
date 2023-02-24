using Model.Manager;
using Model.Users;
using Room = Model.Manager.Room;
using Guest = Model.Users.Patient;
using Patient = Model.Users.Patient;
using ViewModel = Sekretar_WPF_Project.VM.ViewModel;
using Appointment = Model.Doctor.Appointment;
using Sekretar_WPF_Project.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Sekretar_WPF_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = ViewModel.getInstance();
        ObservableCollection<Appointment> currentAppointmentItemSource = new ObservableCollection<Appointment>(); //da mogu da se kombinuju search i filteri
        
        public MainWindow()
        {
            InitializeComponent();           
            RoomComboBox.DataContext = vm;
            dgGuests.ItemsSource = vm.Guests;
            dgGuests.DataContext = vm;
            dgPatients.ItemsSource = vm.Patients;
            dgPatients.DataContext = vm;
            dgDoctors.ItemsSource = vm.Doctors;
            dgDoctors.DataContext = vm;
            dgAppointments.ItemsSource = vm.Appointments;
            dgAppointments.DataContext = vm;
            Room room = (Room)RoomComboBox.SelectedItem;
            dgRoomSchedule.ItemsSource = vm.getAppointmentsForRoom(room);
            dgRoomSchedule.DataContext = vm;
            currentAppointmentItemSource = vm.Appointments;
        }

        private void AddGuestClick(object sender, RoutedEventArgs e)
        {
            AddGuestWindow addGuestWindow = new AddGuestWindow();
            addGuestWindow.Show();
        }


        private void LinkToPatientClick(object sender, RoutedEventArgs e)
        {
            Guest guest = (Guest)dgGuests.SelectedItem;
            if (guest == null)
            {
                return;
            }
            else
            {
                LinkToPatientWindow linkToPatientWindow = new LinkToPatientWindow(guest);
                linkToPatientWindow.Show();
            }
            
        }

        private void SeeGuestAppointmentsClick(object sender, RoutedEventArgs e)
        {
            Guest guest = (Guest)dgGuests.SelectedItem;
            if (guest == null)
                {
                return;
                } else {
                        SeeGuestAppointmentsWindow seeGuestAppointmentsWindow = new SeeGuestAppointmentsWindow(guest);
                        seeGuestAppointmentsWindow.Show();
                        }
        }

        private void AddPatientClick(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.Show();
        }

        private void SeePatientAppointmentsClick(object sender, RoutedEventArgs e)
        {
            Patient patient = (Patient)dgPatients.SelectedItem;
            if (patient == null)
            {
                return;
            }
            else
            {
                SeePatientAppointmentsWindow seePatientAppointmentsWindow = new SeePatientAppointmentsWindow(patient);
                seePatientAppointmentsWindow.Show();
            }
        }

        private void SeeDoctorAppointmentsClick(object sender, RoutedEventArgs e)
        {
            Doctor doctor = (Doctor)dgDoctors.SelectedItem;
            if (doctor == null)
            {
                return;
            }
            else
            {
                SeeDoctorAppointmentsWindow seeDoctorAppointmentsWindow = new SeeDoctorAppointmentsWindow(doctor);
                seeDoctorAppointmentsWindow.Show();
            }
        }

        private void ScheduleAppointmentClick(object sender, RoutedEventArgs e)
        {
            ScheduleAppointmentWindow scheduleAppointmentWindow = new ScheduleAppointmentWindow(this);
            scheduleAppointmentWindow.Show();
        }

        private void RecheduleAppointmentClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment = null;
            if (Tabs1.SelectedIndex == 3)
            {
                appointment = (Appointment)dgAppointments.SelectedItem;
            } else if (Tabs1.SelectedIndex == 4)
            {
                appointment = (Appointment)dgRoomSchedule.SelectedItem;
            }

            if (appointment == null)
                {
                    return;
                }
            else
                {
                    RescheduleAppointmentWindow rescheduleAppointmentWindow = new RescheduleAppointmentWindow(appointment, this);
                    rescheduleAppointmentWindow.Show();
                }
            
        }

        private void CancelAppointmentClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment;
            if (Tabs1.SelectedIndex == 3)
            {
                appointment = (Appointment)dgAppointments.SelectedItem;
            }
            else
            {
                appointment = (Appointment)dgRoomSchedule.SelectedItem;
            }
            if (appointment == null)
            {
                return;
            }
            else
            {
                CancelAppointmentWindow cancelAppointmentWindow = new CancelAppointmentWindow(appointment,this);
                cancelAppointmentWindow.Show();
            }
        }

        private void MenuItemFileNewClick(object sender, RoutedEventArgs e)
        {
            if (Tabs1.SelectedIndex == 0)
            {
                AddGuestClick(sender,e);
            } else if(Tabs1.SelectedIndex == 1)
            {
                AddPatientClick(sender, e);
            } else if (Tabs1.SelectedIndex == 2)
            {
                MessageBox.Show("Insufficient privileges (Add Doctor)");
            } else if (Tabs1.SelectedIndex == 3)
            {
                ScheduleAppointmentClick(sender, e);  // appointments tab
            } else
            {
                ScheduleAppointmentClick(sender, e); // room schedule tab
            }

        }

        private void MenuItemFileEditClick(object sender, RoutedEventArgs e)
        {
            if (Tabs1.SelectedIndex == 0)
            {
                MessageBox.Show("Insufficient privileges (Edit Guest)");
            }
            else if (Tabs1.SelectedIndex == 1)
            {
                MessageBox.Show("Insufficient privileges (Edit Patient)");
            }
            else if (Tabs1.SelectedIndex == 2)
            {
                MessageBox.Show("Insufficient privileges (Edit Doctor)");
            }
            else if (Tabs1.SelectedIndex == 3)
            {
                RecheduleAppointmentClick(sender, e);  // appointments tab
            }
            else
            {
                RecheduleAppointmentClick(sender, e); // room schedule tab
            }
        }

        private void MenuItemFileDeleteClick(object sender, RoutedEventArgs e)
        {
            Appointment appointment1 = (Appointment)dgAppointments.SelectedItem;
            if (appointment1 == null && Tabs1.SelectedIndex == 3)
            {
                MessageBox.Show("You must first select an appointment.");
                return;
            }
            else if(Tabs1.SelectedIndex == 3) // appointments tab
            {
                CancelAppointmentWindow cancelAppointmentWindow = new CancelAppointmentWindow(appointment1,this);
                cancelAppointmentWindow.Show();
                return;
            }
            Appointment appointment2 = (Appointment)dgRoomSchedule.SelectedItem;
            if (appointment2 == null && Tabs1.SelectedIndex == 4)
            {
                MessageBox.Show("You must first select an appointment.");
                return;
            }
            else if (Tabs1.SelectedIndex == 4) // room schedule tab
            {
                CancelAppointmentWindow cancelAppointmentWindow = new CancelAppointmentWindow(appointment2,this);
                cancelAppointmentWindow.Show();
                return;
            }
            MessageBox.Show("Insufficient privileges (Can only delete/cancel appointment)");
            return;

        }

        private void TutorialMenuItem_Click(object sender, RoutedEventArgs e)
        {
            VideoTutorialWindow videoTutorialWindow = new VideoTutorialWindow();
            videoTutorialWindow.Show();
        }
        private void MenuItemFileExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RadioButtonLight_Checked(object sender, RoutedEventArgs e)
        {
            this.Resources["Theme"] = 0;

            Tabs1.Background = Brushes.GhostWhite;
            Stack1.Background = Brushes.DodgerBlue;
            this.Background = Brushes.White;
            label1.Foreground = Brushes.Black;
            label2.Foreground = Brushes.Black;
            label3.Foreground = Brushes.Black;
            label4.Foreground = Brushes.Black;
            label5.Foreground = Brushes.Black;
            dgGuests.Background = Brushes.White;
            dgPatients.Background = Brushes.White;
            dgDoctors.Background = Brushes.White;
            dgAppointments.Background = Brushes.White;
            dgRoomSchedule.Background = Brushes.White;
            GuestTab.Background = Brushes.GhostWhite;
            PatientTab.Background = Brushes.GhostWhite;
            DoctorTab.Background = Brushes.GhostWhite;
            AppointmentTab.Background = Brushes.GhostWhite;
            RoomScheduleTab.Background = Brushes.GhostWhite;
            Rect1.Fill = Brushes.LightBlue;
            Rect2.Fill = Brushes.LightBlue;
            ClinicLabel.Foreground = Brushes.Black;
            ClinicLabel.Background = Brushes.White;


        }
        private void RadioButtonDark_Checked(object sender, RoutedEventArgs e)
        {
            this.Resources["Theme"] = 1;
            Tabs1.Background = Brushes.Black;
            Stack1.Background = Brushes.MidnightBlue;
            this.Background = Brushes.Black;
            label1.Foreground = Brushes.White;
            label2.Foreground = Brushes.White;
            label3.Foreground = Brushes.White;
            label4.Foreground = Brushes.White;
            label5.Foreground = Brushes.White;
            dgGuests.Background = Brushes.DarkGray;
            dgPatients.Background = Brushes.DarkGray;
            dgDoctors.Background = Brushes.DarkGray;
            dgAppointments.Background = Brushes.DarkGray;
            dgRoomSchedule.Background = Brushes.DarkGray;
            GuestTab.Background = Brushes.DarkGray;
            PatientTab.Background = Brushes.DarkGray;
            DoctorTab.Background = Brushes.DarkGray;
            AppointmentTab.Background = Brushes.DarkGray;
            RoomScheduleTab.Background = Brushes.DarkGray;
            Rect1.Fill = Brushes.SteelBlue;
            Rect2.Fill = Brushes.SteelBlue;
            ClinicLabel.Foreground = Brushes.White;
            ClinicLabel.Background = Brushes.MidnightBlue;


        }

        private void RoomComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            timepickerrsstart.Text = "";
            timepickerrsend.Text = "";
            datepickerrsstart.Text = "";
            datepickerrsend.Text = "";
            refreshRoomSchedule();
        }

        public void refreshRoomSchedule()
        {
            Room room = (Room)RoomComboBox.SelectedItem;
            dgRoomSchedule.ItemsSource = vm.getAppointmentsForRoom(room);
            dgRoomSchedule.DataContext = vm;
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
            ObservableCollection<Appointment> itemsource = vm.Appointments;
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
                    int appointmenttimestart = appointment.Duration.StartTime.Hour * 100 + appointment.Duration.StartTime.Minute; //

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
                currentAppointmentItemSource = newtimeitemsource; //kombinacija search i filtera
                dgAppointments.ItemsSource = newtimeitemsource;
                dgAppointments.DataContext = vm;
            }
            if (!vremeselektovano && datumselektovan)
            {
                currentAppointmentItemSource = newdateitemsource; //kombinacija search i filtera
                dgAppointments.ItemsSource = newdateitemsource;
                dgAppointments.DataContext = vm;
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
                currentAppointmentItemSource = intersecteditemsource; //kombinacija search i filtera
                dgAppointments.ItemsSource = intersecteditemsource;
                dgAppointments.DataContext = vm;

            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            timepickerstart.Text = "";
            timepickerend.Text = "";
            datepickerstart.Text = "";
            datepickerend.Text = "";
            appointmenttextbox.Text = "";
            dgAppointments.ItemsSource = vm.Appointments;
            dgAppointments.DataContext = vm;
        }

        private void Buttonrs_Apply(object sender, RoutedEventArgs e) // room schedule /////////////////////////
        {
            Room room = (Room)RoomComboBox.SelectedItem;
            ObservableCollection<Appointment> itemsourceforroom = vm.getAppointmentsForRoom(room); // intersect

            string timestartstring = timepickerrsstart.Text;
            string timeendstring = timepickerrsend.Text;
            string datestartstring = datepickerrsstart.Text;
            string dateendstring = datepickerrsend.Text;

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
            ObservableCollection<Appointment> itemsource = vm.Appointments;
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
                    int appointmenttimestart = appointment.Duration.StartTime.Hour * 100 + appointment.Duration.StartTime.Minute; //

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
                ObservableCollection<Appointment> intersecteditemsource1 = new ObservableCollection<Appointment>();
                foreach (Appointment app1 in newtimeitemsource)
                {
                    foreach (Appointment app2 in itemsourceforroom)
                    {
                        if (app1.Equals(app2))
                        {
                            intersecteditemsource1.Add(app2);
                            MessageBox.Show(intersecteditemsource1.Count.ToString());
                        }
                    }
                    dgRoomSchedule.ItemsSource = intersecteditemsource1;
                    dgRoomSchedule.DataContext = vm;
                }
            }
            if (!vremeselektovano && datumselektovan)
            {
                ObservableCollection<Appointment> intersecteditemsource2 = new ObservableCollection<Appointment>();
                foreach (Appointment app1 in newdateitemsource)
                {
                    foreach (Appointment app2 in itemsourceforroom)
                    {
                        if(app1.Equals(app2))
                        {
                            intersecteditemsource2.Add(app2);
                        }
                    }
                    dgRoomSchedule.ItemsSource = intersecteditemsource2;
                    dgRoomSchedule.DataContext = vm;
                }
            }
            if (datumselektovan && vremeselektovano)
            {
                ObservableCollection<Appointment> intersecteditemsource3 = new ObservableCollection<Appointment>();
                foreach (Appointment app1 in newtimeitemsource)
                {
                    foreach (Appointment app2 in newdateitemsource)
                    {
                        foreach (Appointment app3 in itemsourceforroom)
                        {
                            if (app1.Equals(app2).Equals(app3))
                            {
                                intersecteditemsource3.Add(app2);
                            }
                        }
                    }
                }
                dgRoomSchedule.ItemsSource = intersecteditemsource3;
                dgRoomSchedule.DataContext = vm;

            }
        }

        private void Buttonrs_Reset(object sender, RoutedEventArgs e)
        {
            {
                timepickerrsstart.Text = "";
                timepickerrsend.Text = "";
                datepickerrsstart.Text = "";
                datepickerrsend.Text = "";
                refreshRoomSchedule();
            }
        }
        private void GuestTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchstring = guesttextbox.Text;
            if(searchstring.Equals("") ||  searchstring==null)
            {
                dgGuests.ItemsSource = vm.Guests;
                dgGuests.DataContext = vm;
            } else
            {
                ObservableCollection < Guest > newitemsource = new ObservableCollection<Guest>();
                foreach(Guest guest in vm.Guests)
                {

                    if (guest.name == null || guest.surname == null)
                    {
                        continue;
                    } else {
                        if (guest.IdNumber.ToString().Contains(searchstring) || guest.name.ToString().ToLower().Contains(searchstring.ToLower()) || guest.surname.ToString().ToLower().Contains(searchstring.ToLower()))
                        {
                            newitemsource.Add(guest);
                        }
                    }
                }
                dgGuests.ItemsSource = newitemsource;
                dgGuests.DataContext = vm;
            }
        }
        private void PatientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchstring = patienttextbox.Text;
            if (searchstring.Equals("") || searchstring == null)
            {
                dgPatients.ItemsSource = vm.Patients;
                dgPatients.DataContext = vm;
            }
            else
            {
                ObservableCollection<Patient> newitemsource = new ObservableCollection<Patient>();
                foreach (Patient patient in vm.Patients)
                {
                    if (patient.IdNumber == null || patient.name == null || patient.surname == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (patient.IdNumber.ToString().Contains(searchstring) || patient.name.ToString().ToLower().Contains(searchstring.ToLower()) || patient.surname.ToString().ToLower().Contains(searchstring.ToLower()))
                        {
                            newitemsource.Add(patient);
                        }
                    }
                }
                dgPatients.ItemsSource = newitemsource;
                dgPatients.DataContext = vm;
            }
        }

        private void DoctorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchstring = doctortextbox.Text;
            if (searchstring.Equals("") || searchstring == null)
            {
                dgDoctors.ItemsSource = vm.Doctors;
                dgDoctors.DataContext = vm;
            }
            else
            {
                ObservableCollection<Doctor> newitemsource = new ObservableCollection<Doctor>();
                foreach (Doctor doctor in vm.Doctors)
                {
                    if (doctor.LicenseNumber == null || doctor.name == null || doctor.surname == null)
                    {
                        continue;
                    }
                    else
                    {
                        if (doctor.LicenseNumber.ToString().Contains(searchstring) || doctor.name.ToString().ToLower().Contains(searchstring.ToLower()) || doctor.surname.ToString().ToLower().Contains(searchstring.ToLower()))
                        {
                            newitemsource.Add(doctor);
                        }
                    }
                }
                dgDoctors.ItemsSource = newitemsource;
                dgDoctors.DataContext = vm;
            }

        }

        private void AppointmentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchstring = appointmenttextbox.Text;
            if (searchstring.Equals("") || searchstring == null)
            {
                currentAppointmentItemSource = vm.Appointments;
                dgAppointments.ItemsSource = vm.Appointments;
                dgAppointments.DataContext = vm;
            }
            else
            {
                ObservableCollection<Appointment> newitemsource = new ObservableCollection<Appointment>();
                foreach (Appointment app in currentAppointmentItemSource)
                {
                    foreach(Doctor doc in vm.Doctors)
                    {
                        if (app.Doctor != null)
                        {
                            if (app.Doctor.LicenseNumber == null || app.Doctor.name == null || app.Doctor.surname == null || app.Patient.name == null || app.Patient.surname == null)
                            {
                                continue;
                            }
                            else
                            {
                                if (app.Doctor.name.Contains(doc.name))
                                {
                                    if (app.Patient.IdNumber.ToString().Contains(searchstring) || doc.name.ToString().ToLower().Contains(searchstring.ToLower()) || doc.surname.ToString().ToLower().Contains(searchstring.ToLower()))
                                    {
                                        newitemsource.Add(app);
                                    }
                                    break;
                                }
                            }
                        }
                            
                    }

                }
                dgAppointments.ItemsSource = newitemsource;
                dgAppointments.DataContext = vm;
            }

        }

        private void ReviewSoftware_Click(object sender, RoutedEventArgs e)
        {
            ReviewSoftwareWindow review = new ReviewSoftwareWindow();
            review.Show();
        }

        private void Blogs_Click(object sender, RoutedEventArgs e)
        {
            SeeBlogsWindow blogWindow = new SeeBlogsWindow();
            blogWindow.Show();
        }
    }
}

