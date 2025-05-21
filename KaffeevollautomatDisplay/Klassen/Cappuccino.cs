using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeevollautomatDisplay.Klassen
{
    public class Cappuccino : Getraenk
    {
        public Cappuccino() : base("Cappuccino", zeit: 30, bohnen: 12, wasser: 120) { }
    }
}
