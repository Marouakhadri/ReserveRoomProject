using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Media;

namespace ReserveRoom.Converters
{
    public class ColorCenverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            Color Green = Color.FromRgb(0, 128, 0);
            Color Red = Color.FromRgb(255, 0, 0);
            Color Yellow = Color.FromRgb(255, 255, 0);
            int state = (int)value;

            if (state==0)
            {
                return "Red";
            }
            else if (state==1)
            {
                return "Green";
            }
            else
            {
                return "Green";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
