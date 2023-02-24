using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Lek
    {
        public String Ime { get; set; }
        public String Datum { get; set; }

        public Lek(string ime, string datum)
        {
            this.Ime = ime;
            this.Datum = datum;
        }
    }
}
