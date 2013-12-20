using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using EauxDeBaignade.HauteAutriche.Services;
using Microsoft.Phone.Shell;

namespace EauxDeBaignade.HauteAutriche.ViewModels
{
    public class MainPageViewModel : Screen
    {
        private readonly IDataService _dataService;
        private readonly IUIService _uiService;

        public MainPageViewModel(FavoritesViewModel favoritesvm, AllViewModel allvm, LegendViewModel legendvm, AboutViewModel aboutvm,
            IDataService dataService,
            IUIService uiService)
        {
            _dataService = dataService;
            _uiService = uiService;
            Favorites = favoritesvm;
            All = allvm;
            Legend = legendvm;
            About = aboutvm;
        }

        public FavoritesViewModel Favorites { get; protected set; }
        public AllViewModel All { get; protected set; }
        public LegendViewModel Legend { get; protected set; }
        public AboutViewModel About { get; protected set; }

        protected override async void OnViewReady(object view)
        {
            base.OnViewReady(view);
            LoadDataAsync();
        }

        protected async Task LoadDataAsync()
        {
            EnableProgressBar("Daten werden geladen...");

            var data = await _dataService.RetrieveAsync();

            if (!data.Any())
            {
                _uiService.ShowTextToast("Fehler", "Daten konnten nicht geladen werden");
            }
            else
                All.RebindBadestellen(data);

            DisableProgressBar();
        }

        public async void RefreshBadestellen()
        {
            LoadDataAsync();
        }

        private ProgressIndicator _progressIndicator;

        protected void EnableProgressBar(string indicatorText)
        {
            if (null == _progressIndicator)
            {
                _progressIndicator = new ProgressIndicator()
                {
                    IsVisible = true
                };
                SystemTray.ProgressIndicator = _progressIndicator;
            }

            _progressIndicator.Text = indicatorText;
            _progressIndicator.IsIndeterminate = true;
        }

        protected void DisableProgressBar()
        {
            _progressIndicator.Text = "";
            _progressIndicator.IsIndeterminate = false;
        }
    }
}
