using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Lekar
    {
        public string Doktor{ get; set; }
        public double Ocena { get; set; }

        public Lekar(string ime, double ocena)
        {
            this.Doktor = ime;
            this.Ocena = ocena;
        }
    }
}
