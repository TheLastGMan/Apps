using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Session.Properties
{
	internal static class BaseProperty
	{
		internal static T Setting<T>(this BasePointer Ptr, uint PropertyId, Func<IntPtr, T> Parser)
		{
			var info = EDSDK.PropertySize(Ptr, PropertyId);
			IntPtr dataPtr = EDSDK.GetPropertyData(Ptr, PropertyId, info.Size);

			T value = Parser(dataPtr);

			Marshal.FreeHGlobal(dataPtr);
			return value;
		}
	}
}
