using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaffeevollautomatDisplay.Klassen;


namespace KaffeevollautomatDisplay.Tests
{
    [TestClass]
    public class VerbrauchTests
    {
        [TestInitialize]
        public void Init()
        {
            Fuellstand.WasserAuffuellen();
            Fuellstand.BohnenAuffuellen();
        }

        [TestMethod]
        public void VerbrauchWirdKorrektAbgezogen()
        {
            var espresso = new Espresso();
            int wasserVorher = Fuellstand.AktuellerWasser;
            int bohnenVorher = Fuellstand.AktuelleBohnen;

            Fuellstand.VerbrauchEintragen(espresso);

            Assert.AreEqual(wasserVorher - espresso.WasserVerbrauchMl, Fuellstand.AktuellerWasser);
            Assert.AreEqual(bohnenVorher - espresso.BohnenVerbrauchGramm, Fuellstand.AktuelleBohnen);
        }

        [TestMethod]
        public void MehrereGetraenkeLeerenFuellstand()
        {
            Fuellstand.AktuelleBohnen = 25;
            Fuellstand.AktuellerWasser = 300;

            Fuellstand.VerbrauchEintragen(new Kaffee());
            Fuellstand.VerbrauchEintragen(new Cappuccino());

            Assert.AreEqual(25 - (10+12), Fuellstand.AktuelleBohnen);   
            Assert.AreEqual(300 - (150 + 120), Fuellstand.AktuellerWasser);
        }
    }
}
