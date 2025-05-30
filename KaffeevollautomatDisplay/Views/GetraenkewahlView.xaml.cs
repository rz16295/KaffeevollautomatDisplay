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
            // Überschrift
            if (this.Content is Grid grid && grid.Children[0] is TextBlock ueberschrift)
                ueberschrift.Text = SpracheManager.Text("Bitte wählen Sie Ihr Getränk");

            KaffeeText.Text = SpracheManager.Text("Kaffee");
            CappuccinoText.Text = SpracheManager.Text("Cappuccino");
            EspressoText.Text = SpracheManager.Text("Espresso");
            ZurueckButton.Content = SpracheManager.Text("Zurück");
            StaerkeText.Text = SpracheManager.Text("Stärke wählen");

            if (StaerkeComboBox.Items[0] is ComboBoxItem item1) item1.Content = SpracheManager.Text("Mild");
            if (StaerkeComboBox.Items[1] is ComboBoxItem item2) item2.Content = SpracheManager.Text("Normal");
            if (StaerkeComboBox.Items[2] is ComboBoxItem item3) item3.Content = SpracheManager.Text("Stark");
        }



        private void Kaffee_Click(object sender, RoutedEventArgs e)
        {
            var kaffee = new Kaffee();
            kaffee.Staerke = AusgewaehlteStaerke();
            GetraenkAusgewaehlt?.Invoke(this, kaffee);

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

        private Kaffeestaerke AusgewaehlteStaerke()
        {
            return StaerkeComboBox.SelectedIndex switch
            {
                0 => Kaffeestaerke.Mild,
                1 => Kaffeestaerke.Normal,
                2 => Kaffeestaerke.Stark,
                _ => Kaffeestaerke.Normal
            };
        }
    }
}
