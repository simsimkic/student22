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
    /// Interaction logic for HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        public class Notificvation
        {
            private string category;

            public string Category
            {
                get { return category; }
                set { category = value; }
            }
            private string text;

            public string Text
            {
                get { return text; }
                set { text = value; }
            }


        }

        public static ObservableCollection<Notificvation> noti { get; set; } = new ObservableCollection<Notificvation>();
        public static bool loaded = false;
        public HelpPage()
        {
            InitializeComponent();
            this.DataContext = this;
            if (!loaded)
            {
                Notificvation n1 = new Notificvation();
                n1.Category = "How do I create a product with you?";
                n1.Text = "If you have an idea contact us by our online form, e-mail or phone. We'll meet and talk it over. Just be sure to prepare as much info about your idea as possible, it will smoothen the meeting and benefit further cooperation. If you don't know how to get around to it, go ahead and read our blog entry on how to write a project brief.";
                Notificvation n2 = new Notificvation();
                n2.Category = "Should I create a mobile or a web app?";
                n2.Text = "Both have their benefits and flaws. Mobile apps are surely more expensive but can provide you with many more data collecting, monetisation capabilities than web applications. Progressive Web Apps are a good compromise between a mobile and web app — you can  learn more about PWA on our blog. But remember that sooner or later you may need both mobile and web app and when that moment comes we are here for you.";
                Notificvation n3 = new Notificvation();
                n3.Category = "What do I need to know before contacting you?";
                n3.Text = "Well, the most important thing to know is what do you want to accomplish. Why do I need this software? What for? What should it do? Having a clear vision in mind is crucial when ordering a software application. You don't want to spend many months developing it with us without being sure what you need. If you have no experience in app development feel free to read our blog entry on that topic. We'll also be glad to help you get started, building projects from scratch is nothing new for us.";
                Notificvation n4 = new Notificvation();
                n4.Category = "How do I create a product with you?";
                n4.Text = "If you have an idea contact us by our online form, e-mail or phone. We'll meet and talk it over. Just be sure to prepare as much info about your idea as possible, it will smoothen the meeting and benefit further cooperation. If you don't know how to get around to it, go ahead and read our blog entry on how to write a project brief.";
                Notificvation n5 = new Notificvation();
                n5.Category = "Should I create a mobile or a web app?";
                n5.Text = "Both have their benefits and flaws. Mobile apps are surely more expensive but can provide you with many more data collecting, monetisation capabilities than web applications. Progressive Web Apps are a good compromise between a mobile and web app — you can  learn more about PWA on our blog. But remember that sooner or later you may need both mobile and web app and when that moment comes we are here for you.";
                Notificvation n6 = new Notificvation();
                n6.Category = "What do I need to know before contacting you?";
                n6.Text = "Well, the most important thing to know is what do you want to accomplish. Why do I need this software? What for? What should it do? Having a clear vision in mind is crucial when ordering a software application. You don't want to spend many months developing it with us without being sure what you need. If you have no experience in app development feel free to read our blog entry on that topic. We'll also be glad to help you get started, building projects from scratch is nothing new for us.";
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

        private void rateSoftware(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RateSoftwarePage());
        }
    }
}
