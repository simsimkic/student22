using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Pregled
    {
        public String Tip { get; set; }
        public String Datum { get; set; }
        public String Vreme { get; set; }
        public String Lekar { get; set; }

        public Pregled(String tip, String datum, String vreme, String lekar)
        {
            this.Tip = tip;
            this.Datum = datum;
            this.Vreme = vreme;
            this.Lekar = lekar;
        }
    }
}
