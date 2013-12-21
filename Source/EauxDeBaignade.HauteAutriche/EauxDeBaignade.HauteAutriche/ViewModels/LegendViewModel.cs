using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using EauxDeBaignade.HauteAutriche.Model;

namespace EauxDeBaignade.HauteAutriche.ViewModels
{
    public class LegendViewModel : Screen
    {
        public LegendViewModel()
        {
            LegendItems = LegendItem.GenerateLegendItems();
        }

        public List<LegendItem> LegendItems { get; set; }
    }
}
