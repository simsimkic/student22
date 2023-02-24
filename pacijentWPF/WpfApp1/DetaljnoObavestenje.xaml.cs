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

namespace HCI
{
    /// <summary>
    /// Interaction logic for DetaljnoObavestenje.xaml
    /// </summary>
    public partial class DetaljnoObavestenje : Window
    {
        public DetaljnoObavestenje()
        {
            InitializeComponent();
            if (Jezik.jezik1 == 0)
            {
                this.Title = "Objava";
                nazad.Content = "NAZAD";
                lekar1.Content = "Lekar:";
                s.Content = "Specijalizacija:";
                d.Content = "Objavljen:";
                k.Content = "Kategorija:";
                t.Content = "Tekst:";

;
            }
            else
            {
                this.Title = "Post";
                nazad.Content = "BACK";
                lekar1.Content = "Doctor:";
                s.Content = "Speciality:";
                d.Content = "Date:";
                k.Content = "Category:";
                t.Content = "Text:";
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
