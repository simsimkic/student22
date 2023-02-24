using lekar_wpf.Model;
using Model.Doctor;
using ProjekatKlinika.Controller;
using ProjekatKlinika.Model.Doctor.Util;
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
    /// Interaction logic for AddCategoryDialog.xaml
    /// </summary>
    public partial class AddCategoryDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public static ArticleCategoryController articleCategoryController { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AddCategoryDialog()
        {
            InitializeComponent();
            this.DataContext = this;

            var app = Application.Current as App;

            articleCategoryController = app.articleCategoryController;
        }

        private void leave(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            ArticleCategory ac = new ArticleCategory();
            ac.Name = new ArticleCategoryName(textBox.Text);
            articleCategoryController.Create(ac);
            this.Close();
        }

        private void validate(object sender, RoutedEventArgs e)
        {
            if(textBox.Text.Equals(""))
            {
                poruka2.Visibility = Visibility.Visible;
                poruka1.Visibility = Visibility.Hidden;
                poruka3.Visibility = Visibility.Hidden;
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            }
            else if(textBox.Text.Length > 50)
            {
                poruka2.Visibility = Visibility.Hidden;
                poruka1.Visibility = Visibility.Visible;
                poruka3.Visibility = Visibility.Hidden;
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
            } else
            {
                bool exists = false;
                /*
                foreach (Category c in BlogPage.Categories)
                {
                    if(c.Name.Equals(textBox.Text.ToUpper()))
                    {
                        exists = true;
                        break;
                    }
                }
                */
                if(exists)
                {
                    poruka2.Visibility = Visibility.Hidden;
                    poruka1.Visibility = Visibility.Hidden;
                    poruka3.Visibility = Visibility.Visible;
                    isButtonEnabled = false;
                    OnPropertyChanged("isButtonEnabled");
                } else
                {
                    poruka2.Visibility = Visibility.Hidden;
                    poruka1.Visibility = Visibility.Hidden;
                    poruka3.Visibility = Visibility.Hidden;
                    isButtonEnabled = true;
                    OnPropertyChanged("isButtonEnabled");
                }
            }
        }
    }
}
