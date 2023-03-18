using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct VolumeInfo
	{
		public StorageType StorageType;
		public Access Access;
		public ulong MaxCapacity;
		public ulong FreeSpaceInBytes;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = BaseSizes.MAX_NAME)]
		public string szVolumeLabel;
	}
}
