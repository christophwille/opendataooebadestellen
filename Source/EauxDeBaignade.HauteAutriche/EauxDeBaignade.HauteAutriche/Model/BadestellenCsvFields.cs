using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EauxDeBaignade.HauteAutriche.Model
{
    public enum BadestellenCsvFields
    {
        // Fields in the dataset:
        //
        // #1 Badestelle;
        // #2 Datum;
        // #3 E.coli (Fäkalcoli.) in 100 ml;
        // #4 Intestinale Enterokokken in 100 ml;
        // #5 Gesamtcoliforme Bakterien;
        // #6 Luft Temp. °C;
        // #7 Wolken (in /8) Wetter;
        // #8 Oberfläche (Aussehen, Farbe);
        // #9 ST (Sichttiefe) in m;
        // #10 pH;
        // #11 O2 (Sauerstoffsättigung) in %;
        // #12 Wasser Temp. °C

        Name = 0,
        Datum,
        EColi,
        Enterokokken,
        Bakterien,
        Lufttemperatur,
        WolkenAchtel,
        Oberflaeche,
        Sichttiefe,
        pH,
        Sauerstoffsaettigung,
        Wassertemperatur
    }
}
