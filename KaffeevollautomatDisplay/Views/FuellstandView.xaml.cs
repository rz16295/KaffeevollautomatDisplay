using System.Windows;
using System.Windows.Controls;

namespace KaffeevollautomatDisplay.Views
{
    public partial class FuellstandView : UserControl
    {
        public event EventHandler ZurueckClicked;

        public FuellstandView()
        {
            InitializeComponent();
            AktualisiereAnzeige();
        }

        private void AktualisiereAnzeige()
        {
            WasserstandText.Text = $"{Fuellstand.AktuellerWasser} ml / {Fuellstand.MaxWasser} ml";
            BohnenstandText.Text = $"{Fuellstand.AktuelleBohnen} g / {Fuellstand.MaxBohnen} g";
        }

        private void WasserAuffuellen_Click(object sender, RoutedEventArgs e)
        {
            Fuellstand.WasserAuffuellen();
            AktualisiereAnzeige();
        }

        private void BohnenAuffuellen_Click(object sender, RoutedEventArgs e)
        {
            Fuellstand.BohnenAuffuellen();
            AktualisiereAnzeige();
        }

        private void ZurueckButton_Click(object sender, RoutedEventArgs e)
        {
            ZurueckClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
