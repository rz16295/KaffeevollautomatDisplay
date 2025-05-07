using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KaffeevollautomatDisplay.Views
{
    public partial class ZubereitungView : UserControl
    {
        private Getraenk _getraenk;
        public event EventHandler ZubereitungBeendet;

        public ZubereitungView(Getraenk getraenk)
        {
            InitializeComponent();
            _getraenk = getraenk;

            if (!Fuellstand.GenugFuellstand(getraenk))
            {
                string fehlermeldung = $"Nicht genug Ressourcen für {_getraenk.Name}!";

                if (Fuellstand.AktuelleBohnen < getraenk.BohnenVerbrauchGramm)
                    fehlermeldung += " (Bohnen)";
                if (Fuellstand.AktuellerWasser < getraenk.WasserVerbrauchMl)
                    fehlermeldung += " (Wasser)";

                ZubereitungText.Text = fehlermeldung;

                // Nach kurzer Zeit zur Startseite zurückkehren
                Task.Run(async () =>
                {
                    await Task.Delay(2000); // 2 Sekunden warten
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ZubereitungBeendet?.Invoke(this, EventArgs.Empty);
                    });
                });

                return;
            }

            ZubereitungText.Text = $"Ihr {_getraenk.Name} wird zubereitet:";
            StartZubereitung();
        }

        private async void StartZubereitung()
        {
            Fuellstand.VerbrauchEintragen(_getraenk);

            int dauerMs = _getraenk.ZubereitungszeitSekunden * 1000;
            int interval = 50;
            int steps = dauerMs / interval;

            for (int i = 0; i <= steps; i++)
            {
                ZubereitungsProgressBar.Value = i * 100 / steps;
                await Task.Delay(interval);
            }

            ZubereitungText.Text = $"{_getraenk.Name} ist fertig!";
            ZubereitungsProgressBar.Visibility = Visibility.Collapsed;

            Console.WriteLine($"{_getraenk.Name} wurde erfolgreich zubereitet.");

            await Task.Delay(2000); // 2 Sekunden anzeigen
            ZubereitungBeendet?.Invoke(this, EventArgs.Empty);
        }
    }
}
