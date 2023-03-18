using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums.Camera;

namespace EDSdkWrapper.Session.Properties
{
	public class BaseCameraProperty
	{
		private CameraSession Session;

		public BaseCameraProperty(CameraSession Session)
		{
			this.Session = Session;
		}

		public T GetSetting<T>(Property Property) where T : struct
		{
			T result = Session.ConnectedDevice.Camera.Setting<T>((uint)Property, (ptr) =>
			{
				Type type = typeof(T);
				if (type.IsEnum)
					type = Enum.GetUnderlyingType(type);
				return (T)Marshal.PtrToStructure(ptr, type);
			});
			return result;
		}

		public void SetSetting(Property Property, uint Value)
		{
			var propInfo = EDSDK.PropertySize(Session, Property);
			EDSDK.SetPropertyData(Session, Property, propInfo, Value, 0);
		}

		public string GetText(Property Property)
		{
			string result = Session.ConnectedDevice.Camera.Setting<string>((uint)Property, (ptr) =>
			{
				return Marshal.PtrToStringAnsi(ptr);
			});
			return result;
		}

		public T[] PropertyArray<T>(Property Property) where T : struct
		{
			var desc = EDSDK.PropertyDescription(Session, Property);
			var tAry = desc.PropDesc.Take(desc.NumElements).Cast<T>().ToArray();
			return tAry;
		}
	}
}
