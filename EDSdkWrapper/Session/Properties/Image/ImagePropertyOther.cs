using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session.Properties.Image
{
	public partial class ImageProperty
	{
		public Rational ExposureCompensation
		{
			get { return GetSetting<Rational>(Property.Exposure_Compensation); }
		}

		public Rational AperatureSize
		{
			get { return GetSetting<Rational>(Property.Aperature_Size); }
		}

		public Rational ShutterSpeed
		{
			get { return GetSetting<Rational>(Property.Shutter_Speed); }
		}

		public PictureStyleDesc PictureStyleDesc
		{
			get { return GetSetting<PictureStyleDesc>(Property.Picture_StyleDesc); }
		}

		public FocusInfo FocusInfo
		{
			get { return GetSetting<FocusInfo>(Property.Focus_Info); }
		}

		public Rational DigitalExposure
		{
			get { return GetSetting<Rational>(Property.Digital_Exposure); }
		}

		public Time DateTime
		{
			get { return GetSetting<Time>(Property.DateTime); }
		}

		public WhiteBalanceShift WhiteBalanceShift
		{
			get { return GetSetting<WhiteBalanceShift>(Property.White_Balance_Shift); }
		}

		//Unknown Items
#warning Unknown Image Properties
		//Focal_Length : Type: Rational_Array : Size : 24
		//Flash_Mode : Type: UInt32_Array : Size : 8
		//White_Balance_Bracket : Type: Int32_Array : Size : 12
	}
}
