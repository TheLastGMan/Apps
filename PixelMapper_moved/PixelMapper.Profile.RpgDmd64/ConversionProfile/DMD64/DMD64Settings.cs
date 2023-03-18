using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using PixelMapper.Core;

namespace PixelMapper.Profile.RpgDmd.ConversionProfile.DMD64
{
	[XmlRoot()]
	public class DMD64Settings
	{

		public ushort OutputWidth { get; set; }

		public ushort OutputHeight { get; set; }

		public GammaInfo GammaInfo { get; set; }


		public PixelMapper.Core.OutputPlugin PluginInfo { get; set; }

	}
}
