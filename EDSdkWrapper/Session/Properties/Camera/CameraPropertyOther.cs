using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session.Properties
{
	public partial class CameraProperty
	{
		public uint AvailableShots
		{
			get { return GetSetting<uint>(Property.Available_Shots); }
		}

		public ImageQuality ImageQuality
		{
			get { return GetSetting<ImageQuality>(Property.Image_Quality); }
			set { SetSetting(Property.Image_Quality, value.Raw); }
		}

		public Time DateTime
		{
			get { return GetSetting<Time>(Property.DateTime); }
		}

		public PictureStyleDesc PictureStyleDesc
		{
			get { return GetSetting<PictureStyleDesc>(Property.Picture_StyleDesc); }
			set { }
		}

		public WhiteBalanceShift WhiteBalanceShift
		{
			get { return GetSetting<WhiteBalanceShift>(Property.White_Balance_Shift); }
			set { }
		}

		public Point EvfZoomPosition
		{
			set { }
		}

#warning Unknown Camera Property
		//MyMenu : Type: UInt32_Array : Size : 0
	}
}
