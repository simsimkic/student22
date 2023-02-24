using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekatHCI.pages
{
    public class ViewModel
    {
        public List<Model.Lekari> Data { get; set; }
        public ViewModel()
        {
            Data = new List<Model.Lekari>()
            {
                 new Model.Lekari {Vreme=Izvestaj.datum, Lekar1=300, Lekar2=200 },
                 new Model.Lekari {Vreme="-", Lekar1=450, Lekar2=500 },
                 new Model.Lekari {Vreme="-", Lekar1=400, Lekar2=300 },
                 new Model.Lekari {Vreme="-", Lekar1=550, Lekar2=500 },
                 new Model.Lekari {Vreme=Izvestaj.datum2, Lekar1=650, Lekar2=450 },
            };
        }
    }
}
