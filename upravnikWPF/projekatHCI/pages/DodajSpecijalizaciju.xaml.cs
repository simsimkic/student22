using System;
using System.Collections.Generic;
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

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for DodajSpecijalizaciju.xaml
    /// </summary>
    public partial class DodajSpecijalizaciju : Window
    {
        public static string myValue = String.Empty;

        public DodajSpecijalizaciju()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Save_Data(object sender, RoutedEventArgs e)
        {
            myValue = txtSomeBox.Text;
            if (myValue != "")
            {
                Specijalizacije.Specijalizacijee.Add(new Model.Specijalizacija() { Naziv = myValue });
            }

        }
        private void txtSomeBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(txtSomeBox.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }
    }
}
