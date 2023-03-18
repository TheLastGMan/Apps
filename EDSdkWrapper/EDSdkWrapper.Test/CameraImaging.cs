using System;
using System.Collections.Generic;
using System.Linq;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Interop.Response;
using EDSdkWrapper.Structs;
using EDSdkWrapper.Terminal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class CameraImaging
	{
		private TerminalService _Svc = new TerminalService();

		[TestMethod]
		public void CameraImaging_ValidProperties()
		{
			_Svc.Connect();
			var fileInfo = _Svc.ConnectedCameras[0].Connect().Volumes[0].Directories[0].Folders[0].Files[0].Info;

			var valids = new Dictionary<Property, PropertyInfo>();
			for (uint i = 0; i < 0x1FFF; i++)
			{
				try
				{
					var pinfo = EDSDK.PropertySize(fileInfo, (Property)i);
					valids.Add(((Property)i), pinfo);
				}
				catch
				{
					continue;
				}
			}

			string keys = String.Join(Environment.NewLine, valids.Select(f => f.Key.ToString() + " : Type: " + f.Value.DataType.ToString() + " : Size : " + f.Value.Size.ToString()));
			Assert.Inconclusive(String.Join(Environment.NewLine, valids));
		}
	}
}
