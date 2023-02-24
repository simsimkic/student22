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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for NotificationsPage.xaml
    /// </summary>
    public partial class NotificationsPage : Page
    {
        public class Notificvation
        {
            private string category;

            public  string Category
            {
                get { return category; }
                set { category = value; }
            }
            private string text;

            public  string Text
            {
                get { return text; }
                set { text = value; }
            }


        }

        public static ObservableCollection<Notificvation> noti { get; set; } = new ObservableCollection<Notificvation>();
        public static bool loaded = false;
        public NotificationsPage()
        {
            InitializeComponent();
            this.DataContext = this;
            if(!loaded)
            {
                Notificvation n1 = new Notificvation();
                n1.Category = "Operacije";
                n1.Text = "Operacija zakazana za termin 7.7.2020. pomerena je za termin 9.7.2020.";
                Notificvation n2 = new Notificvation();
                n2.Category = "Operacije";
                n2.Text = "Operacija zakazana za termin 10.7.2020. pomerena je za termin 12.7.2020.";
                Notificvation n3 = new Notificvation();
                n3.Category = "Pregledi";
                n3.Text = "Pregled zakazan za termin 7.7.2020. je upravo otkazan";
                Notificvation n4 = new Notificvation();
                n4.Category = "Ocene";
                n4.Text = "Jedan od pacijenata Vas je upravo ocenio ocenom 10";
                Notificvation n5 = new Notificvation();
                n5.Category = "Ocene";
                n5.Text = "Jedan od pacijenata Vas je upravo ocenio ocenom 9";
                Notificvation n6 = new Notificvation();
                n6.Category = "Ocene";
                n6.Text = "Jedan od pacijenata Vas je upravo ocenio ocenom 10";
                noti.Add(n1);
                noti.Add(n5);
                noti.Add(n2);
                noti.Add(n4);
                noti.Add(n3);
                noti.Add(n6);
                loaded = true;
            }
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

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }
    }
}
