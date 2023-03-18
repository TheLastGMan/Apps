using System;
using EDSdkWrapper.Structs;
using EDSdkWrapper.Terminal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class CameraCommandTest
	{
		private TerminalService _Svc = new TerminalService();

		[TestMethod]
		public void CameraBasicCommands()
		{
			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0];
				var session = cam.Connect();
				EDSDK.SendCommand(session, Enums.Camera.Command.ExtendShutdownTimer);
				EDSDK.SendCommand(session, Enums.Camera.Command.RaiseFlash);
				EDSDK.SendCommand(session, Enums.Camera.Command.LiveViewStart);
				System.Threading.Thread.Sleep(1000);
				EDSDK.SendCommand(session, Enums.Camera.Command.TakePicture);
				System.Threading.Thread.Sleep(5000);
				EDSDK.SendCommand(session, Enums.Camera.Command.LiveViewEnd);
				EDSDK.SendCommand(session, Enums.Camera.Command.BulbStart);
				System.Threading.Thread.Sleep(10000);
				EDSDK.SendCommand(session, Enums.Camera.Command.BulbEnd);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void CameraExtendedCommands()
		{
			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0];
				var session = cam.Connect();
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.OFF);
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.Halfway);
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.Completely);
				System.Threading.Thread.Sleep(5000);
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.OFF);
				System.Threading.Thread.Sleep(2500);
				EDSDK.SendCommand_LiveView_AF(session, Enums.Camera.EvfAf.ON);
				EDSDK.SendCommand_LiveView_WB(session, new Cord() { XPosition = 0, YPosition = 0 });
				EDSDK.SendCommand_LiveView_DriveLens(session, Enums.EvfDriveLens.Far3);
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.Completely);
				EDSDK.SendCommand_Shutter(session, Enums.Camera.ShutterButton.OFF);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void CameraStatus()
		{
			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0];
				var session = cam.Connect();
				EDSDK.SendStatus(session, Enums.Camera.Status.UILock);
				System.Threading.Thread.Sleep(10000);
				EDSDK.SendStatus(session, Enums.Camera.Status.UIUnLock);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
