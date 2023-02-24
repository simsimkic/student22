using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI
{
    public class Objava
    {
        public String Text { get; set; }
        public String Autor { get; set; }

        public Objava(String text, String imeprezime)
        {
            this.Text = text;
            this.Autor = imeprezime;
        }
    }
}
