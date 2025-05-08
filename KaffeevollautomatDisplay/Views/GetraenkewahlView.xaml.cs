using System;
using System.Windows;
using System.Windows.Controls;
using KaffeevollautomatDisplay.Klassen;

namespace KaffeevollautomatDisplay.Views
{
    public partial class GetraenkewahlView : UserControl
    {
        public event EventHandler<Getraenk> GetraenkAusgewaehlt;
        public event EventHandler ZurueckClicked;

        public GetraenkewahlView()
        {
            InitializeComponent();
            SetzeTexte();
        }

        private void SetzeTexte()
        {
            var grid = this.Content as Grid;
            if (grid == null) return;

            // Überschrift
            if (grid.Children[0] is TextBlock ueberschrift)
                ueberschrift.Text = SpracheManager.Text("Bitte wählen Sie Ihr Getränk");

            // Getränkenamen in Buttons (StackPanel in Button in StackPanel)
            if (grid.Children[1] is StackPanel buttonPanel)
            {
                if (buttonPanel.Children[0] is Button kaffeeBtn &&
                    kaffeeBtn.Content is StackPanel kaffeeStack &&
                    kaffeeStack.Children[1] is TextBlock kaffeeText)
                {
                    kaffeeText.Text = SpracheManager.Text("Kaffee");
                }

                if (buttonPanel.Children[1] is Button cappuccinoBtn &&
                    cappuccinoBtn.Content is StackPanel cappuccinoStack &&
                    cappuccinoStack.Children[1] is TextBlock cappuccinoText)
                {
                    cappuccinoText.Text = SpracheManager.Text("Cappuccino");
                }

                if (buttonPanel.Children[2] is Button espressoBtn &&
                    espressoBtn.Content is StackPanel espressoStack &&
                    espressoStack.Children[1] is TextBlock espressoText)
                {
                    espressoText.Text = SpracheManager.Text("Espresso");
                }
            }

            // Zurück-Button
            ZurueckButton.Content = SpracheManager.Text("Zurück");
        }


        private void Kaffee_Click(object sender, RoutedEventArgs e)
        {
            GetraenkAusgewaehlt?.Invoke(this, new Kaffee());
        }

        private void Cappuccino_Click(object sender, RoutedEventArgs e)
        {
            GetraenkAusgewaehlt?.Invoke(this, new Cappuccino());
        }

        private void Espresso_Click(object sender, RoutedEventArgs e)
        {
            GetraenkAusgewaehlt?.Invoke(this, new Espresso());
        }

        private void ZurueckButton_Click(object sender, RoutedEventArgs e)
        {
            ZurueckClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
