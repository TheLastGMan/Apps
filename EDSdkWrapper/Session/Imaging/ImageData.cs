using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Session.Properties.Image;

namespace EDSdkWrapper.Session.Imaging
{
	public class ImageData : BasePointer, IDisposable
	{
		public Image Image { get; private set; }

		public ImageData(Image Img)
		{
			Image = Img;
			//Create Image Reference
			Reference = EDSDK.CreateImageRef(Image);
			Settings = new ImageProperty(this);
		}
		~ImageData()
		{
			Dispose();
		}

		public void Dispose()
		{
			if (Reference != IntPtr.Zero)
				EDSDK.Release(Reference);
		}

		public ImageProperty Settings { get; private set; }

	}
}
