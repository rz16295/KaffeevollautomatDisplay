﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeevollautomatDisplay.Klassen
{
    public enum Kaffeestaerke
    {
        Mild, Normal, Stark
    }
    public class Kaffee : Getraenk
    {
        public Kaffee() : base("Kaffee", 20, 10, 150) { }
    }
}
