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

            string getraenkName = SpracheManager.Text(_getraenk.Name);

            if (!Fuellstand.GenugFuellstand(getraenk))
            {
                string fehlermeldung = $"{SpracheManager.Text("Nicht genug Ressourcen")} {getraenkName}!";

                if (Fuellstand.AktuelleBohnen < getraenk.BohnenVerbrauchGramm)
                    fehlermeldung += $" ({SpracheManager.Text("Bohnen:").TrimEnd(':')})";
                if (Fuellstand.AktuellerWasser < getraenk.WasserVerbrauchMl)
                    fehlermeldung += $" ({SpracheManager.Text("Wasser:").TrimEnd(':')})";

                ZubereitungText.Text = fehlermeldung;

                // Nach kurzer Zeit zur Startseite zurückkehren
                Task.Run(async () =>
                {
                    await Task.Delay(2000);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ZubereitungBeendet?.Invoke(this, EventArgs.Empty);
                    });
                });

                return;
            }

            ZubereitungText.Text = $"{SpracheManager.Text("Ihr Getränk wird zubereitet")}: {getraenkName}";
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

            string getraenkName = SpracheManager.Text(_getraenk.Name);
            ZubereitungText.Text = $"{getraenkName} {SpracheManager.Text("ist fertig")}";
            ZubereitungsProgressBar.Visibility = Visibility.Collapsed;

            Console.WriteLine($"{getraenkName} wurde erfolgreich zubereitet.");

            await Task.Delay(2000);
            ZubereitungBeendet?.Invoke(this, EventArgs.Empty);
        }
    }
}
