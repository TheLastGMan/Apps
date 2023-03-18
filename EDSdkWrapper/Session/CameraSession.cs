using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Interop;
using EDSdkWrapper.Session.Properties;

namespace EDSdkWrapper.Session
{
	public class CameraSession : IDisposable
	{
		private bool _SessionOpen = false;
		public ConnectedCamera ConnectedDevice { get; private set; }
		public CameraProperty Settings { get; private set; }
		public CameraSelections Selections { get; private set; }

		//Camera Events
		public delegate void StateChangedHandler(StateEvent Event);
		public event StateChangedHandler StateChanged;
		public delegate void PropertyChangedHandler(PropertyEvent Event, Property Property);
		public event PropertyChangedHandler PropertyChanged;
		public delegate void ObjectChangedHandler(ObjectEvent Event);
		public event ObjectChangedHandler ObjectChanged;

		//SDK Camera Events
		internal event EDSdkCalls.SDKStateEventHandler SDKStateEvent;
		internal event EDSdkCalls.SDKPropertyEventHandler SDKPropertyEvent;
		internal event EDSdkCalls.SDKObjectEventHandler SDKObjectEvent;

		//SDK Mappers
		internal EDSDKResponseCode SDKStateEventMapper(StateEvent inEvent, uint inParameter, IntPtr inContext)
		{
			StateEvent e = (StateEvent)inEvent;
			if (StateChanged != null)
				StateChanged(e);
			return EDSDKResponseCode.OK;
		}

		internal EDSDKResponseCode SDKPropertyEventMapper(uint inEvent, uint inPropertyID, uint inParam, IntPtr inContext)
		{
			PropertyEvent pe = (PropertyEvent)inEvent;
			Property p = (Property)inPropertyID;
			if (PropertyChanged != null)
				PropertyChanged(pe, p);
			return EDSDKResponseCode.OK;
		}

		internal EDSDKResponseCode SDKObjectEventMapper(uint inEvent, IntPtr inRef, IntPtr inContext)
		{
			ObjectEvent e = (ObjectEvent)inEvent;
			if (ObjectChanged != null)
				ObjectChanged(e);
			return EDSDKResponseCode.OK;
		}

		public CameraSession(ConnectedCamera Device)
		{
			//set defaults
			ConnectedDevice = Device;
			Settings = new CameraProperty(this);
			Selections = new CameraSelections(this);

			//hook events
			SDKStateEvent += SDKStateEventMapper;
			SDKPropertyEvent += SDKPropertyEventMapper;

			//connect
			Open();
		}
		~CameraSession()
		{
			Dispose();
			//unhook event
			SDKStateEvent -= SDKStateEventMapper;
			SDKPropertyEvent -= SDKPropertyEventMapper;

			//unlink devices
			ConnectedDevice = null;
			Settings = null;
			Selections = null;
		}

		public void Dispose()
		{
			Close();
		}

		internal void Open()
		{
			if (!_SessionOpen)
			{
				EDSDK.OpenSession(this);
				//hook camera events
				EDSDK.SetStateChangedHandler(SDKStateEvent, ConnectedDevice.Camera, IntPtr.Zero);
				EDSDK.SetPropertyChangedHandler(SDKPropertyEvent, ConnectedDevice.Camera, IntPtr.Zero);
				EDSDK.SetObjectChangedHandler(SDKObjectEvent, ConnectedDevice.Camera, IntPtr.Zero);
			}
			_SessionOpen = true;
		}

		public void Close()
		{
			if (_SessionOpen)
				EDSDK.CloseSession(this);
			_SessionOpen = false;
		}

		//Camera Properties
		public IList<Volume> Volumes
		{
			get
			{
				var vols = new List<Volume>();

				int count = EDSDK.GetChildCount(ConnectedDevice.Camera.Reference);
				while (--count >= 0)
				{
					//combine camera information
					var volume = new Volume(EDSDK.GetChildAtIndex(ConnectedDevice.Camera.Reference, count));
					volume.Info = EDSDK.GetVolumeInfo(volume);
					vols.Add(volume);
				}
				vols.Reverse();

				return vols;
			}
		}

	}
}
