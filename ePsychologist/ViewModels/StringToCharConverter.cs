using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace ePsychologist.ViewModels
{
    class StringToCharConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return "";
            if (value.ToString() == "M")
                return "Man";
            if (value.ToString() == "W")
                return "Woman";
            if (value.ToString() == "D")
                return "Doctor";
            if (value.ToString() == "P")
                return "Patient";

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return "";
            ListBoxItem lbItem = (ListBoxItem)value;
            return lbItem.Content.ToString()[0];
        }
    }
}
