using System;
using System.Linq;
using System.Windows.Data;
using ScjnUtilities;

namespace OrganismosPjf2015.Converters
{
    class LongDateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            DateTime fecha = System.Convert.ToDateTime(value);

            return DateTimeUtilities.ToLongDateFormat(fecha);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
