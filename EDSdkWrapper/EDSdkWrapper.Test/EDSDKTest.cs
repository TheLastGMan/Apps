using System;
using EDSdkWrapper.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class EDSDKTest
	{
		[TestMethod]
		public void QuickInit()
		{
			try
			{
				EDSDK.InitializeSDK();
				EDSDK.TerminateSDK();
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
