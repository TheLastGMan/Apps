using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Session.Imaging;

namespace EDSdkWrapper.Session.Properties
{
	public class BaseImageProperty
	{
		private ImageData Image;

		public BaseImageProperty(ImageData Image)
		{
			this.Image = Image;
		}

		public T GetSetting<T>(Property Property) where T : struct
		{
			T result = Image.Setting<T>((uint)Property, (ptr) =>
			{
				Type type = typeof(T);
				if (type.IsEnum)
					type = Enum.GetUnderlyingType(type);
				return (T)Marshal.PtrToStructure(ptr, type);
			});
			return result;
		}

		public string GetText(Property Property)
		{
			string result = Image.Setting<string>((uint)Property, (ptr) =>
			{
				return Marshal.PtrToStringAnsi(ptr);
			});
			return result;
		}
	}
}
