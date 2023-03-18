using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum Status : int
	{
		/// <summary>
		/// Locks the UI
		/// </summary>
		UILock,
		/// <summary>
		/// Unlocks the UI
		/// </summary>
		UIUnLock,
		/// <summary>
		/// Puts the camera in direct transfer mode
		/// </summary>
		EnterDirectTransfer,
		/// <summary>
		/// Ends direct transfer mode
		/// </summary>
		ExitDirectTransfer,
	}
}
