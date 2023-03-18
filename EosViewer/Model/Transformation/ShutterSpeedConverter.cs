using System;
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
	public class ShutterSpeedConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is ShutterSpeed)
				return CameraSelections.ShutterName((ShutterSpeed)value);
			return null;
        }

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
