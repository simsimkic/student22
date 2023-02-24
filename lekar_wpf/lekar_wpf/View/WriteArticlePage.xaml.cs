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
    /// Interaction logic for WriteArticlePage.xaml
    /// </summary>
    public partial class WriteArticlePage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<ArticleCategory> Categories { get; set; }
        public bool isButtonEnabled { get; set; } = false;
        public static ArticleController articleController { get; set; }
        public static ArticleCategoryController articleCategoryController { get; set; }
        public WriteArticlePage()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;

            articleController = app.articleController;
            articleCategoryController = app.articleCategoryController;
            Categories = new ObservableCollection<ArticleCategory>(articleCategoryController.GetAll().ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BlogPage());
        }
        private void check(object sender, RoutedEventArgs e)
        {
            bool valid = true;
            if (heading.Text.Equals("") || heading.Text.Length > 100)
            {
                heading.BorderBrush = System.Windows.Media.Brushes.Red;
                heading.BorderThickness = new Thickness(1);
                valid = false;
            }
            else
            {
                heading.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            if (text.Text.Equals("") || text.Text.Length > 2000)
            {
                text.BorderBrush = System.Windows.Media.Brushes.Red;
                text.BorderThickness = new Thickness(1);
                valid = false;
            }
            else
            {
                text.BorderBrush = System.Windows.Media.Brushes.LightBlue;
            }
            isButtonEnabled = valid;
            OnPropertyChanged("isButtonEnabled");
        }
        private void write(object sender, RoutedEventArgs e)
        {
            Article a = new Article();
            a.Author = LoginPage.signedIn;
            if (comboBox.SelectedIndex >= 0)
                a.Category = Categories[comboBox.SelectedIndex];
            else
                a.Category = Categories[0];
            a.Published = DateTime.Now;
            a.Headline = new ProjekatKlinika.Model.Doctor.Util.ArticleHeadline(heading.Text);
            a.Text = new ProjekatKlinika.Model.Doctor.Util.ArticleText(text.Text);
            articleController.Create(a);
            this.NavigationService.Navigate(new BlogPage());
        }

        private void addCategory(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCategoryDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
            Categories = new ObservableCollection<ArticleCategory>(articleCategoryController.GetAll().ToList());
            OnPropertyChanged("Categories");

        }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
