using KaffeevollautomatDisplay.Klassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KaffeevollautomatDisplay.Tests;

[TestClass]
public class AblaufTests
{
    [TestMethod]
    public void KompletterAblauf()
    {
        var espresso = new Espresso { Staerke = Kaffeestaerke.Normal };
        Fuellstand.AktuelleBohnen = 50;
        Fuellstand.AktuellerWasser = 100;

        Assert.IsTrue(Fuellstand.GenugFuellstand(espresso));

        Fuellstand.VerbrauchEintragen(espresso);

        Assert.AreEqual(50 - espresso.BohnenVerbrauchGramm, Fuellstand.AktuelleBohnen);
        Assert.AreEqual(100 - espresso.WasserVerbrauchMl, Fuellstand.AktuellerWasser);
    }
}
