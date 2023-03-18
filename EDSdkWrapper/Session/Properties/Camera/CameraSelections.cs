using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;

namespace EDSdkWrapper.Session.Properties
{
	public class CameraSelections : BaseCameraProperty
	{
		public CameraSelections(CameraSession Session)
			: base(Session)
		{ }

		//public MyMenu MenuItems
		//{
		//	get { }
		//}

		public ImageQuality[] ImageQualities
		{
			get { return PropertyArray<uint>(Property.Image_Quality).Select(f => new ImageQuality(f)).ToArray(); }
		}

		public WhiteBalance[] WhiteBalances
		{
			get { return PropertyArray<WhiteBalance>(Property.White_Balance); }
		}

		public ColorTemperature[] ColorTemperatures
		{
			get { return PropertyArray<ColorTemperature>(Property.Color_Temperature); }
		}

		public ColorSpace[] ColorSpaces
		{
			get { return PropertyArray<ColorSpace>(Property.Color_Space); }
		}

		public PictureStyle[] PictureStyles
		{
			get { return PropertyArray<PictureStyle>(Property.Picture_Style); }
		}

		public DriveMode[] DriveModes
		{
			get { return PropertyArray<DriveMode>(Property.Drive_Mode); }
		}

		public static string IsoName(IsoSpeed Iso)
		{
			return Iso.ToString().Replace("ISO_", "");
		}

		public IDictionary<IsoSpeed, string> IsoSpeeds
		{
			get
			{
				var values = PropertyArray<IsoSpeed>(Property.Iso_Speed);
				var output = values.ToDictionary<IsoSpeed, IsoSpeed, string>(f => f, f => IsoName(f));
				return output;
			}
		}

		public Metering[] MeteringModes
		{
			get { return PropertyArray<Metering>(Property.Metering_Mode); }
		}

		public AFMode[] AFModes
		{
			get { return PropertyArray<AFMode>(Property.AF_Mode); }
		}

		public static string AperatureName(AperatureSize Aperature)
		{
			//x1p2_1d3 = 1.2 (1/3) stop => F1.2
			string name = Aperature.ToString().Replace("x", "").Replace("p", ".").Replace("_1d3", "");
			return name;
		}

		public IDictionary<AperatureSize, string> AvSizes
		{
			get
			{
				var values = PropertyArray<AperatureSize>(Property.Aperature_Size);
				var output = values.ToDictionary<AperatureSize, AperatureSize, string>(f => f, f => AperatureName(f));
				return output;
			}
		}

		public static string ShutterName(ShutterSpeed ShutterSpeed)
		{
			//t20s_1d3 => 20"
			//t1d8000 => 1/8000"
			string name = ShutterSpeed.ToString().Replace("t", "").Replace("_1s3", "").Replace("q", "\"").Replace("s", "/");
			return name;
		}

		public IDictionary<ShutterSpeed, string> TvSizes
		{
			get
			{
				var values = PropertyArray<ShutterSpeed>(Property.Shutter_Speed);
				var output = values.ToDictionary<ShutterSpeed, ShutterSpeed, string>(f => f, f => ShutterName(f));
				return output;
			}
		}

		public Bracket[] AEBrackets
		{
			get { return PropertyArray<Bracket>(Property.AE_Bracket); }
		}

		public EvfOutputDevice[] LiveView_OutputDevices
		{
			get { return PropertyArray<EvfOutputDevice>(Property.Evf_Output_Device); }
		}

		public EvfMode[] LiveView_Modes
		{
			get { return PropertyArray<EvfMode>(Property.Evf_Mode); }
		}

		public WhiteBalance[] LiveView_WhiteBalances
		{
			get { return PropertyArray<WhiteBalance>(Property.Evf_WhiteBalance); }
		}

		public ColorTemperature[] LiveView_ColorTemperatures
		{
			get { return PropertyArray<ColorTemperature>(Property.Evf_Color_Temperature); }
		}

		public EvfAFMode[] LiveView_AFModes
		{
			get { return PropertyArray<EvfAFMode>(Property.Evf_AF_Mode); }
		}
	}
}
