using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using TerritoryServant.Data;

namespace TerritoryServant.Converters
{
    public class BooleanToTerrStatusConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TerritoryStatus) {
                var v = (TerritoryStatus)value;
                return v == TerritoryStatus.CheckedIn;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is Boolean) {
                var v = (Boolean)value;

                return v ? TerritoryStatus.CheckedIn : TerritoryStatus.CheckedOut;
            }
            return null;
        }
    }
}
