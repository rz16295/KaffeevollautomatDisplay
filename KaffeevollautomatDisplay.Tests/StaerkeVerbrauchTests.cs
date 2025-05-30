using KaffeevollautomatDisplay.Klassen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KaffeevollautomatDisplay.Tests;

[TestClass]
public class StaerkeVerbrauchTests
{
    [TestMethod]
    public void MildVerbrauchtWeniger()
    {
        var kaffee = new Kaffee { Staerke = Kaffeestaerke.Mild };
        int expected = (int)(kaffee.BohnenVerbrauchGramm * 0.75);

        Assert.AreEqual(expected, kaffee.BerechneterBohnenVerbrauch);
    }

    [TestMethod]
    public void StarkVerbrauchtMehr()
    {
        var kaffee = new Kaffee { Staerke = Kaffeestaerke.Stark };
        int expected = (int)(kaffee.BohnenVerbrauchGramm * 1.25);

        Assert.AreEqual(expected, kaffee.BerechneterBohnenVerbrauch);
    }
}
