using System;
using System.Windows;
using System.Windows.Controls;
using KaffeevollautomatDisplay.Klassen;

namespace KaffeevollautomatDisplay.Views
{
    public partial class GetraenkewahlView : UserControl
    {
        public event EventHandler ZurueckClicked;

        public GetraenkewahlView()
        {
            InitializeComponent();
        }

        private void ZurueckButton_Click(object sender, RoutedEventArgs e)
        {
            ZurueckClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Kaffee_Click(object sender, RoutedEventArgs e)
        {
            AppState.AktuellesGetraenk = new Kaffee();
        }

        private void Cappuccino_Click(object sender, RoutedEventArgs e)
        {
            AppState.AktuellesGetraenk = new Cappuccino();
        }

        private void Espresso_Click(object sender, RoutedEventArgs e)
        {
            AppState.AktuellesGetraenk = new Espresso();
        }

    }
}
