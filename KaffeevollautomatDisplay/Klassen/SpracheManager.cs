using System.Globalization;
using System.Threading;

// Die Klasse SpracheManager wurde mit Unterstützung von ChatGPT erstellt und im Projekt eigenständig angepasst.

namespace KaffeevollautomatDisplay
{
    public static class SpracheManager
    {
        public static string AktuelleSprache { get; private set; } = "de";

        public static void SetzeSprache(string kulturCode)
        {
            AktuelleSprache = kulturCode;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(kulturCode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(kulturCode);
        }

        public static string Text(string key)
        {
            return AktuelleSprache switch
            {
                "en" => key switch
                {
                    // Startseite / Navigation
                    "Willkommen" => "Welcome!",
                    "Getränkeauswahl" => "Choose Drink",
                    "Reinigung" => "Cleaning",
                    "Sprache" => "Language",
                    "Füllstand" => "Fill Level",
                    "Zurück" => "Back",

                    // Fehler- & Statusmeldungen
                    "Bitte Füllstand prüfen!" => "Please check fill level!",
                    "Bohnen leer." => "Beans empty.",
                    "Wasser leer." => "Water empty.",
                    "Nicht genug Ressourcen" => "Not enough resources for",
                    "ist fertig" => "is ready!",

                    // Zubereitung
                    "Ihr Getränk wird zubereitet" => "Your drink is being prepared",

                    // Füllstand
                    "Wasser auffüllen" => "Refill water",
                    "Bohnen auffüllen" => "Refill beans",
                    "Wasserstand" => "Water level",
                    "Bohnenstand" => "Bean level",
                    "Bohnen:" => "Beans:",
                    "Wasser:" => "Water:",

                    // Sprache
                    "Sprache wählen" => "Choose Language",
                    "Deutsch" => "German",
                    "Englisch" => "English",

                    // Getränkeauswahl
                    "Bitte wählen Sie Ihr Getränk" => "Please choose your drink",
                    "Kaffee" => "Coffee",
                    "Cappuccino" => "Cappuccino",
                    "Espresso" => "Espresso",

                    // Stärke wählen
                    "Stärke wählen" => "Choose strength",
                    "Mild" => "Mild",
                    "Normal" => "Normal",
                    "Stark" => "Strong",

                    _ => key
                },
                _ => key // Standard: Deutsch
            };
        }
    }
}
