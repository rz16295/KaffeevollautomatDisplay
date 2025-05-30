using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaffeevollautomatDisplay.Klassen;

namespace KaffeevollautomatDisplay
{
    public abstract class Getraenk
    {
        public string Name { get; }
        public int ZubereitungszeitSekunden { get; }
        public int BohnenVerbrauchGramm { get; }
        public int WasserVerbrauchMl { get; }

        public Kaffeestaerke Staerke { get; set; } = Kaffeestaerke.Normal;

        protected Getraenk(string name, int zeit, int bohnen, int wasser)
        {
            Name = name;
            ZubereitungszeitSekunden = zeit;
            BohnenVerbrauchGramm = bohnen;
            WasserVerbrauchMl = wasser;
        }

        public int BerechneterBohnenVerbrauch
        {
            get
            {
                return Staerke switch
                {
                    Kaffeestaerke.Mild => (int)(BohnenVerbrauchGramm * 0.75),
                    Kaffeestaerke.Stark => (int)(BohnenVerbrauchGramm * 1.25),
                    _ => BohnenVerbrauchGramm,
                };
            }
        }


    }

}
