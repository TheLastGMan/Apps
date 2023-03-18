using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EDSdkWrapper.Session.Imaging;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session
{
	public class Directory : IDisposable
	{
		public Directory(IntPtr Reference)
		{
			this.Reference = Reference;
		}
		~Directory()
		{
			Dispose();
		}

		public IntPtr Reference { get; private set; }
		public DirectoryItemInfo Info { get; internal set; }

		public void Dispose()
		{
			if (Reference != IntPtr.Zero)
				EDSDK.Release(Reference);
		}

		public IList<Directory> Folders
		{
			get
			{
				var folders = new List<Directory>();

				int count = EDSDK.GetChildCount(Reference);
				while(--count >= 0)
				{
					var itm = EDSDK.GetChildAtIndex(Reference, count);
					var dir = new Directory(itm);
					var itmInfo = EDSDK.GetDirectoryItemInfo(dir);
					dir.Info = itmInfo;
					if (itmInfo.IsFolder)
						folders.Add(dir);
				}
				folders.Reverse();

				return folders;
			}
		}

		public IList<Image> Files
		{
			get
			{
				var files = new List<Image>();

				int count = EDSDK.GetChildCount(Reference);
				while(--count >= 0)
				{
					var itm = EDSDK.GetChildAtIndex(Reference, count);
					var dir = new Directory(itm);
					var itmInfo = EDSDK.GetDirectoryItemInfo(dir);
					if (!itmInfo.IsFolder)
					{
						var file = new Image(dir, itmInfo);
						files.Add(file);
					}
				}
				files.Reverse();

				return files;
			}
		}
	}
}
