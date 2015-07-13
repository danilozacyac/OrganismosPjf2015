using System;
using System.Linq;
using System.Windows.Data;
using OrganismosPjf2015.Singletons;

namespace OrganismosPjf2015.Converters
{
    class CircuitoConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                

                return (from n in CircuitosSingleton.Circuitos
                        where n.IdElemento == number
                        select n.Descripcion).ToList()[0];
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
