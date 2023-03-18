using System;
using System.Collections.Generic;
using System.Linq;
using EDSdkWrapper.Session;
using EDSdkWrapper.Session.Imaging;
using EDSdkWrapper.Structs;
using EDSdkWrapper.Terminal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class CameraNavigationTest
	{
		private TerminalService _Svc = new TerminalService();

		[TestMethod]
		public void CameraSession()
		{
			try
			{
				_Svc.Connect();
				var session = _Svc.ConnectedCameras[0].Connect();
				session.Close();
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void CameraVolumes()
		{
			IList<Volume> volumes = null;

			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0];
				var session = cam.Connect();
				volumes = session.Volumes;
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(volumes, "Camera Volumes Not Set");
			Assert.IsTrue(volumes.Any(), "No Volumes Detected");
		}

		[TestMethod]
		public void CameraDirectoryFiles()
		{
			IList<Directory> directories = null;
			IList<Image> files = null;

			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0];
				var session = cam.Connect();
				var volumes = session.Volumes;
				var volume = volumes[0];			//select first volume [SD-Card]
				directories = volume.Directories;	//DCIM and MISC
				var directory = directories[0].Folders[0];	//X00CANON Folders
				files = directory.Files;
				var info = files[1].Info;
				var i2 = files[2].Info;
				var i3 = files[1].Info;

				var prop = info.Settings.FocusInfo;
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.IsNotNull(directories, "Camera directories not set");
			Assert.IsTrue(directories.Any(), "Camera has no directories");
			Assert.IsNotNull(files, "Camera files not set");
			Assert.IsTrue(files.Any(), "Camrea has no files");
		}
	}
}
