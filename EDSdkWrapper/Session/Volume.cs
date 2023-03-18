using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session
{
	public class Volume : IDisposable
	{
		public IntPtr Reference { get; private set; }
		public VolumeInfo Info { get; internal set; }

		public Volume(IntPtr Reference)
		{
			this.Reference = Reference;
		}
		~Volume()
		{
			Dispose();
		}

		public void Dispose()
		{
			if(Reference != IntPtr.Zero)
				EDSDK.Release(Reference);
		}

		public IList<Directory> Directories
		{
			get
			{
				var dirs = new List<Directory>();

				int count = EDSDK.GetChildCount(Reference);
				while (--count >= 0)
				{
					var dir = new Directory(EDSDK.GetChildAtIndex(Reference, count));
					dir.Info = EDSDK.GetDirectoryItemInfo(dir);
					dirs.Add(dir);
				}
				dirs.Reverse();

				return dirs;
			}
		}
	}
}
