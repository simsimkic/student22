using Controller;
using lekar_wpf.Model;
using Model.Doctor;
using ProjekatKlinika.Controller;
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
    /// Interaction logic for BlogPage.xaml
    /// </summary>
    public partial class BlogPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<Article> articles {get; set;}
        public static ObservableCollection<Article> articlesByCategory { get; set; }
        public static ObservableCollection<ArticleCategory> Categories { get; set; }
        public static ArticleController articleController { get; set; }
        public static ArticleCategoryController articleCategoryController { get; set; }

        public BlogPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            articleController = app.articleController;
            articleCategoryController = app.articleCategoryController;

            articles = new ObservableCollection<Article>(articleController.GetAll().ToList());
            articlesByCategory = new ObservableCollection<Article>(articleController.GetAll().ToList());
            Categories = new ObservableCollection<ArticleCategory>(articleCategoryController.GetAll().ToList());

            OnPropertyChanged("articlesByCategory");
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void writeArticle(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new WriteArticlePage());
        }

        private void viewNotifications(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NotificationsPage());
        }

        private void manageCategories(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ArticleCategoriesPage());
        }

        private void showArticlesByCategory(object sender, RoutedEventArgs e)
        {
            articlesByCategory = new ObservableCollection<Article>(articleController.GetByCategory(Categories[comboBox.SelectedIndex]).ToList());
            OnPropertyChanged("articlesByCategory");
        }
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
