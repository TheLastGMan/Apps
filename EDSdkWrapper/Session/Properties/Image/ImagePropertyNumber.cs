using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Enums.Image;

namespace EDSdkWrapper.Session.Properties.Image
{
	public partial class ImageProperty
	{
		public ImageQuality ImageQuality
		{
			get { return GetSetting<ImageQuality>(Property.Image_Quality); }
		}

		public Orientation Orientation
		{
			get { return GetSetting<Orientation>(Property.Orientation); }
		}

		public WhiteBalance WhiteBalance
		{
			get { return GetSetting<WhiteBalance>(Property.White_Balance); }
		}

		public ColorTemperature ColorTemperature
		{
			get { return GetSetting<ColorTemperature>(Property.Color_Temperature); }
		}

		public Scaling Contrast
		{
			get { return GetSetting<Scaling>(Property.Contrast); }
		}

		public Scaling ColorSaturation
		{
			get { return GetSetting<Scaling>(Property.Color_Saturation); }
		}

		public Scaling ColorTone
		{
			get { return GetSetting<Scaling>(Property.Color_Tone); }
		}

		public Sharpness Sharpness
		{
			get { return GetSetting<Sharpness>(Property.Sharpness); }
		}

		public ColorSpace ColorSpace
		{
			get { return GetSetting<ColorSpace>(Property.Color_Space); }
		}

		public PhotoEffect PhotoEffect
		{
			get { return GetSetting<PhotoEffect>(Property.Photo_Effect); }
		}

		public PictureStyle PictureStyle
		{
			get { return GetSetting<PictureStyle>(Property.Picture_Style); }
		}

		public uint UNK_279
		{
			get { return GetSetting<uint>((Property)279); }
		}

		public AEMode AEMode
		{
			get { return GetSetting<AEMode>(Property.AE_Mode); }
		}

		public DriveMode DriveMode
		{
			get { return GetSetting<DriveMode>(Property.Drive_Mode); }
		}

		public IsoSpeed IsoSpeed
		{
			get { return GetSetting<IsoSpeed>(Property.Iso_Speed); }
		}

		public Metering MeteringMode
		{
			get { return GetSetting<Metering>(Property.Metering_Mode); }
		}

		public AFMode AFMode
		{
			get { return GetSetting<AFMode>(Property.AF_Mode); }
		}

		public Bracket Bracket
		{
			get { return GetSetting<Bracket>(Property.Bracket); }
		}

		public bool FlashUsed
		{
			get { return GetSetting<bool>(Property.Flash_On); }
		}

		public bool RedEyeReductionOff
		{
			get { return GetSetting<bool>(Property.Red_Eye); }
		}
	}
}
