using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum Property : uint
	{
		/*----------------------------------
		Property Mask
		----------------------------------*/
		AtCapture_Flag = 0x80000000,

		/*----------------------------------
         Camera Setting Properties
        ----------------------------------*/
		Unknown = 0xffff,

		Product_Name = 0x002,
		Body_ID = 0x65,
		Body_ID_Ex = 0x015,
		Owner_Name = 0x004,
		Maker_Name = 0x005,
		DateTime = 0x006,
		Firmware_Version = 0x007,
		Battery_Level = 0x008,
		CFn = 0x009,
		Save_To = 0x00b,
		Current_Storage = 0x00c,
		Current_Folder = 0x00d,
		My_Menu = 0x00e,

		Battery_Quality = 0x010,
		HD_Directory_Structure = 0x020,
		Record = 0x510,

		/*----------------------------------
		 Image Processing Properties
		----------------------------------*/
		Linear = 0x300,
		Click_WB_Point = 0x301,
		WB_Coeffs = 0x302,

		/*----------------------------------
		 Capture Properties
		----------------------------------*/
		AE_Mode = 0x400,
		AE_Mode_Select = 0x436,
		Drive_Mode = 0x401,
		Iso_Speed = 0x402,
		Metering_Mode = 0x403,
		AF_Mode = 0x404,
		Aperature_Size = 0x405,
		Shutter_Speed = 0x406,
		Exposure_Compensation = 0x407,
		Flash_Compensation = 0x408,
		Focal_Length = 0x409,
		Available_Shots = 0x40a,
		Bracket = 0x40b,
		White_Balance_Bracket = 0x40c,
		Lens_Name = 0x40d,
		AE_Bracket = 0x40e,
		FE_Bracket = 0x40f,
		ISO_Bracket = 0x410,
		Noise_Reduction = 0x411,
		Flash_On = 0x412,
		Red_Eye = 0x413,
		Flash_Mode = 0x414,
		Lens_Status = 0x416,

		Artist = 0x418,
		Copyright = 0x419,
		Depth_Of_Field = 0x41b,
		EF_Compensation = 0x41e,

		/*----------------------------------
		Image Properties
		----------------------------------*/
		Image_Quality = 0x100,
		Jpeg_Quality = 0x101,
		Orientation = 0x102,
		ICC_Profile = 0x103,
		Focus_Info = 0x104,
		Digital_Exposure = 0x105,
		White_Balance = 0x106,
		Color_Temperature = 0x107,
		White_Balance_Shift = 0x108,
		Contrast = 0x109,
		Color_Saturation = 0x10a,
		Color_Tone = 0x10b,
		Sharpness = 0x10c,
		Color_Space = 0x10d,
		Tone_Curve = 0x10e,
		Photo_Effect = 0x10f,
		Filter_Effect = 0x110,
		Toning_Effect = 0x111,
		Parameter_Set = 0x112,
		Color_Matrix = 0x113,
		Picture_Style = 0x114,
		Picture_StyleDesc = 0x115,
		Picture_StyleCaption = 0x200,

		/*----------------------------------
		 Image GPS Properties
		----------------------------------*/
		GPS_VersionID = 0x800,
		GPS_LatitudeRef = 0x801,
		GPS_Latitude = 0x802,
		GPS_LongitudeRef = 0x803,
		GPS_Longitude = 0x804,
		GPS_AltitudeRef = 0x805,
		GPS_Altitude = 0x806,
		GPS_TimeStamp = 0x807,
		GPS_Satellites = 0x808,
		GPS_Status = 0x809,
		GPS_MapDatum = 0x812,
		GPS_DateStamp = 0x81D,

		/*----------------------------------
		 EVF Properties (Live view)
		----------------------------------*/
		Evf_Output_Device = 0x500,
		Evf_Mode = 0x501,
		Evf_WhiteBalance = 0x502,
		Evf_Color_Temperature = 0x503,
		Evf_Depth_Of_Field_Preview = 0x504,

		// EVF IMAGE DATA Properties
		Evf_Zoom = 0x507,
		Evf_Zoom_Position = 0x508,
		Evf_Focus_Aid = 0x509,
		Evf_Histogram = 0x50A,
		Evf_Image_Position = 0x50B,
		Evf_Histogram_Status = 0x50C,
		Evf_AF_Mode = 0x50E
	}
}
