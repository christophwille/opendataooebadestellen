using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Model
{
    public class Badestelle
    {
        public string Name { get; set; }
        public DateTime Datum { get; set; }
        public string EColi { get; set; }
        public string Enterokokken { get; set; }
        public string Bakterien { get; set; }
        public string Lufttemperatur { get; set; }
        public string WolkenAchtel { get; set; }
        public string Oberflaeche { get; set; }
        public string Sichttiefe { get; set; }
        public string pH { get; set; }
        public string Sauerstoffsaettigung { get; set; }
        public string Wassertemperatur { get; set; }

        public string DatumDisplay
        {
            get { return Datum.ToShortDateString(); }
        }

        public string WassertemperaturDisplay
        {
            get { return Wassertemperatur + " °"; }
        }
    }
}
