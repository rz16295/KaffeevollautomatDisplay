using KaffeevollautomatDisplay.Klassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KaffeevollautomatDisplay.Tests;

[TestClass]
public class ZubereitungTests
{
    [TestMethod]
    public void GetraenkZubereitungVerbrauchtRichtigeMenge()
    {
        var espresso = new Espresso { Staerke = Kaffeestaerke.Stark };
        Fuellstand.AktuelleBohnen = 100;
        Fuellstand.AktuellerWasser = 100;

        Fuellstand.VerbrauchEintragen(espresso);

        Assert.AreEqual(90, Fuellstand.AktuelleBohnen);
        Assert.AreEqual(100 - espresso.WasserVerbrauchMl, Fuellstand.AktuellerWasser);
    }

    [TestMethod]
    public void GetraenkZubereitungNichtGenugBohnen()
    {
        var espresso = new Espresso { Staerke = Kaffeestaerke.Stark };
        Fuellstand.AktuelleBohnen = 5; // Weniger als benötigt
        Fuellstand.AktuellerWasser = 100;
        
        bool reicht = Fuellstand.GenugFuellstand(espresso);

        Assert.IsFalse(reicht);
    }
}
