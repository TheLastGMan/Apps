using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums.Camera;

namespace EDSdkWrapper.Interop.Response
{
	public class PropertyInfo
	{
		public PropertyInfo(DataType Type, int Length)
		{
			DataType = Type;
			Size = Length;
		}

		public DataType DataType { get; private set; }
		public int Size { get; private set; }
	}
}
