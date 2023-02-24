using Controller;
using Model.Manager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for UnosNoveVrsteLeka.xaml
    /// </summary>
    public partial class UnosNoveVrsteLeka : Window
    {
        public static string myName = String.Empty;

        public static int number = 0;

        private readonly DrugController drugController;


        public UnosNoveVrsteLeka()
        {
            InitializeComponent();
            var app = Application.Current as App;
            drugController = app.drugController;

        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            myName = nazivLeka.Text;

           

            number = Int32.Parse(brojLeka.Text);

            Drug drug = new Drug();
            drug.Name = myName;
            drug.Ingredients.Add(sastavLeka.Text);
            drug.Quantity = number;
            

            drugController.Create(drug);

            var s = new Lekovi();
            s.Show();
            this.Close();

            /*
            if (brojLeka.Text == "")
            {
                number = 0;
            }
            else
            { try
                {
                    number = Int32.Parse(brojLeka.Text);
                    if (number <= 5000)
                    {
                        if (myName != "" && mySastav != "")
                        {
                          //  Lekovi.SviLekovi.Add(new Model.Lek() { Ime = myName, Kolicina = number, Sastav = mySastav });
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
                }catch(FormatException f)
                {
                    MessageBox.Show("Neispravan format podatka!");
                }
            }*/

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nazivLeka_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(nazivLeka.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }

        private void sastavLeka_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            if (regex.IsMatch(sastavLeka.Text))
            {
                MessageBox.Show("Morate uneti samo slova!");
            }
        }

        private void brojLeka_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            if (regex.IsMatch(brojLeka.Text))
            {
                MessageBox.Show("Morate uneti samo brojeve !");
            }
        }
    }
}
