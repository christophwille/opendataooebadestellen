using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EauxDeBaignade.HauteAutriche.Model
{
    public class LegendItem
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Brush FillColorBrush { get; set; }

        public static List<LegendItem> GenerateLegendItems()
        {
            return new List<LegendItem>()
            {
                new LegendItem()
                {
                    Name = "gut",
                    Beschreibung = "geringe bakteriologische Belastung",
                    FillColorBrush = GutBrush
                },
                new LegendItem()
                {
                    Name = "geeignet",
                    Beschreibung = "mäßige bakteriologische Belastung",
                    FillColorBrush = GeeignetBrush
                },
                new LegendItem()
                {
                    Name = "bedenklich",
                    Beschreibung = "starke bakteriologische Belastung",
                    FillColorBrush = BedenklichBrush
                },
                new LegendItem()
                {
                    Name = "nicht geeignet",
                    Beschreibung = "sehr starke bakteriologische Belastung",
                    FillColorBrush = NichtGeeignetBrush
                },
            };
        }

        public static readonly Brush GutBrush = new SolidColorBrush(Colors.Blue);
        public static readonly Brush GeeignetBrush = new SolidColorBrush(Colors.Green);
        public static readonly Brush BedenklichBrush = new SolidColorBrush(Colors.Yellow);
        public static readonly Brush NichtGeeignetBrush = new SolidColorBrush(Colors.Red);
    }
}
