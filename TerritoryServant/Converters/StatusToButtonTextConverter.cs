using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using TerritoryServant.Data;
using TerritoryServant.Models;

namespace TerritoryServant.Converters
{
    public class StatusToButtonTextConverter : IValueConverter
    {
        public bool Invert { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var b = (TerritoryStatus) value == TerritoryStatus.CheckedIn;
            if (Invert) 
                return !b ? "Check In" : "Check Out";
            return b ? "Check In" : "Check Out";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
