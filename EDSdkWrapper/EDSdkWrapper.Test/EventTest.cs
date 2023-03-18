using System;
using EDSdkWrapper.Terminal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class EventTest
	{
		private Terminal.TerminalService _Svc = new Terminal.TerminalService();

		[TestMethod]
		public void EventTest_Connected()
		{
			//arrange
			bool detectedConnection = false;
			_Svc.CameraAdded += delegate()
			{
				detectedConnection = true;
			};

			//act
			_Svc.Connect();
			for (int i = 0; i < 2000; i++)
			{
				//EDSDK.CheckForEvent();
				System.Threading.Thread.Sleep(10);
			}

			//assert
			Assert.IsTrue(detectedConnection, "Camera addition not detected");
		}
	}
}
