using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using EauxDeBaignade.HauteAutriche.Common;
using EauxDeBaignade.HauteAutriche.Model;
using Newtonsoft.Json;

namespace EauxDeBaignade.HauteAutriche.ViewModels
{
    public class AllViewModel : Screen
    {
        private readonly INavigationService _navigationService;

        public AllViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public List<AlphaKeyGroup<Badestelle>> Badestellen { get; set; }

        public void RebindBadestellen(List<Badestelle> badestellen)
        {
            // http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj244365%28v=vs.105%29.aspx
            List<AlphaKeyGroup<Badestelle>> grouped = AlphaKeyGroup<Badestelle>
                .CreateGroups(badestellen, Thread.CurrentThread.CurrentUICulture, h => h.Name, true);

            Badestellen = grouped;
            NotifyOfPropertyChange(() => Badestellen);
        }

        public void ShowBadestelle(object sender)
        {
            this.WhenSelectionChanged<Badestelle>(sender, 
                (item) => 
                    {
                        string json = JsonConvert.SerializeObject(item);

                        _navigationService.UriFor<BadestelleDetailsPageViewModel>()
                            .WithParam(vm => vm.NavigationBadestelleJson, json)
                            .Navigate();
                    });
        }
    }
}
