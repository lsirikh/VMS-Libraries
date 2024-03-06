﻿
using Dotnet.Libraries.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Dotnet.Libraries.Utils
{
    public class EnumDeviceTypeToSensorAllowedConverter
        : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(bool))
                return null;


            string inputData = value.ToString();

            if (inputData == EnumDeviceType.NONE.ToString())
                return false;
            else if (inputData == EnumDeviceType.Controller.ToString())
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
