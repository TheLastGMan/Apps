using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper.Interop
{
	public class EDSdkCalls
	{
		//Global
		private const string EDSDK = "EDSDK.dll";

		//Callback Functions
		public delegate EDSDKResponseCode SDKCameraAddedHandler(IntPtr inContext);
		public delegate EDSDKResponseCode SDKPropertyEventHandler(uint inEvent, uint inPropertyID, uint inParam, IntPtr inContext);
		public delegate EDSDKResponseCode SDKObjectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext);
		public delegate EDSDKResponseCode SDKStateEventHandler(StateEvent inEvent, uint inParameter, IntPtr inContext);
		public delegate EDSDKResponseCode SDKProgressCallbackHandler(uint inPercent, IntPtr inContext, ref bool outCancel);

		/// <summary>
		/// Initializes the libraries. When using the EDSDK libraries, you must call this API once before using EDSDK APIs.
		/// </summary>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsInitializeSDK();

		/// <summary>
		/// Terminates use of the libraries. Calling this function releases all resources allocated by the libraries.
		/// </summary>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsTerminateSDK();

		/// <summary>
		/// Increments the reference counter of existing objects
		/// </summary>
		/// <param name="inRef">Objects of all types in the EDSDK can be designated</param>
		/// <returns>Returns a reference counter if successful. For errors, returns 0xFFFFFFFF. The return value is 4 bytes, and the maximum value of the reference counter is 65535</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsRetain(IntPtr inRef);

		/// <summary>
		/// Decrements the reference counter to an object. When the reference counter reaches 0, the object is released.
		/// </summary>
		/// <param name="inRef">Objects of all types in the EDSDK can be designated.</param>
		/// <returns>Returns a reference counter if successful. For errors, returns 0xFFFFFFFF.</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsRelease(IntPtr inRef);

		/// <summary>
		/// Gets the number of child objects of the designated object
		/// </summary>
		/// <returns>EDS Response</returns>
		/// <example>Number of files in a directory</example>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetChildCount(IntPtr inRef, out int Count);

		/// <summary>
		/// Gets an indexed child object of the designated object.
		/// </summary>
		/// <param name="inRef">Designate the parent object of the object to get. You can designate EdsCameraListRef, EdsCameraRef, EdsVolumeRef, or EdsDirectoryItemRef.</param>
		/// <param name="inIndex">Designate the index of the child object list. The index is 0-based, so designate 0 to get the first child object.</param>
		/// <param name="outRef">The indexed child object</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetChildAtIndex(IntPtr inRef, int inIndex, out IntPtr outRef);

		/// <summary>
		/// Gets the parent object of the designated object
		/// </summary>
		/// <param name="inRef">The EdsCameraListRef, EdsCameraRef, EdsVolumeRef, or EdsDirectoryItemRef object.</param>
		/// <param name="outParentRef">Returns a pointer to the variable for receiving the parent object reference</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetParent(IntPtr inRef, out IntPtr outParentRef);


		/// <summary>
		/// Gets camera list objects.
		/// </summary>
		/// <param name="outCameraListRef">list of cameras connected to the host computer</param>
		/// <returns>EDS Response</returns>
		/// <remarks>The reference counter is implicitly 1 for the retrieved camera list. When the object is not needed, you must use EdsRelease to decrease the reference counter</remarks>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetCameraList(out IntPtr outCameraListRef);

		/// <summary>
		/// Gets device information, such as the device name. Because device information of remote cameras is stored on the host computer, you can use this API before the camera object initiates communication (that is, before a session is opened).
		/// </summary>
		/// <param name="inCameraRef">The camera object for which to get device information</param>
		/// <param name="outVeviceInfo"></param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetDeviceInfo(IntPtr inCameraRef, out DeviceInfo outVeviceInfo);

		/// <summary>
		/// Gets volume information for a memory card in the camera
		/// </summary>
		/// <param name="inVolumeRef">Designate the volume object for which to get volume information</param>
		/// <param name="outVolumeInfo">Specifies the pointer to the EdsVolumeInfo structure for receiving the volume information</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetVolumeInfo(IntPtr inVolumeRef, out VolumeInfo outVolumeInfo);

		/// <summary>
		/// Gets information about the directory or file objects on the memory card (volume) in a remote camera.
		/// </summary>
		/// <param name="inDireItemRef">Designate the directory item object.</param>
		/// <param name="outDirItemInfo">Pointer to the DirectoryItemInfo structure for receiving the directory item information</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetDirectoryItemInfo(IntPtr inDireItemRef, out DirectoryItemInfo outDirItemInfo);

		/// <summary>
		/// Establishes a logical connection with a remote camera. Use this API after getting the camera's EdsCamera object.
		/// </summary>
		/// <param name="inCameraRef">Designate the camera object of the camera to connect to.</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsOpenSession(IntPtr inCameraRef);

		/// <summary>
		/// Closes a logical connection with a remote camera.
		/// </summary>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCloseSession(IntPtr inCameraRef);

		/// <summary>
		/// Sends a command such as "Shoot" to a remote camera.
		/// </summary>
		/// <param name="inCameraRef">Only a camera object can be designated.</param>
		/// <param name="inCommand">The command ID to send to the object</param>
		/// <param name="inParam">Specify the x-coordinate in the upper WORD and the y-coordinate in the lower WORD for kEdsCameraCommand_DoClickWBEvf only.</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSendCommand(IntPtr inCameraRef, Command inCommand, uint inParam);

		/// <summary>
		/// Sends a command such as "Shoot" to a remote camera.
		/// </summary>
		/// <param name="inCameraRef">Designate the camera object</param>
		/// <param name="inStatusCommand">Designate the particular mode ID to set the camera to</param>
		/// <param name="inParam">Currently unused. Designate 0.</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSendStatusCommand(IntPtr inCameraRef, Status inStatusCommand, int inParam);
	
		/// <summary>
		/// Sets the remaining HDD capacity on the host computer(excluding the portion from image transfer),as calculated by subtracting the portion from the previous time.
		/// Set a reset flag initially and designate the cluster length and number of free clusters.
		/// Some cameras can display the number of shots left on the camera based on the available disk capacity of the host computer.
		/// For these cameras, after the storage destination is set to the computer,use this API to notify the camera of the available disk capacity of the host computer.
		/// </summary>
		/// <param name="inCameraRef"></param>
		/// <param name="inCapacity"></param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetCapacity(IntPtr inCameraRef, Capacity inCapacity);

		/// <summary>
		/// Gets the byte size and data type of a designated property from a camera object or image object
		/// </summary>
		/// <param name="inRef">Designate either EdsCameraRef or EdsImageRef.</param>
		/// <param name="inPropertyId">Designate the property ID</param>
		/// <param name="inParam">Additional information of the property. Used to designate multiple additional items of information, if the property has such information that can be set or retrieved. For descriptions of values that can be designated for each property, see the description of inParam for EdsGetPropertyData.</param>
		/// <param name="DataType">Returns the property data type. The particular item defined by enum EdsDataType is returned</param>
		/// <param name="outSize">Stores the property size. The data type and value returned varies depending on the property ID</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetPropertySize(IntPtr inRef, uint inPropertyId, int inParam, out DataType DataType, out int outSize);

		/// <summary>
		/// Gets property information from the object designated in inRef.
		/// </summary>
		/// <param name="inRef">Designate the object for which to get properties. The EDSDK objects you can designate are EdsCameraRef, EdsDirectoryItemRef, or EdsImageRef.</param>
		/// <param name="inPropertyID">Designate the property ID.</param>
		/// <param name="inParam">
		/// Designate additional property information. Use additional property information if multiple items of information such as picture styles can be set or retrieved for a property.
		/// Values that can be designated for each property are as follows.</param>
		/// <param name="inPropertySize"></param>
		/// <param name="outPropertyData"></param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetPropertyData(IntPtr inRef, uint inPropertyID, int inParam, int inPropertySize, IntPtr outPropertyData);

		/// <summary>
		/// Sets property data for the object designated in inRef.
		/// </summary>
		/// <param name="inRef">Designate the object for which to set properties. Designate either EdsCameraRef or EdsImageRef</param>
		/// <param name="inPropertyId">Designate the property ID</param>
		/// <param name="inParam">Designate additional property information. Use additional property information if multiple items of information such as picture styles can be set or retrieved for a property. For descriptions of values that can be designated for each property, see the description of inParam for EdsGetPropertyData.</param>
		/// <param name="inPropertySize">Designate the size of the property data in bytes. The data size of each property can be retrieved by means of EdsGetPropertySize.</param>
		/// <param name="inPropertyData">Designate the property data to set</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetPropertyData(IntPtr inRef, uint inPropertyId, int inParam, int inPropertySize, IntPtr inPropertyData);

		/// <summary>
		/// Gets a list of property data that can be set for the object designated in inRef, as well as maximum and minimum values.
		/// This API is intended for only some shooting-related properties
		/// </summary>
		/// <param name="inRef">The target object. Designate EdsCameraRef.</param>
		/// <param name="inPropertyId">Designate a property ID.</param>
		/// <param name="outPropertyDesc"></param>
		/// <returns>Specifies a pointer to the EdsPropertyDesc structure for getting a list of property data that can currently be set in the target object.</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetPropertyDesc(IntPtr inRef, uint inPropertyId, out PropertyDesc outPropertyDesc);

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDeleteDirectoryItem();

		/// <summary>
		/// Formats volumes of memory cards in a camera
		/// </summary>
		/// <param name="inVolumeRef">Designate the volume (memory card) to format</param>
		/// <returns>EDS Response</returns>
		/// <remarks>Be careful to avoid doing this when the camera is not in the right mode. Lock the UI, for example</remarks>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsFormatVolume(IntPtr inVolumeRef);

		/// <summary>
		/// Gets attributes of files on a camera
		/// </summary>
		/// <param name="inDirectoryItemRef">Designate the file object for which to get attributes</param>
		/// <param name="outFileAttribute">Indicates the file attributes</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetAttribute(IntPtr inDirectoryItemRef, out FileAttribute outFileAttribute);

		/// <summary>
		/// Changes attributes of files on a camera.
		/// </summary>
		/// <param name="inDirectoryItemRef">Designate the file object for which to change attributes.</param>
		/// <param name="inFileAttribute">Indicates the file attributes</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetAttribute(IntPtr inDirectoryItemRef, FileAttribute inFileAttribute);

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDownload(IntPtr inDirItemRef, uint inReadSize, IntPtr outStream);

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDownloadComplete(IntPtr inDirItemRef);

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDownloadCancel();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDownloadThumbnail();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateEvfImageRef();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsDownloadEvfImage();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateFileStream(string FileName, FileCreateDisposition FileOption, Access DesiredAccess, out IntPtr Stream);

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateFileStreamEx();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateMemoryStream();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateMemoryStreamFromPointer();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetPointer();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsRead();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsWrite();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSeek();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetPosition();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetLength();

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCopyData();

		/// <summary>
		/// Creates an image object from an image file.
		/// Without modification, stream objects cannot be worked with as images. Thus, when extracting images from image files, you must use this API to create image objects.
		/// The image object created this way can be used to get image information (such as the height and width, number of color components, and resolution), thumbnail image data, and the image data itself.
		/// </summary>
		/// <param name="inStreamRef">Designate the image file (or image data in the memory stream).</param>
		/// <param name="outImageRef">Specifies the pointer to the variable for receiving the image object.</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsCreateImageRef(IntPtr inStreamRef, out IntPtr outImageRef);

		/// <summary>
		/// Gets image information from a designated image object.
		/// Here, image information means the image width and height, number of color components, resolution, and effective image area
		/// </summary>
		/// <param name="inImageRef">Designate the object for which to get image information.</param>
		/// <param name="inImageSource">Of the various image data items in the image file, designate the type of image data representing the information you want to get. Designate the image as defined in Enum EdsImageSource.</param>
		/// <param name="outImageInfo">Stores the image data information designated in inImageSource</param>
		/// <returns>EDS Result</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetImageInfo(IntPtr inImageRef, ImageSource inImageSource, out ImageInfo outImageInfo);

		/// <summary>
		/// Gets designated image data from an image file, in the form of a designated rectangle.
		/// Returns uncompressed results for JPEG compressed images. Additionally, by designating the input/output rectangle, it is possible to get reduced, enlarged, or partial images. However, because images corresponding to the designated output rectangle are always returned by the SDK, the SDK does not take the aspect ratio into account. To maintain the aspect ratio, you must keep the aspect ratio in mind when designating the rectangle
		/// </summary>
		/// <param name="inImageRef">Designate the image object for which to get the image data.</param>
		/// <param name="inImageSource">Designate the type of image data to get from the image file (thumbnail, preview, and so on).
		/// Designate values as defined in Enum EdsImageSource.</param>
		/// <param name="inImageType">
		/// Designate the output image type. Because the output format of EdsGetImage may only be RGB, only
		/// kEdsTargetImageType_RGB or kEdsTargetImageType_RGB16 can be designated.
		/// However, image types exceeding the resolution of inImageSource cannot be designated.
		/// </param>
		/// <param name="inSrcRect">Designate the coordinates and size of the rectangle to be retrieved (processed) from the source image</param>
		/// <param name="inSize">Designate the rectangle size for output.</param>
		/// <param name="outStreamRef">Designate the memory or file stream for output of the image</param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetImage(IntPtr inImageRef, ImageSource inImageSource, TargetImageType inImageType, Rect inSrcRect, Size inSize, out IntPtr outStreamRef);

		#region Events

		/// <summary>
		/// Registers a callback function for when a camera is detected
		/// </summary>
		/// <param name="inCameraAddedHAndler">
		/// Designate the pointer to the callback function called when a camera is detected.
		/// You must implement the callback function registered this way following a prescribed type definition.
		/// The callback function type is defined as follows.
		/// </param>
		/// <param name="inContext">
		/// Designate application information to be passed by means of the callback function. Any data needed for your application can be passed.
		/// In multithreaded environments, the callback function is executed by a thread exclusively for the event. Use it appropriately, as in designating the this pointer to pass data to UI threads
		/// Designate a NULL pointer if it is not needed.
		/// </param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetCameraAddedHandler(SDKCameraAddedHandler inCameraAddedHAndler, IntPtr inContext);

		/// <summary>
		/// Registers a callback function for receiving status change notification events for objects on a remote camera.
		/// Here, object means volumes representing memory cards, files and directories, and shot images stored in memory, in particular.
		/// </summary>
		/// <param name="inCameraRef">Designate the camera object.</param>
		/// <param name="inEvent">
		/// Designate one or all events to be supplemented. To designate all events, use kEdsObjectEvent_All.
		/// For details on events that can be designated, refer to the section on object-related events in the event lists of Asynchronous Events
		/// </param>
		/// <param name="inObjectEventHandler">
		/// Designate the pointer to the callback function for receiving object-related camera events. The callback function registered here is called by the EDSDK when the event is received.
		/// To cancel supplementation of the event designated in the event type, designate NULL in this argument
		/// You must implement the callback function registered this way following a prescribed type definition.
		/// The callback function type for object-related events is defined as follows.
		/// </param>
		/// <param name="inContext">
		/// Designate application information to be passed by means of the callback function. Any data needed for your application can be passed.
		/// In multithreaded environments, the callback function is executed by a thread exclusively for the event. Use it appropriately, as in designating the this pointer to pass data to UI threads. Designate a NULL pointer if it is not needed.
		/// </param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetObjectEventHandler(IntPtr inCameraRef, ObjectEvent inEvent, SDKObjectEventHandler inObjectEventHandler, IntPtr inContext);

		/// <summary>
		/// Registers a callback function for receiving status change notification events for property states on a camera.
		/// </summary>
		/// <param name="inCameraRef">Designate the camera object.</param>
		/// <param name="inEvent">
		/// Designate one or all events to be supplemented. To designate all events, use kEdsPropertyEvent_All.
		/// For details on events that can be designated, refer to the section on property-related events in the event lists of Asynchronous Events.</param>
		/// <param name="inPropertyEventHandler">
		/// Designate the pointer to the callback function for receiving property-related camera events. The callback function registered here is called by the EDSDK when the event is received.
		/// To cancel supplementation of the event designated in the event type, designate NULL in this argument.
		/// You must implement the callback function registered this way following a prescribed type definition.
		/// The callback function type for property-related events is defined as follows.
		/// </param>
		/// <param name="inContext">
		/// Designate application information to be passed by means of the callback function. Any data needed for your application can be passed.
		/// In multithreaded environments, the callback function is executed by a thread exclusively for the event. Use it appropriately, as in designating the this pointer to pass data to UI threads. Designate a NULL pointer if it is not needed.
		/// </param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetPropertyEventHandler(IntPtr inCameraRef, PropertyEvent inEvent, SDKPropertyEventHandler inPropertyEventHandler, IntPtr inContext);

		/// <summary>
		/// Registers a callback function for receiving status change notification events for camera objects
		/// </summary>
		/// <param name="inCameraRef">Designate the camera object.</param>
		/// <param name="inEvent">
		/// Designate one or all events to be supplemented. To designate all events, use kEdsStateEvent_All.
		/// For details on events that can be designated, refer to the section on events related to camera states in the event lists of Asynchronous Events.
		/// </param>
		/// <param name="inPropertyEventHandler">
		/// Designate the pointer to the callback function for receiving property-related camera events. The callback function registered here is called by the EDSDK when the event is received.
		/// To cancel supplementation of the event designated in the event type, designate NULL in this argument.
		/// You must implement the callback function registered this way following a prescribed type definition.
		/// The callback function type for property-related events is defined as follows.
		/// </param>
		/// <param name="inContext">
		/// Designate application information to be passed by means of the callback function. Any data needed for your application can be passed.
		/// In multithreaded environments, the callback function is executed by a thread exclusively for the event. Use it appropriately, as in designating the this pointer to pass data to UI threads. Designate a NULL pointer if it is not needed.
		/// </param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetCameraStateEventHandler(IntPtr inCameraRef, StateEvent inEvent, SDKStateEventHandler inStateEventHandler, IntPtr inContext);

		/// <summary>
		/// Register a progress callback function.
		/// An event is received as notification of progress during processing that takes a relatively long time, such as downloading files from a remote camera.
		/// If you register the callback function, the EDSDK calls the callback function during execution or on completion of the following APIs.
		/// This timing can be used in updating on-screen progress bars, for example.
		/// </summary>
		/// <param name="inRef">
		/// Designate the relevant object.
		/// EdsImageRef or EdsStreamRef are the objects of APIs for which progress callback registration is valid.
		/// </param>
		/// <param name="inProgressFunc">
		/// Designate a pointer to the progress callback function
		/// The progress callback function type is defined as follows.
		/// </param>
		/// <param name="inProgressOption">Options when this callback function is called are defined in Enum EdsProgressOption.</param>
		/// <param name="inContext">
		/// Application information, passed in the argument when the callback function is called.
		/// Any information required for your program may be added.
		/// </param>
		/// <returns>EDS Response</returns>
		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsSetProgressCallback(IntPtr inRef, SDKProgressCallbackHandler inProgressFunc, ProgressOption inProgressOption, IntPtr inContext);

		#endregion

		[STAThread]
		[DllImport(EDSDK)]
		protected extern static SDKResponse EdsGetEvent();
	}
}
