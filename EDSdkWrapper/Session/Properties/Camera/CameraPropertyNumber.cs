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
		/// <summary>
		/// Read/Write
		/// </summary>
		public SaveTo SaveTo
		{
			get { return GetSetting<SaveTo>(Property.Save_To); }
			set { SetSetting(Property.Save_To, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public PictureStyle PictureStyle
		{
			get { return GetSetting<PictureStyle>(Property.Picture_Style); }
			set { SetSetting(Property.Picture_Style, (uint)value); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public AEMode AEMode
		{
			get { return GetSetting<AEMode>(Property.AE_Mode); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public DriveMode DriveMode
		{
			get { return GetSetting<DriveMode>(Property.Drive_Mode); }
			set { SetSetting(Property.Drive_Mode, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public IsoSpeed IsoSpeed
		{
			get { return GetSetting<IsoSpeed>(Property.Iso_Speed); }
			set { SetSetting(Property.Iso_Speed, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public Metering MeteringMode
		{
			get { return GetSetting<Metering>(Property.Metering_Mode); }
			set { SetSetting(Property.Metering_Mode, (uint)value); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public AFMode AFMode
		{
			get { return GetSetting<AFMode>(Property.AF_Mode); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public AperatureSize AperatureSize
		{
			get { return GetSetting<AperatureSize>(Property.Aperature_Size); }
			set { SetSetting(Property.Aperature_Size, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public ShutterSpeed ShutterSpeed
		{
			get { return GetSetting<ShutterSpeed>(Property.Shutter_Speed); }
			set { SetSetting(Property.Shutter_Speed, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public Exposure ExposureCompensation
		{
			get { return GetSetting<Exposure>(Property.Exposure_Compensation); }
			set { SetSetting(Property.Exposure_Compensation, (uint)value); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public BatteryLevel BatteryLevel
		{
			get { return GetSetting<BatteryLevel>(Property.Battery_Level); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public WhiteBalance WhiteBalance
		{
			get { return GetSetting<WhiteBalance>(Property.White_Balance); }
			set { SetSetting(Property.White_Balance, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public ColorTemperature ColorTemperature
		{
			get { return GetSetting<ColorTemperature>(Property.Color_Temperature); }
			set { SetSetting(Property.Color_Temperature, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public ColorSpace ColorSpace
		{
			get { return GetSetting<ColorSpace>(Property.Color_Space); }
			set { SetSetting(Property.Color_Space, (uint)value); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public WhiteBalance EvfWhiteBalance
		{
			get { return GetSetting<WhiteBalance>(Property.Evf_WhiteBalance); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public Bracket Bracket
		{
			get { return GetSetting<Bracket>(Property.Bracket); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public Bracket AEBracket
		{
			get { return GetSetting<Bracket>(Property.AE_Bracket); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public LensStatus LensStatus
		{
			get { return GetSetting<LensStatus>(Property.Lens_Status); }
		}

		/// <summary>
		/// Read across all models
		/// Write for models without a Mode Dial
		/// </summary>
		//public AEModeSelect AEModeSelect
		public AEMode AEModeSelect
		{
			get { return GetSetting<AEMode>(Property.AE_Mode_Select); }
			set { SetSetting(Property.AE_Mode_Select, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public EvfOutputDevice EvfOutputDevice
		{
			get { return GetSetting<EvfOutputDevice>(Property.Evf_Output_Device); }
			set { SetSetting(Property.Evf_Output_Device, (uint)value); }
		}

		/// <summary>
		/// Enable/Disable Live View
		/// </summary>
		public EvfMode EvfMode
		{
			get { return GetSetting<EvfMode>(Property.Evf_Mode); }
			set { SetSetting(Property.Evf_Mode, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public ColorTemperature EvfColorTemperature
		{
			get { return GetSetting<ColorTemperature>(Property.Evf_Color_Temperature); }
			set { SetSetting(Property.Evf_Color_Temperature, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public EvfDepthOfFieldPreview EvfDepthOfFieldPreview
		{
			get { return GetSetting<EvfDepthOfFieldPreview>(Property.Evf_Depth_Of_Field_Preview); }
			set { SetSetting(Property.Evf_Depth_Of_Field_Preview, (uint)value); }
		}

		/// <summary>
		/// Read
		/// </summary>
		public EvfZoom EvfZoom
		{
			set { SetSetting(Property.Evf_Zoom, (uint)value); }
		}

		/// <summary>
		/// Read/Write
		/// </summary>
		public EvfAFMode EvfAFMode
		{
			get { return GetSetting<EvfAFMode>(Property.Evf_AF_Mode); }
			set { SetSetting(Property.Evf_AF_Mode, (uint)value); }
		}

		/// <summary>
		/// Start/Stop Video Recording
		/// </summary>
		public Record Record
		{
			get { return GetSetting<Record>(Property.Record); }
			set { SetSetting(Property.Record, (uint)value); }
		}
	}
}
