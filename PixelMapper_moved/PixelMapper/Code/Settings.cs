using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PixelMapper.Code
{
	[XmlRoot]
	public class Settings
	{
		public static readonly string SettingFileName = "AppSettings.xml";

		public int ConversionProfileIndex { get; set; }
		public int OutputProfileIndex { get; set; }
	}
}
