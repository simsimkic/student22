using Controller;
using Model.Manager;
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
    /// Interaction logic for UnosNoveSobe.xaml
    /// </summary>
    public partial class UnosNoveSobe : Window
    {
        private readonly RoomController roomController;
        public static int imeIzBoxa;

        public UnosNoveSobe()
        {
            InitializeComponent();
            var app = Application.Current as App;
           roomController = app.roomController;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            imeIzBoxa =Int32.Parse(ime.Text);

            Room room = new Room();
            room.RoomNumber = imeIzBoxa;
            roomController.Create(room);

            var s = new Sobe();
            s.Show();
            this.Close();

            /*   if (imeIzBoxa != "")
               {
                   Sobe.SobeLista.Add(new Model.Soba() { Ime = imeIzBoxa });
               }*/
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
