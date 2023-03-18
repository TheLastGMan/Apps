using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Session.Imaging;

namespace EDSdkWrapper.Session.Properties.Image
{
	public class GPS : BaseImageProperty
	{
		public GPS(ImageData Image)
			: base(Image)
		{ }

		//GPS_VersionID : Type: UInt8_Array : Size : 4
		//GPS_LatitudeRef
		//GPS_Latitude
		//GPS_LongitudeRef
		//GPS_Longitue
		//GPS_AltitudeRef
		//GPS_Altitude
		//GPS_TimeStamp
		//GPS_Satellites
		//GPS_MapDatum
		//GPS_DataStamp
		//GPS_Status

	}
}
