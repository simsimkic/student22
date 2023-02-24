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
    /// Interaction logic for ArticleCategoriesPage.xaml
    /// </summary>
    public partial class ArticleCategoriesPage : Page, INotifyPropertyChanged
    {
        public static ObservableCollection<ArticleCategory> Categories { get; set; } = new ObservableCollection<ArticleCategory>();
        public static ArticleCategoryController articleCategoryController { get; set; }
        public ArticleCategoriesPage()
        {
            InitializeComponent();
            this.DataContext = this;
            var app = Application.Current as App;

            articleCategoryController = app.articleCategoryController;
            Categories = new ObservableCollection<ArticleCategory>(articleCategoryController.GetAll().ToList());
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BlogPage());
        }

        private void addCategory(object sender, RoutedEventArgs e)
        {
            var dialog = new AddCategoryDialog();
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
            OnPropertyChanged("Categories");
        }

        private void isUnique(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            if(datagrid.SelectedIndex >= 0)
            {
                if(name.Equals(""))
                {
                    updateButton.IsEnabled = false;
                    deleteButton.IsEnabled = true;
                    return;
                }
                if (BlogPage.Categories[datagrid.SelectedIndex].Name.Equals(name))
                {
                    poruka.Visibility = Visibility.Hidden;
                    updateButton.IsEnabled = false;
                    return;
                }
                foreach (ArticleCategory c in Categories)
                {
                    if (name.ToUpper().Equals(c.Name))
                    {
                        updateButton.IsEnabled = false;
                        if (!BlogPage.Categories[datagrid.SelectedIndex].Name.Equals(name))
                        {
                            poruka.Visibility = Visibility.Visible;
                            return;
                        }
                    }
                }
                poruka.Visibility = Visibility.Hidden;
                updateButton.IsEnabled = true;
            }
            else if (textBox.Text == null || textBox.Text.Equals(""))
            {
                deleteButton.IsEnabled = false;
                updateButton.IsEnabled = false;
            }
        }
        private void update(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            if (name.ToUpper().Equals("SVE KATEGORIJE"))
            {
                return;
            }
            
            ((ArticleCategory)datagrid.SelectedItem).Name.Value = name.ToUpper();
            articleCategoryController.Update((ArticleCategory)datagrid.SelectedItem);
            OnPropertyChanged("Categories");
        }

        private void check(object sender, RoutedEventArgs e)
        {
            if(datagrid.SelectedIndex >= 0)
            {
                if (BlogPage.Categories[datagrid.SelectedIndex].Name.Equals("SVE KATEGORIJE"))
                {
                    deleteButton.IsEnabled = false;
                    updateButton.IsEnabled = false;
                    textBox.IsEnabled = false;
                }
                else
                {
                    deleteButton.IsEnabled = true;
                    updateButton.IsEnabled = true;
                    textBox.IsEnabled = true;
                }
            }
            else if (textBox.Text == null || textBox.Text.Equals(""))
            {
                deleteButton.IsEnabled = false;
                updateButton.IsEnabled = false;
            }
        }

        private void delete(object sender, RoutedEventArgs e)
        {
            string name = textBox.Text;
            if(name.Equals("SVE KATEGORIJE"))
            {
                return;
            }
            foreach (ArticleCategory category in Categories)
            {
                if(category.Name.Value.Equals(name))
                {
                    articleCategoryController.Delete(category);
                    OnPropertyChanged("Categories");
                    return;
                }
            }
            Categories = new ObservableCollection<ArticleCategory>(articleCategoryController.GetAll().ToList());
            OnPropertyChanged("Categories");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            NavigationService.Navigate(new ArticleCategoriesPage());
        }

    }
}
