using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Datum { get; set; }
        public string Pol { get; set; }
        public string Broj { get; set; }
        public string Email { get; set; }

        public Osoba(string ime, string prezime, string datum, string pol, string broj, string email)
        {
            Ime = ime;
            Prezime = prezime;
            Datum = datum;
            Pol = pol;
            Broj = broj;
            Email = email;
        }
    }
}
