using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD
{
	public class DMDColor
	{
		/// <summary>
		/// Red display color value
		/// </summary>
		[XmlAttribute]
		public byte R { get; set; }

		/// <summary>
		/// Green display color value
		/// </summary>
		[XmlAttribute]
		public byte G { get; set; }

		/// <summary>
		/// Blue display color value
		/// </summary>
		[XmlAttribute]
		public byte B { get; set; }
	}
}
