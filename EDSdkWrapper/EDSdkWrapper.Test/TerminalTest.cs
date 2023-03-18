using System;
using System.Collections.Generic;
using System.Linq;
using EDSdkWrapper.Session;
using EDSdkWrapper.Structs;
using EDSdkWrapper.Terminal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class TerminalTest
	{
		private TerminalService _Svc = new TerminalService();

		[TestMethod]
		public void TerminalConnect()
		{
			try
			{
				_Svc.Connect();
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void TerminalCameras()
		{
			IList<ConnectedCamera> cameras = null;
			try
			{
				_Svc.Connect();
				cameras = _Svc.ConnectedCameras;
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			//Assert
			Assert.IsTrue(cameras != null, "Cameras not assigned a value");
			if (!cameras.Any())
				Assert.Inconclusive("No Cameras Found, can not fully test");
			Assert.IsTrue(cameras.Any(), "No cameras found");
		}
	}
}
