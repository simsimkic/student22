using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Uput
    {
        public String Lekar { get; set; }
        public String Datum { get; set; }

        public Uput(string ime, string datum)
        {
            this.Lekar = ime;
            this.Datum = datum;
        }

    }
}
