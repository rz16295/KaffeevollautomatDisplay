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

           
            view.GetraenkAusgewaehlt += (s, getraenk) =>
            {
                var zubereitungView = new ZubereitungView(getraenk);
                zubereitungView.ZubereitungBeendet += (ss, ee) =>
                {
                    MainContent.Content = null;
                    MainContent.Visibility = Visibility.Collapsed;
                    StartseiteGrid.Visibility = Visibility.Visible;
                    AktualisiereFuellstandHinweis();
                };

                MainContent.Content = zubereitungView;
            };
            view.ZurueckClicked += (s, e) => { MainContent.Content = null; };
            MainContent.Content = view;
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

        

        public void ZurueckZurStartseite()
        {
            MainContent.Content = null; // oder neue StartView, falls du eine eigene hast
        }

        private void AktualisiereFuellstandHinweis()
        {
            var fehltText = "";

            if (Fuellstand.AktuelleBohnen <= 0)
                fehltText += "Bohnen leer. ";

            if (Fuellstand.AktuellerWasser <= 0)
                fehltText += "Wasser leer. ";

            FuellstandHinweis.Text = fehltText.Trim();
        }

        private void Fuellstand_Click(object sender, RoutedEventArgs e)
        {
            var view = new FuellstandView();
            view.ZurueckClicked += (s, ee) =>
            {
                MainContent.Content = null;
                MainContent.Visibility = Visibility.Collapsed;
                StartseiteGrid.Visibility = Visibility.Visible;
                AktualisiereFuellstandHinweis();
            };
            MainContent.Content = view;
            MainContent.Visibility = Visibility.Visible;
            StartseiteGrid.Visibility = Visibility.Collapsed;
        }


    }
}
