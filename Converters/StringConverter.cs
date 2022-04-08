using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveRoom.Converters
{
    public class StringConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                int myInt = (int)value;
                return myInt;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null )
            {
                return 0;
            }

            int myInt = int.Parse(value.ToString());
            return myInt;
        }
    }
}
