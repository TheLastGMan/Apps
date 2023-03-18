using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session
{
	public class ConnectedCamera
	{
		public ConnectedCamera(Camera Camera, DeviceInfo Info)
		{
			this.Camera = Camera;
			this.Info = Info;
		}

		public Camera Camera { get; private set; }
		public DeviceInfo Info { get; private set; }

		public CameraSession Connect()
		{
			return new CameraSession(this);
		}

		public string Name
		{
			get { return Info.szDeviceDescription; }
		}
	}
}
