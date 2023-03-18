using System;
using EDSdkWrapper.Enums.Camera;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class zRamdon
	{
		[TestMethod]
		public void RandomTest()
		{
			for(byte i = 0; i < 4; i++)
			{
				Status s = (Status)i;
				if (s >= 0)
					continue;
				continue;
			}

			Assert.Inconclusive("Random Test, No pass scenario");
		}
	}
}
