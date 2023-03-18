using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Session.Imaging
{
	public class Image : IDisposable
	{
		public Directory Directory { get; private set; }
		public DirectoryItemInfo Item { get; private set; }
		public IntPtr Reference { get; private set; }

		public Image(Directory Directory, DirectoryItemInfo Item)
		{
			if (Item.IsFolder)
				throw new ArgumentException("Item is not a file");
			this.Item = Item;
			this.Directory = Directory;
		}
		~Image()
		{
			Dispose();
		}

		public void Dispose()
		{
			EDSDK.Release(Reference);
			EDSDK.Release(Directory.Reference);
			ImgDat.Dispose();
		}

		private ImageData ImgDat;
		/// <summary>
		/// WARNING!!! - Image processing must be done on the host computer so extra time will be added while this happens the first time for each file.
		/// </summary>
		public ImageData Info
		{
			get
			{
				if (ImgDat == null)
				{
					Reference = EDSDK.CreateFileStream(Item, FileCreateDisposition.CreateAlways, Access.Read | Access.Write);
					EDSDK.Download(Directory, Item, Reference);
					EDSDK.DownloadComplete(Directory);
					ImgDat = new ImageData(this);
					EDSDK.Release(Reference);
				}
				return ImgDat;
			}
		}

	}
}
