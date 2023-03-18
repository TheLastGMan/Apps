using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DirectoryItemInfo
	{
		public uint SizeInBytes;
		public bool IsFolder;
		public uint GroupID;
		public uint Option;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = BaseSizes.MAX_NAME)]
		public string szFileName;

		public uint format;
		public uint dateTime;
	} 
}
