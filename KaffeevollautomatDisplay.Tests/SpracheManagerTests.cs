using Microsoft.VisualStudio.TestTools.UnitTesting;
using KaffeevollautomatDisplay;

namespace KaffeevollautomatDisplay.Tests
{
    [TestClass]
    public class SpracheManagerTests
    {
        [TestMethod]
        public void Text_LiefertDeutschenWert()
        {
            SpracheManager.SetzeSprache("de");
            Assert.AreEqual("Willkommen", SpracheManager.Text("Willkommen"));
        }

        [TestMethod]
        public void Text_LiefertEnglischenWert()
        {
            SpracheManager.SetzeSprache("en");
            Assert.AreEqual("Welcome!", SpracheManager.Text("Willkommen"));
        }

        [TestMethod]
        public void Text_FaelltZurueckWennNichtGefunden()
        {
            SpracheManager.SetzeSprache("en");
            Assert.AreEqual("NichtVorhanden", SpracheManager.Text("NichtVorhanden"));
        }
    }
}
