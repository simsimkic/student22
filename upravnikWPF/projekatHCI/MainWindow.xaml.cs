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
using System.Windows.Navigation;
using System.Windows.Shapes;
using projekatHCI.pages;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ProjekatKlinika.Controller;
using Model.Users;

namespace projekatHCI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,  INotifyPropertyChanged
    {
        public static string mejl = String.Empty;
        public static string sifra = String.Empty;
        private readonly ManagerController managerController;
        public static ObservableCollection<Model.Korisnici> ListaKorisnika
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            var app = Application.Current as App;

            managerController = app.managerController;

            ListaKorisnika = new ObservableCollection<Model.Korisnici>() {
            new Model.Korisnici() {Mejl = "e@gmail.com",Lozinka="pera"}
            };

      
        }
        private Manager isManager(String email, String password)
        {
            return managerController.LogIn(email, password);
        }
        public event PropertyChangedEventHandler PropertyChanged;

       
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            mejl = textBox.Text;
            sifra = textBox1.Text;

            if (isManager(mejl, sifra) != null)
            {
                var s = new Upravnik();
                s.Show();
                this.Close();
            }
            /*
            foreach (Model.Korisnici mk in ListaKorisnika)
            {
                if (mk.Mejl != mejl || mk.Lozinka != sifra)
                {
                    if (mejl == "")
                    {
                        MessageBox.Show("Morate uneti Vas mejl.");
                    }
                    else if (sifra == "")
                    {
                        MessageBox.Show("Morate uneti Vasu sifru");
                    }
                    else
                    {
                        MessageBox.Show("Neispravan mejl ili sifra!");
                    }
                }
                
                
                else
                {
                    var s = new Upravnik();
                    s.Show();
                    this.Close();
                }
            }
           */     
           
        }

    }
}
