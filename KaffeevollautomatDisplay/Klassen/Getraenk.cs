using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeevollautomatDisplay
{
    public abstract class Getraenk
    {
        public string Name { get; }
        public int ZubereitungszeitSekunden { get; }
        public int BohnenVerbrauchGramm { get; }
        public int WasserVerbrauchMl { get; }

        protected Getraenk(string name, int zeit, int bohnen, int wasser)
        {
            Name = name;
            ZubereitungszeitSekunden = zeit;
            BohnenVerbrauchGramm = bohnen;
            WasserVerbrauchMl = wasser;
        }
    }

}
