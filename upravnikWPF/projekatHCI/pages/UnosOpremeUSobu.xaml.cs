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
    /// Interaction logic for UnosOpremeUSobu.xaml
    /// </summary>
    public partial class UnosOpremeUSobu : Window
    {
        public static string imeIzBoxa=String.Empty;
        public static int kolicinaIzBoxa;

        public UnosOpremeUSobu()
        {
            InitializeComponent();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            imeIzBoxa =naziv.Text;
            

            if (kolicina.Text == "")
            {
                kolicinaIzBoxa = 0;
            }
            else
            {
                try
                {
                    kolicinaIzBoxa = Int32.Parse(kolicina.Text);
                    if (kolicinaIzBoxa <= 5000 )
                    {
                        if (imeIzBoxa != "")
                        {
                            Soba2.OpremeLista.Add(new Model.Oprema() { Ime = imeIzBoxa, Kolicina = kolicinaIzBoxa });
                        }
                        }
                    else
                    {
                        MessageBox.Show("Mozete uneti najvise 5000 komada!");
                    }
                }
                catch (OverflowException o)
                {
                    MessageBox.Show("Neispravan unos!");
                }
                catch (FormatException f)
                {
                    MessageBox.Show("Neispravan format podatka!");
                }
            }


            
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void naziv_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(naziv.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }

        private void kolicina_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(kolicina.Text))
            {
                MessageBox.Show("Morate uneti samo brojeve !");
            }

        }
    }
}
