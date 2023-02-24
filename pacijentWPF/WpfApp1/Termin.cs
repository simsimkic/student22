using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Termin
    {
        public string Datum { get; set; }
        public string Vreme { get; set; }

        public Termin(string datum, string vreme)
        {
            this.Datum = datum;
            this.Vreme = vreme;
        }
    }
}
