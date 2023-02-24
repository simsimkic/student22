using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.pages
{
    public class viewRoomInfo
    {
        public List<Model.Statistika> Data { get; set; }
        public viewRoomInfo()
        {
            Data = new List<Model.Statistika>()
            {
                 new Model.Statistika {Vreme=StatistickiPodaci2.pocetniDatum, Soba=300 },
                 new Model.Statistika {Vreme="-", Soba=400},
                 new Model.Statistika {Vreme="-", Soba=200 },
                 new Model.Statistika {Vreme="-", Soba=550 },
                 new Model.Statistika {Vreme=StatistickiPodaci2.krajnjiDatum, Soba=100 },
            };
        }
    }
}
