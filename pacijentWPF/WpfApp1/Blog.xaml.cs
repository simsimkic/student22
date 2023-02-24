using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;

namespace HCI
{
    /// <summary>
    /// Interaction logic for Blog.xaml
    /// </summary>
    public partial class Blog : Window
    {
        public int colNum = 0;
        public ObservableCollection<Objava> Objave
        {
            get;
            set;
        }

        public Blog()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                nazad.Content = "NAZAD";
            }
            else
            {
                nazad.Content = "BACK";
            }
            nazad.Focus();
            this.DataContext = this;
            Objave = new ObservableCollection<Objava>();
            Objave.Add(new Objava("Objava1", "Ime Prezime"));
            Objave.Add(new Objava("Objava2", "Ime Prezime"));


        }
        public void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 2)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGridBlog_Selected(object sender, RoutedEventArgs e)
        {
            DetaljnoObavestenje dod = new DetaljnoObavestenje();
            nazad.Focus();
            dod.Show();
            
        }

        private void KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                DetaljnoObavestenje dod = new DetaljnoObavestenje();
                DataGridBlog.UnselectAll();
                nazad.Focus();
                dod.Show();
            }
        }
    }
}
