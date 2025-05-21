using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaffeevollautomatDisplay;
using KaffeevollautomatDisplay.Klassen;

namespace KaffeevollautomatDisplay.Tests
{
    [TestClass]
    public class GetraenkTests
    {
        [TestMethod]
        public void KaffeeHatRichtigeWerte()
        {
            var getraenk = new Kaffee();
            Assert.AreEqual("Kaffee", getraenk.Name);
            Assert.AreEqual(20, getraenk.ZubereitungszeitSekunden);
            Assert.AreEqual(10, getraenk.BohnenVerbrauchGramm);
            Assert.AreEqual(150, getraenk.WasserVerbrauchMl);
        }

        [TestMethod]
        public void CappuccinoHatRichtigeWerte()
        {
            var getraenk = new Cappuccino();
            Assert.AreEqual("Cappuccino", getraenk.Name);
            Assert.AreEqual(30, getraenk.ZubereitungszeitSekunden);
            Assert.AreEqual(12, getraenk.BohnenVerbrauchGramm);
            Assert.AreEqual(120, getraenk.WasserVerbrauchMl);
        }

        [TestMethod]
        public void EspressoHatRichtigeWerte() {
            var getraenk = new Espresso();
            Assert.AreEqual("Espresso", getraenk.Name);
            Assert.AreEqual(15, getraenk.ZubereitungszeitSekunden);
            Assert.AreEqual(8, getraenk.BohnenVerbrauchGramm);
            Assert.AreEqual(50, getraenk.WasserVerbrauchMl);
        }
    }
}