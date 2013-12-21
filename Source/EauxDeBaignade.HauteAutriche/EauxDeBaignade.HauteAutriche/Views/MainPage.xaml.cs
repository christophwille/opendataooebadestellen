using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using EauxDeBaignade.HauteAutriche.Resources;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ReviewNotifier.Apollo;
using CM = Caliburn.Micro;

namespace EauxDeBaignade.HauteAutriche.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }
        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar()
            {
                IsVisible = true
            };

            var refreshAppBarButton = new CM.AppBarButton()
            {
                IconUri = new Uri("/Assets/refresh.png", UriKind.Relative),
                Text = "Aktualisieren",
                Message = "RefreshBadestellen"
            };

            ApplicationBar.Buttons.Add(refreshAppBarButton);
        }

        private void PanoramaMain_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isUpdateableView =
                ((PanoramaItem)(((Panorama)sender).SelectedItem)).Content is AllView;

            ApplicationBar.IsVisible = isUpdateableView;
        }

        private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            ReviewNotification.TriggerAsync("Lassen Sie andere wissen was Sie über diese App denken - und reviewen Sie bitte!",
                "Bitten bewerten Sie die App", 
                5);
        }
    }
}