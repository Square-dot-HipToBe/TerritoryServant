using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using TerritoryServant.Data;

namespace TerritoryServant.Converters
{
    public class TerritoryTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return "Null Value";
            
            var member = value.GetType().GetRuntimeFields().FirstOrDefault(x => x.Name == value.ToString());
            
            if (member == null) return "Null Member";

            var attrib = member.GetCustomAttribute(typeof (DisplayAttribute), false) as DisplayAttribute;

            if (attrib == null) return value.ToString();

            return attrib.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
