using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Interop;
using EDSdkWrapper.Session;

namespace EDSdkWrapper.Terminal
{
	public class TerminalService : IDisposable
	{
		private bool _Connected = false;

		//camera added event
		public delegate void CameraAddedHandler();
		public event CameraAddedHandler CameraAdded;

		internal event EDSdkCalls.SDKCameraAddedHandler SDKCameraAdded;
		internal EDSDKResponseCode SDKCameraAddedMapper(IntPtr Context)
		{
			if (CameraAdded != null)
				CameraAdded();
			return EDSDKResponseCode.OK;
		}

		public TerminalService()
		{
			SDKCameraAdded += SDKCameraAddedMapper;
		}
		~TerminalService()
		{
			SDKCameraAdded -= SDKCameraAddedMapper;
			Dispose();
		}

		public void Dispose()
		{
			Disconnect();
		}

		public void Connect()
		{
			if (!_Connected)
			{
				EDSDK.InitializeSDK();
				EDSDK.SetCameraAddedHandler(SDKCameraAdded, IntPtr.Zero);
			}
			_Connected = true;
		}

		public void Disconnect()
		{
			if (_Connected)
				EDSDK.TerminateSDK();
			_Connected = false;
		}

		public IList<ConnectedCamera> ConnectedCameras
		{
			get
			{
				var cams = new List<ConnectedCamera>();

				IntPtr cameras = EDSDK.GetCameraList();
				int count = EDSDK.GetChildCount(cameras);
				while(--count >= 0)
				{
					//combine camera information
					var camera = new Camera(EDSDK.GetChildAtIndex(cameras, count));
					var info = EDSDK.GetDeviceInfo(camera);
					cams.Add(new ConnectedCamera(camera, info));
				}
				EDSDK.Release(cameras);

				return cams;
			}
		}

	}
}
