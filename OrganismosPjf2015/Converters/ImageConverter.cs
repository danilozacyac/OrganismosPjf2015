using System;
using System.Linq;
using System.Windows.Data;

namespace OrganismosPjf2015.Converters
{
    class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int number = 0;
            int.TryParse(value.ToString(), out number);

            switch (number)
            {
                case 0:
                case 1:
                    return "pack://application:,,,/Resources/blue_check_64.png";
                case 2: return "pack://application:,,,/Resources/hosp_128.png";
                case 3: return "pack://application:,,,/Resources/old_256.png";
                case 4: return "pack://application:,,,/Resources/banned_128.png";
                case 5: return "pack://application:,,,/Resources/ataud.png";

            

                default: return " ";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}