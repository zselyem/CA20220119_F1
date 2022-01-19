using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA20220119
{
    public class Jatek
    {
        public int ev;
        public string nev;
        public string mufaj;
        public string kiado;
        public string[] platform;

        public Jatek(int ev, string nev, string mufaj, string kiado, string[] platform)
        {
            this.ev = ev;
            this.nev = nev;
            this.mufaj = mufaj;
            this.kiado = kiado;
            this.platform = platform;
        }



    }
}
