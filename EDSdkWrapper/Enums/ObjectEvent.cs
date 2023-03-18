using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums
{
	public enum ObjectEvent : int
	{
		All	= 0x200,
		VolumeInfoChanged = 0x201,
		VolumeUpdateItems = 0x202,
		FolderUpdateItems = 0x203,
		DirectoryItemCreated = 0x204,
		DirectoryItemRemoved = 0x205,
		DirectoryItemInfoChanged = 0x206,
		DirectoryItemContentChanged = 0x207,
		DirectoryItemRequestTransfer = 0x208,
		DirectoryItemRequestTransferDT = 0x209,
		DirectoryItemCancelTransferDT = 0x20A,
		VolumeRemoved = 0x20D
	}
}
