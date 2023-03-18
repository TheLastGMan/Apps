using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Interop;
using EDSdkWrapper.Interop.Response;
using EDSdkWrapper.Session;
using EDSdkWrapper.Session.Imaging;
using EDSdkWrapper.Structs;

namespace EDSdkWrapper
{
	public class EDSDK : EDSdkCalls
	{
		#region SDK Session

		public static void InitializeSDK()
		{
			var result = EdsInitializeSDK();
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "InitializeSDK");
		}

		public static void TerminateSDK()
		{
			var result = EdsTerminateSDK();
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "TerminateSDK");
		}

		#endregion

		#region Low Level Commands

		public static ushort Retain(IntPtr Item)
		{
			var result = EdsRetain(Item);
			if (result.RAW == uint.MaxValue)
				throw new SDKException(result, "Retain");

			return (ushort)result.Code;
		}

		public static ushort Release(IntPtr Item)
		{
			try
			{
				var result = EdsRelease(Item);
				if (result.RAW == uint.MaxValue)
					throw new SDKException(result, "Release");
				return (ushort)result.RAW;
			}
			catch
			{
				//item didn't need releasing
				return 0;
			}
		}

		public static int GetChildCount(IntPtr Item)
		{
			int count;
			var result = EdsGetChildCount(Item, out count);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetChildCount");

			return count;
		}

		public static IntPtr GetChildAtIndex(IntPtr Item, int Index)
		{
			IntPtr childItem;
			var result = EdsGetChildAtIndex(Item, Index, out childItem);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetChildAtIndex");

			return childItem;
		}

		public static IntPtr GetParent(IntPtr Item)
		{
			IntPtr parent;
			var result = EdsGetParent(Item, out parent);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetParent");

			return parent;
		}

		#endregion

		#region Camera Navigation Information

		public static IntPtr GetCameraList()
		{
			IntPtr cameras;
			var result = EdsGetCameraList(out cameras);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetCameraList");

			return cameras;
		}

		public static DeviceInfo GetDeviceInfo(Camera Camera)
		{
			DeviceInfo info;
			var result = EdsGetDeviceInfo(Camera.Reference, out info);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetDeviceInfo");

			return info;
		}

		public static VolumeInfo GetVolumeInfo(Volume Volume)
		{
			VolumeInfo info;
			var result = EdsGetVolumeInfo(Volume.Reference, out info);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetVolumeInfo");

			return info;
		}

		public static DirectoryItemInfo GetDirectoryItemInfo(Directory Directory)
		{
			DirectoryItemInfo info;
			var result = EdsGetDirectoryItemInfo(Directory.Reference, out info);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetDirectoryItemInfo");

			return info;
		}

		#endregion

		#region Camera Session

		public static void OpenSession(CameraSession Session)
		{
			var result = EdsOpenSession(Session.ConnectedDevice.Camera.Reference);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "OpenSession");
		}

		public static void CloseSession(CameraSession Session)
		{
			//try to close and release session, don't error as that would mean it has already been cleared
			EdsCloseSession(Session.ConnectedDevice.Camera.Reference);
			Release(Session.ConnectedDevice.Camera.Reference);
		}

		#endregion

		#region Camera Command

		public static void SendCommand(CameraSession Session, Command Cmd, uint param = 0)
		{
			var result = EdsSendCommand(Session.ConnectedDevice.Camera.Reference, Cmd, param);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendCommand : " + Cmd.ToString());
		}

		public static void SendCommand_Shutter(CameraSession Session, ShutterButton Button)
		{
			var result = EdsSendCommand(Session.ConnectedDevice.Camera.Reference, (Command)CommandLiveView.PressShutterButton, (uint)Button);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendCommand_LiveView_Shutter : " + Button.ToString());
		}

		public static void SendCommand_LiveView_DriveLens(CameraSession Session, EvfDriveLens Mode)
		{
			var result = EdsSendCommand(Session.ConnectedDevice.Camera.Reference, (Command)CommandLiveView.DriveLensEvf, (uint)Mode);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendCommand_LiveView_DriveLens : " + Mode.ToString());
		}

		public static void SendCommand_LiveView_WB(CameraSession Session, Cord XYCordinate)
		{
			var result = EdsSendCommand(Session.ConnectedDevice.Camera.Reference, (Command)CommandLiveView.DoClickWBEvf, XYCordinate.RAW);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendCommand_LiveView_WB");
		}

		public static void SendCommand_LiveView_AF(CameraSession Session, EvfAf Mode)
		{
			var result = EdsSendCommand(Session.ConnectedDevice.Camera.Reference, (Command)CommandLiveView.DoEvfAf, (uint)Mode);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendCommand_LiveView_AF : " + Mode.ToString());
		}

		#endregion

		public static void SendStatus(CameraSession Session, Status Status)
		{
			var result = EdsSendStatusCommand(Session.ConnectedDevice.Camera.Reference, Status, 0);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SendStatus : " + Status.ToString());
		}

		/// <summary>
		/// Notify camera of remaining HDD capacity on host computer
		/// Set a reset flag initially and designate the cluster length and number of free clusters
		/// Some cameras can display the number of shots left on the camera based on the available disk capacity of the host computer.
		/// For these cameras, after the storage destination is set to the computer,use this API to notify the camera of the available disk capacity of the host computer
		/// </summary>
		public static void SetCapacity(CameraSession Session, Capacity Capacity)
		{
			var result = EdsSetCapacity(Session.ConnectedDevice.Camera.Reference, Capacity);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetCapacity");
		}

		#region Property Size

		internal static PropertyInfo PropertySize(BasePointer Ptr, uint PropertyId)
		{
			DataType Type;
			int Size;

			var result = EdsGetPropertySize(Ptr.Reference, PropertyId, 0, out Type, out Size);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "PropertySize : " + PropertyId.ToString());

			var output = new PropertyInfo(Type, Size);
			return output;
		}

		public static PropertyInfo PropertySize(CameraSession Session, Property Property)
		{
			return PropertySize(Session.ConnectedDevice.Camera, (uint)Property);
		}

		public static PropertyInfo PropertySize(ImageData Image, Property Property)
		{
			return PropertySize(Image, (uint)Property);
		}

		#endregion

		#region Get Property Value

		internal static IntPtr GetPropertyData(BasePointer Ptr, uint PropertyId, int Size)
		{
			IntPtr ptr = Marshal.AllocHGlobal((int)Size);
			var result = EdsGetPropertyData(Ptr.Reference, PropertyId, 0, Size, ptr);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "GetPropertyData : " + PropertyId.ToString());

			return ptr;
		}

		public static IntPtr GetPropertyData(CameraSession Session, Property Property, PropertyInfo Info)
		{
			return GetPropertyData(Session.ConnectedDevice.Camera, (uint)Property, Info.Size);
		}

		public static IntPtr GetPropertyData(ImageData Image, Property Property, PropertyInfo Info)
		{
			return GetPropertyData(Image, (uint)Property, Info.Size);
		}

		/*
		public static IntPtr GetPropertyData(DirInfoRef DirInfo, Property Property, PropertyInfo Info)
		{

		}*/

		#endregion

		#region Set Property Value

		private static IntPtr IntRef(uint Value)
		{
			IntPtr dataRef = Marshal.AllocHGlobal(sizeof(uint));
			Marshal.WriteInt32(dataRef, (int)Value);
			return dataRef;
		}

		internal static SDKResponse SetPropertyData(IntPtr Ptr, uint PropertyId, int Size, IntPtr Data, int Param = 0)
		{
			var result = EdsSetPropertyData(Ptr, PropertyId, Param, Size, Data);
			Marshal.Release(Data);
			return result;
		}

		public static void SetPropertyData(CameraSession Session, Property Property, PropertyInfo Info, uint Data, int Param = 0)
		{
			IntPtr dataRef = IntRef(Data);
			var result = SetPropertyData(Session.ConnectedDevice.Camera.Reference, (uint)Property, Info.Size, dataRef, Param);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetPropertyData : " + Property.ToString());
		}

		public static void SetPropertyData(ImageData ImageRef, Property Property, PropertyInfo Info, uint Data, int Param = 0)
		{
			IntPtr dataRef = IntRef(Data);
			var result = SetPropertyData(ImageRef.Reference, (uint)Property, Info.Size, dataRef, Param);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetPropertyData : " + Property.ToString());
		}

		#endregion

		public static PropertyDesc PropertyDescription(CameraSession Session, Property Property)
		{
			PropertyDesc desc;
			var result = EdsGetPropertyDesc(Session.ConnectedDevice.Camera.Reference, (uint)Property, out desc);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "PropertyDescription");

			return desc;
		}


		//More Methods
		//------------

		public static IntPtr CreateImageRef(Image ImageInfo)
		{
			IntPtr stream;
			var result = EdsCreateImageRef(ImageInfo.Reference, out stream);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "CreateImageRef");

			return stream;
		}

		public static IntPtr CreateFileStream(DirectoryItemInfo FileInfo, FileCreateDisposition FileOption = FileCreateDisposition.OpenExisting, Access RequestedAccess = Access.Read)
		{
			IntPtr stream;
			var result = EdsCreateFileStream(FileInfo.szFileName, FileOption, RequestedAccess, out stream);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "CreateFileStream : " + FileInfo.szFileName);

			return stream;
		}

		public static void Download(Directory Directory, DirectoryItemInfo FileInfo, IntPtr Stream)
		{
			var result = EdsDownload(Directory.Reference, FileInfo.SizeInBytes, Stream);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "Download");
		}

		public static void DownloadComplete(Directory Directory)
		{
			var result = EdsDownloadComplete(Directory.Reference);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "DownloadComplete");
		}

		//Events
		public static void SetCameraAddedHandler(SDKCameraAddedHandler Handler, IntPtr Context)
		{
			var result = EdsSetCameraAddedHandler(Handler, Context);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetCameraAddedHandler");
		}

		public static void SetStateChangedHandler(SDKStateEventHandler Handler, Camera Camera, IntPtr Context, StateEvent Event = StateEvent.All)
		{
			var result = EdsSetCameraStateEventHandler(Camera.Reference, Event, Handler, Context);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetStateChangedHandler");
		}

		public static void SetPropertyChangedHandler(SDKPropertyEventHandler Handler, Camera Camera, IntPtr Context, PropertyEvent Event = PropertyEvent.All)
		{
			var result = EdsSetPropertyEventHandler(Camera.Reference, Event, Handler, Context);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetPropertyChangedHandler");
		}

		public static void SetObjectChangedHandler(SDKObjectEventHandler Handler, Camera Camera, IntPtr Context, ObjectEvent Event = ObjectEvent.All)
		{
			var result = EdsSetObjectEventHandler(Camera.Reference, Event, Handler, Context);
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "SetObjectChangedHandler");
		}

		[STAThread]
		public static void CheckForEvent()
		{
			var result = EdsGetEvent();
			if (result.Code != EDSDKResponseCode.OK)
				throw new SDKException(result, "CheckForEvent");
		}
	}
}
