using Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static lekar_wpf.View.DrugsPage;

namespace lekar_wpf.View
{
    /// <summary>
    /// Interaction logic for SearchDrugsDialog.xaml
    /// </summary>
    public partial class SearchDrugsDialog : Window, INotifyPropertyChanged
    {
        public bool isButtonEnabled { get; set; } = false;
        public static ObservableCollection<Drug> drugs { get; set; }
        public SearchDrugsDialog()
        {
            InitializeComponent();
            this.DataContext = this;
            ingridients = new List<string>();
        }

        private List<string> ingridients;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public List<string> Ingridients
        {
            get { return ingridients; }
        }

        private void addIngridient(object sender, RoutedEventArgs e)
        {
            ingridients.Add(sastojci.Text);
            datagrid.Items.Refresh();
            sastojci.Text = "";
        }

        private void removeIngridient(object sender, RoutedEventArgs e)
        {
            int selectedRow = datagrid.SelectedIndex;
            if (selectedRow >= 0)
            {
                ingridients.RemoveAt(selectedRow);
                datagrid.Items.Refresh();
            }
        }

        private void beginSearch(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^ *$");
            if(regex.IsMatch(name.Text) && regex.IsMatch(manufacturer.Text) && ingridients.Count == 0)
            {
                if(DrugsPage.lastApproved)
                {
                    SearchedDrugs = Drugs;
                }
                else
                {
                    SearchedDrugs = DrugsForApproval;
                }
                this.Close();
                return;
            }
            drugs = new ObservableCollection<Drug>();
            foreach (Drug d in SearchedDrugs)
            {
                drugs.Add(d);
            }
            if (name.Text != "")
            {
                foreach (Drug d in SearchedDrugs)
                {
                    if(!d.Name.Equals(name.Text))
                    {
                        drugs.Remove(d);
                    }
                }
            }
            if (manufacturer.Text != "")
            {
                foreach (Drug d in SearchedDrugs)
                {
                    if (!d.Manufacturer.Equals(manufacturer.Text))
                    {
                        drugs.Remove(d);
                    }
                }
            }
            if (ingridients.Count > 0)
            {
                foreach(string ing in ingridients)
                {
                    foreach (Drug d in SearchedDrugs)
                    {
                        bool hasIng = false;
                        foreach(string ing1 in d.Ingredients)
                        {
                            if(ing1.Equals(ing))
                            {
                                hasIng = true;
                                break;
                            }
                        }
                        if(ing.Equals(""))
                        {
                            hasIng = true;
                        }
                        if(!hasIng)
                        {
                            drugs.Remove(d);
                        }
                    }
                }
            }
            DrugsPage.SearchedDrugs = drugs;
            this.Close();
        }

        private void checkButton(object sender, RoutedEventArgs e)
        {
            if(sastojci.Text == null || sastojci.Text.Equals(""))
            {
                isButtonEnabled = false;
                OnPropertyChanged("isButtonEnabled");
                return;
            }else
            {
                foreach (string i in ingridients)
                {
                    if (i.Equals(sastojci.Text))
                    {
                        isButtonEnabled = false;
                        OnPropertyChanged("isButtonEnabled");
                        return;
                    }
                }
                isButtonEnabled = true;
                OnPropertyChanged("isButtonEnabled");
            }
        }
    }
}
