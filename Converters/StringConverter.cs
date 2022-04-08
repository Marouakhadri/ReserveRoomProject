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
                return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = (string)value;

            if (!str.IsNotNullOrWhiteSpace())
            {
                return null;
            }

            int myint = 0;
            bool isNumber = int.TryParse(str, out myint);

            if (isNumber)
            {
                // return and fire
                return myint;
            }
            else
            {
                // just return
                return value;
            }
        }
    }
}
