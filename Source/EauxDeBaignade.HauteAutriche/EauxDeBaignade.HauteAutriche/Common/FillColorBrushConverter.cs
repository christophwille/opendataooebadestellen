using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EauxDeBaignade.HauteAutriche.Model;

namespace EauxDeBaignade.HauteAutriche.Common
{
    public class FillColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is WaterQualityEnum)
            {
                var qe = (WaterQualityEnum)value;
                switch (qe)
                {
                    case WaterQualityEnum.NichtVerfuegbar:
                        break;
                    case WaterQualityEnum.Gut:
                        return LegendItem.GutBrush;
                        break;
                    case WaterQualityEnum.Geeignet:
                        return LegendItem.GeeignetBrush;
                        break;
                    case WaterQualityEnum.Bedenklich:
                        return LegendItem.BedenklichBrush;
                        break;
                    case WaterQualityEnum.NichtGeeignet:
                        return LegendItem.NichtGeeignetBrush;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
