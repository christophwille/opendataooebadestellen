using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Model
{
    public class DesignTimeSampleData
    {
        public ObservableCollection<Badestelle> Badestellen { get; set; }
        public Badestelle Badestelle { get; set; }

        public DesignTimeSampleData()
        {
            this.Badestelle = new Badestelle()
            {
                Name = "Wolfgangsee",
                Datum = new DateTime(2013, 8, 1),
                Wassertemperatur = "20,1"
            };

            var bs = new List<Badestelle>()
            {
                this.Badestelle
            };

            Badestellen = new ObservableCollection<Badestelle>(bs);
        }
    }
}
