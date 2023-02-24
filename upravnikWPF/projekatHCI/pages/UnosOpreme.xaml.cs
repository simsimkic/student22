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
    /// Interaction logic for UnosOpreme.xaml
    /// </summary>
    public partial class UnosOpreme : Window
    {
        public static string myValue = String.Empty;

        public static int number=0;

        

        public UnosOpreme()
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
            if (txtSomeBox2.Text == "")
            {
                number = 0;
            }
            else
            {   try
                {
                    number = Int32.Parse(txtSomeBox2.Text);
                    if (number <= 5000)
                    {
                        if (myValue != "")
                        {
                            EvidentiranjeOpreme.Opreme.Add(new Model.Oprema() { Ime = myValue, Kolicina = number });
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mozete uneti najvise 5000 komada!");
                    }
                }
                catch(OverflowException o)
                {
                    MessageBox.Show("Neispravan unos!");
                }
                catch (FormatException f)
                {
                    MessageBox.Show("Neispravan format podatka!");
                }
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
        
        private void txtSomeBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        { 
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(txtSomeBox2.Text))
            {
                MessageBox.Show("Morate uneti samo brojeve !");
            }
            

        }
    }
}
