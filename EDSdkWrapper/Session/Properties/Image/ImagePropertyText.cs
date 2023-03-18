using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Session.Imaging;

namespace EDSdkWrapper.Session.Properties.Image
{
	public partial class ImageProperty : BaseImageProperty
	{
		public ImageProperty(ImageData Image)
			: base(Image)
		{
			GPS = new GPS(Image);
		}

		public GPS GPS { get; private set; }

		public string ProductName
		{
			get { return GetText(Property.Product_Name); }
		}

		public string OwnerName
		{
			get { return GetText(Property.Owner_Name); }
		}

		public string MakerName
		{
			get { return GetText(Property.Maker_Name); }
		}

		public string FirmwareVersion
		{
			get { return GetText(Property.Firmware_Version); }
		}

		public string BodyIdExtended
		{
			get { return GetText(Property.Body_ID_Ex); }
		}

		public string LensName
		{
			get { return GetText(Property.Lens_Name); }
		}

		public string Artist
		{
			get { return GetText(Property.Artist); }
		}

		public string Copyright
		{
			get { return GetText(Property.Copyright); }
		}
	}
}
