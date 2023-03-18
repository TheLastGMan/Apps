using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EDSdkWrapper.Enums;

namespace EosViewer.Model.Transformation
{
	public class ModeConverter : IValueConverter
	{
		internal string ModeText(AEMode Mode)
		{
			switch (Mode)
			{
				case AEMode.Manual:
					return "M";
				case AEMode.Av:
					return "Av";
				case AEMode.Tv:
					return "Tv";
				case AEMode.Program:
					return "P";
				case AEMode.Invalid:
					return "N/C";
				default:
                    return "X";
			}
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is AEMode)
				return ModeText((AEMode)value);
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
