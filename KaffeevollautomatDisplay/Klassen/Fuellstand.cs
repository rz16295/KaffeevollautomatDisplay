namespace KaffeevollautomatDisplay
{
    public static class Fuellstand
    {
        public static int MaxWasser = 750;
        public static int MaxBohnen = 200;

        public static int AktuellerWasser = MaxWasser;
        public static int AktuelleBohnen = MaxBohnen;

        public static bool GenugFuellstand(Getraenk getraenk)
        {
            return AktuellerWasser >= getraenk.WasserVerbrauchMl && AktuelleBohnen >= getraenk.BerechneterBohnenVerbrauch;
        }

        public static void VerbrauchEintragen(Getraenk getraenk)
        {
            AktuellerWasser -= getraenk.WasserVerbrauchMl;
            AktuelleBohnen -= getraenk.BerechneterBohnenVerbrauch;
        }

        public static void WasserAuffuellen() => AktuellerWasser = MaxWasser;
        public static void BohnenAuffuellen() => AktuelleBohnen = MaxBohnen;
    }
}
