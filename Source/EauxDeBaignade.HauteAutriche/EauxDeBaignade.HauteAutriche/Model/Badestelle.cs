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

        // http://data.ooe.gv.at/files/cms/Legende_Einstufung_Badewasserqualitaet.jpg
        //               E.Coli  Enterokokken
        //gut            <100    <100
        //geeignet       <500    <250
        //bedenklich     <2000   <400
        //nicht geeignet >2000   >400
        public WaterQualityEnum EColiQuality
        {
            get
            {
                int ecoli = 0;
                if (Int32.TryParse(this.EColi, out ecoli))
                {
                    if (ecoli <= 100)
                        return WaterQualityEnum.Gut;
                    else if (ecoli <= 500)
                        return WaterQualityEnum.Geeignet;
                    else if (ecoli <=2000)
                        return WaterQualityEnum.Bedenklich;

                    return WaterQualityEnum.NichtGeeignet;
                }

                return WaterQualityEnum.NichtVerfuegbar;
            }
        }

        public WaterQualityEnum EnterokokkenQuality
        {
            get
            {
                int enterokokken = 0;
                if (Int32.TryParse(this.Enterokokken, out enterokokken))
                {
                    if (enterokokken <= 100)
                        return WaterQualityEnum.Gut;
                    else if (enterokokken <= 250)
                        return WaterQualityEnum.Geeignet;
                    else if (enterokokken <= 400)
                        return WaterQualityEnum.Bedenklich;

                    return WaterQualityEnum.NichtGeeignet;
                }

                return WaterQualityEnum.NichtVerfuegbar;
            }
        }

        public WaterQualityEnum WaterQuality
        {
            get
            {
                var ecoli = EColiQuality;
                var enterokokken = EnterokokkenQuality;

                return ecoli > enterokokken ? ecoli : enterokokken;
            }
        }
    }
}
