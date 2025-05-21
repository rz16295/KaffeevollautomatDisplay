using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaffeevollautomatDisplay;
using KaffeevollautomatDisplay.Klassen;

namespace KaffeevollautomatDisplay.Tests
{
    [TestClass]
    public class FuellstandTests
    {
        [TestInitialize]
        public void Init()
        {
            Fuellstand.AktuelleBohnen = 0;
            Fuellstand.AktuellerWasser = 0;
        }

        [TestMethod]
        public void WasserUndBohnenWerdenAufgefuellt()
        {
            Fuellstand.WasserAuffuellen();
            Fuellstand.BohnenAuffuellen();

            Assert.AreEqual(Fuellstand.MaxWasser, Fuellstand.AktuellerWasser);
            Assert.AreEqual(Fuellstand.MaxBohnen, Fuellstand.AktuelleBohnen);
        }

        [TestMethod]
        public void GenugFuellstand_TrueBeiAusreichendemFuellstand()
        {
            Fuellstand.WasserAuffuellen();
            Fuellstand.BohnenAuffuellen();
            var kaffee = new Kaffee();

            Assert.IsTrue(Fuellstand.GenugFuellstand(kaffee));
        }

        [TestMethod]
        public void GenugFuellstand_FalseWennNichtsDrin()
        {
            var espresso = new Espresso();
            Assert.IsFalse(Fuellstand.GenugFuellstand(espresso));
        }
    }
}
