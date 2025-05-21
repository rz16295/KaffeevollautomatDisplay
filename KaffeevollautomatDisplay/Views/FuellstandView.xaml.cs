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
            SetzeTexte();
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

        private void SetzeTexte()
        {
            if (this.Content is Grid grid && grid.Children[0] is StackPanel buttonPanel)
            {
                if (buttonPanel.Children[0] is Button wasserBtn)
                    wasserBtn.Content = SpracheManager.Text("Wasser auffüllen");

                if (buttonPanel.Children[1] is Button bohnenBtn)
                    bohnenBtn.Content = SpracheManager.Text("Bohnen auffüllen");

                if (buttonPanel.Children[2] is Button zurueckBtn)
                    zurueckBtn.Content = SpracheManager.Text("Zurück");
            }

            if (this.Content is Grid mainGrid && mainGrid.Children[1] is Grid contentGrid)
            {
                if (contentGrid.Children[0] is StackPanel wasserPanel && wasserPanel.Children[0] is TextBlock wasserTitel)
                    wasserTitel.Text = SpracheManager.Text("Wasserstand");

                if (contentGrid.Children[1] is StackPanel bohnenPanel && bohnenPanel.Children[0] is TextBlock bohnenTitel)
                    bohnenTitel.Text = SpracheManager.Text("Bohnenstand");
            }
        }
    }
}
