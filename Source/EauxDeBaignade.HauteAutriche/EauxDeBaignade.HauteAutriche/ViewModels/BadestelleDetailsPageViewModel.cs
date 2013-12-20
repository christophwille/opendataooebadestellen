using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using EauxDeBaignade.HauteAutriche.Model;
using Newtonsoft.Json;

namespace EauxDeBaignade.HauteAutriche.ViewModels
{
    public class BadestelleDetailsPageViewModel : Screen
    {
        protected override void OnActivate()
        {
            base.OnActivate();

            this.Badestelle = JsonConvert.DeserializeObject<Badestelle>(NavigationBadestelleJson);
        }

        public string NavigationBadestelleJson { get; set; }

        private Badestelle _badestelle;

        public Badestelle Badestelle
        {
            get
            {
                return _badestelle;
            }
            set
            {
                _badestelle = value;
                NotifyOfPropertyChange(() => Badestelle);
            }
        }
    }
}
