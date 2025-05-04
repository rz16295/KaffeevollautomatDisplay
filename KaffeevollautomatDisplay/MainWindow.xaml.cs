using System.Windows;
using KaffeevollautomatDisplay.Views;

namespace KaffeevollautomatDisplay
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGetraenkewahl_Click(object sender, RoutedEventArgs e)
        {
            // View anzeigen und Startseite verstecken
            var view = new GetraenkewahlView();
            view.ZurueckClicked += View_ZurueckClicked;
            MainContent.Content = view;
            MainContent.Visibility = Visibility.Visible;
            StartseiteGrid.Visibility = Visibility.Collapsed;
        }

        private void View_ZurueckClicked(object sender, System.EventArgs e)
        {
            // Zurück zur Startseite
            MainContent.Visibility = Visibility.Collapsed;
            MainContent.Content = null;
            StartseiteGrid.Visibility = Visibility.Visible;
        }

        private void Reinigung_Click(object sender, RoutedEventArgs e) { }

        private void Sprache_Click(object sender, RoutedEventArgs e) { }

        private void Fuellstand_Click(object sender, RoutedEventArgs e) { }
    }
}
