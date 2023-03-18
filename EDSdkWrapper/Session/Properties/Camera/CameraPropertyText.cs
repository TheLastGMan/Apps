using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums.Camera;

namespace EDSdkWrapper.Session.Properties
{
	public partial class CameraProperty : BaseCameraProperty
	{
		public CameraProperty(CameraSession Session) : base(Session)
		{ }

		public string ProductName
		{
			get { return GetText(Property.Product_Name); }
		}

		public string OwnerName
		{
			get { return GetText(Property.Owner_Name); }
			set { }
		}

		public string FirmwareVersion
		{
			get { return GetText(Property.Firmware_Version); }
		}

		public string CurrentStorage
		{
			get { return GetText(Property.Current_Storage); }
		}

		public string CurrentFolder
		{
			get { return GetText(Property.Current_Folder); }
		}

		public string BodyIDEx
		{
			get { return GetText(Property.Body_ID_Ex); }
		}

		public string BodyID
		{
			get { return GetText(Property.Body_ID); }
		}

		public string LensName
		{
			get { return GetText(Property.Lens_Name); }
		}

		public string Artist
		{
			get { return GetText(Property.Artist); }
			set { }
		}

		public string Copyright
		{
			get { return GetText(Property.Copyright); }
			set { }
		}
	}
}
