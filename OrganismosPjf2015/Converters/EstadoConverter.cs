using System;
using System.Linq;
using System.Windows.Data;
using OrganismosPjf2015.Singletons;

namespace OrganismosPjf2015.Converters
{
    class EstadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                int number = 0;
                int.TryParse(value.ToString(), out number);

                if (number == 0)
                    return " ";

                int estado = (from n in CiudadesSingleton.Ciudades
                              where n.IdCiudad == number
                              select n.IdEstado).ToList()[0];

                return (from n in CiudadesSingleton.Estados
                        where n.IdEstado == estado
                        select n.EstadoStr).ToList()[0];
            }

            return " ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
