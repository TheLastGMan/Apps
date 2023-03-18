﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Session.Properties;

namespace EosViewer.Model.Transformation
{
	public class AperatureSizeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is AperatureSize)
				return CameraSelections.AperatureName((AperatureSize)value);
			return null;
        }

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
