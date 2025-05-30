using System;
using System.Windows;
using System.Windows.Controls;

namespace KaffeevollautomatDisplay.Views
{
    public partial class SpracheView : UserControl
    {
        public event EventHandler SpracheGeaendert;
        public event EventHandler ZurueckClicked;

        public SpracheView()
        {
            InitializeComponent();
            SetzeTexte();
        }

        private void Deutsch_Click(object sender, RoutedEventArgs e)
        {
            SpracheManager.SetzeSprache("de");
            SpracheGeaendert?.Invoke(this, EventArgs.Empty);
        }

        private void Englisch_Click(object sender, RoutedEventArgs e)
        {
            SpracheManager.SetzeSprache("en");
            SpracheGeaendert?.Invoke(this, EventArgs.Empty);
        }

        private void Zurueck_Click(object sender, RoutedEventArgs e)
        {
            ZurueckClicked?.Invoke(this, EventArgs.Empty);
        }

        private void SetzeTexte()
        {
            ZurueckTextBlock.Text = SpracheManager.Text("Zurück");
        }
    }
}
