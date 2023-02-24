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

namespace projekatHCI.pages
{
    /// <summary>
    /// Interaction logic for Renoviranje.xaml
    /// </summary>
    public partial class Renoviranje : Window
    {
        public static string datum;

        public static string datum2;
        public static int deoPrvi;
        public static int deoDrugi;
        public static int deoTreci;
        public static int deo1I;
        public static int deo2I;
        public static int deo3I;

        public static DateTime? picker2=null;
        public static DateTime? picker1=null;

        public static string comboSelection;

        public Renoviranje()
        {
            InitializeComponent();
        }
        private void image2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Upravnik();
            s.Show();
        }

        private void image3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var s = new Meni();
            s.Show();
        }

        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (Window item in App.Current.Windows)
            {
                if (item != this)
                    item.Close();
            }
            var s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            comboSelection = combo.Text;
            //datum
            //datum2
            // RenovacijaSoba.Renoviranja.Add(new Model.Renoviranje() {Ime=comboSelection, PocetniD=datum, KrajnjiD=datum2 });
            Console.WriteLine("*****" + comboSelection);

            if (picker2 != null && picker1 != null)
            {
                //RenovacijaSoba.Renoviranja.Add(new Model.Renoviranje() { Ime = comboSelection, PocetniD = datum, KrajnjiD = datum2 });
                var s = new RenovacijaSoba();
                RenovacijaSoba.Renoviranja.Add(new Model.Renoviranje() { Ime = comboSelection, PocetniD = datum, KrajnjiD = datum2 });
                s.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            picker1 = picker.SelectedDate;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;

            Console.WriteLine(date);
            if (date == null)
            {
                // ... A null object.
                datum = "No date";
            }
            else
            {
                // ... No need to display the time.
                datum = date.Value.ToShortDateString();
                string[] delovi = datum.Split('.');
                string deoPrvi1 = delovi[0];
                string deoDrugi1 = delovi[1];
                string deoTreci1 = delovi[2];

                deoPrvi = Int32.Parse(deoPrvi1);
                deoDrugi = Int32.Parse(deoDrugi1);
                deoTreci = Int32.Parse(deoTreci1);

                if (picker2 != null)
                {
                    if (deo3I < deoTreci)
                    {
                        MessageBox.Show("Ne mozete uneti datum koji je nakon odabranog!");


                    }
                    else if (deo3I == deoTreci)
                    {
                        if (deo2I < deoDrugi)
                        {
                            MessageBox.Show("Ne mozete uneti datum koji je nakon odabranog!");
                            picker.SelectedDate = null;
                            picker1 = null;

                        }
                        else if (deo2I == deoDrugi)
                        {
                            if (deo1I < deoPrvi)
                            {
                                MessageBox.Show("Ne mozete uneti datum koji je nakon odabranog!");
                                picker.SelectedDate = null;
                                picker1 = null;
                            }
                            else if (deo1I == deoPrvi)
                            {
                                MessageBox.Show("Morate odabrati vremenski interval u razmaku od jedan dan najmanje!");
                                picker.SelectedDate = null;
                                picker1 = null;
                            }
                        }
                    }
                }

            }
        }

        private void DatePicker_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            picker2 = picker.SelectedDate;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;


            if (date == null)
            {
                // ... A null object.
                datum2 = "No date";


            }
            else
            {
                // ... No need to display the time.
                datum2 = date.Value.ToShortDateString();
                Console.WriteLine(" DATUMMMMM" + datum2);
                //20.6.2020. -datum 2
                string[] delovi = datum2.Split('.');
                string deo1 = delovi[0];
                string deo2 = delovi[1];
                string deo3 = delovi[2];
                Console.WriteLine(" DATUMMMMM" + deo1 + " " + deo2 + " " + deo3
                    );
                deo1I = Int32.Parse(deo1);
                deo2I = Int32.Parse(deo2);
                deo3I = Int32.Parse(deo3);

                if (picker1 != null)
                {
                    if (deo3I < deoTreci)
                    {
                        MessageBox.Show("Ne mozete uneti datum koji prethodi odabranom!");


                    }
                    else if (deo3I == deoTreci)
                    {
                        if (deo2I < deoDrugi)
                        {
                            MessageBox.Show("Ne mozete uneti datum koji prethodi odabranom!");
                            picker.SelectedDate = null;
                            picker2 = null;

                        }
                        else if (deo2I == deoDrugi)
                        {
                            if (deo1I < deoPrvi)
                            {
                                MessageBox.Show("Ne mozete uneti datum koji prethodi odabranom!");
                                picker.SelectedDate = null;
                                picker2 = null;
                            }
                            else if (deo1I == deoPrvi)
                            {
                                MessageBox.Show("Morate odabrati vremenski interval u razmaku od jedan dan najmanje!");
                                picker.SelectedDate = null;
                                picker2 = null;
                            }
                        }
                    }
                }

            }

        }
    }
}
