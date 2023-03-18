using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Enums.Camera
{
	public enum Command : int
	{
		/// <summary>
		/// Requests the camera to shoot
		/// For EOS 50D or EOS 5D Mark II or later cameras use command
		/// CameraCommand_PressShutterButton
		/// </summary>
		TakePicture			= 0,
		/// <summary>
		/// Requests to extend the time for the auto shut-off timer. (Keep Device On)
		/// </summary>
		ExtendShutdownTimer	= 1,
		/// <summary>
		/// Starts bulb shooting
		/// Lock the UI before bulb shooting
		/// An exposure time event is generated at the start of bulb shooting. (kEdsStateEvent_BulbExposureTime)
		/// For EOS 50D or EOS 5D Mark II or later cameras use command CameraCommand_PressShutterButton
		/// </summary>
		BulbStart			= 2,
		/// <summary>
		/// Ends bulb shooting
		/// Lock the UI before bulb shooting
		/// An exposure time event is generated at the start of bulb shooting. (kEdsStateEvent_BulbExposureTime)
		/// For EOS 50D or EOS 5D Mark II or later cameras use command CameraCommand_PressShutterButton
		/// </summary>
		BulbEnd				= 3,

		//Additional Command Found for T5i (not in SDK Manual)
		RaiseFlash			= 262,
		LiveViewStart		= 263,
		LiveViewEnd			= 264
	}

	public enum CommandLiveView : int
	{
		/// <summary>
		/// Controls shutter button operations
		/// </summary>
		PressShutterButton	= 4,
		/// <summary>
		/// Drives the lens and adjusts focus
		/// </summary>
		DriveLensEvf		= 0x103,
		/// <summary>
		/// Adjusts the white balance of the live view image at the specified position
		/// </summary>
		DoClickWBEvf		= 0x104,
		/// <summary>
		/// Controls auto focus in live view mode.
		/// </summary>
		DoEvfAf				= 0x102
	}
}
