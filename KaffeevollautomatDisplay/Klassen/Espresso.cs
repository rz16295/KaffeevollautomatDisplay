using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeevollautomatDisplay.Klassen
{
    public class Espresso : Getraenk
    {
        public Espresso() : base("Espresso", zeit: 15, bohnen: 8, wasser: 50) { }
    }
}
