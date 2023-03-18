using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using EDSdkWrapper.Enums;
using EDSdkWrapper.Enums.Camera;
using EDSdkWrapper.Interop.Response;
using EDSdkWrapper.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EDSdkWrapper.Test
{
	[TestClass]
	public class CameraProperties
	{
		private Terminal.TerminalService _Svc = new Terminal.TerminalService();

		[TestMethod]
		public void ValidCameraPropertyDescriptions()
		{
			_Svc.Connect();
			var cam = _Svc.ConnectedCameras[0].Connect();

			var valids = new Dictionary<string, PropertyDesc>();
			for(uint i = 0; i < 0xFFFF; i++)
			{
				try
				{
					var desc = EDSDK.PropertyDescription(cam, (Property)i);
					if(desc.NumElements > 0)
						valids.Add(((Property)i).ToString(), desc);
				}
				catch
				{
					continue;
				}
			}

			string keys = String.Join(Environment.NewLine, valids.Select(f => f.Key + " : " + ((Access)f.Value.Access).ToString() + " : " + f.Value.NumElements.ToString() + " : 0x" + String.Join(", 0x", f.Value.PropDesc.Take(f.Value.NumElements).Select(g => g.ToString("x")))));
			Assert.Inconclusive(keys);
		}

		[TestMethod]
		public void ValidCameraProperties()
		{
			_Svc.Connect();
			var cam = _Svc.ConnectedCameras[0].Connect();

			var valids = new Dictionary<Property, PropertyInfo>();
			for (uint i = 0; i < 0x1FFF; i++)
			{
				try
				{
					var pinfo = EDSDK.PropertySize(cam, (Property)i);
					valids.Add(((Property)i), pinfo);
				}
				catch
				{
					continue;
				}
			}

			string keys = String.Join(Environment.NewLine, valids.Select(f => f.Key.ToString() + " : Type: " + f.Value.DataType.ToString() + " Size : " + f.Value.Size.ToString()));
			Assert.Inconclusive(String.Join(Environment.NewLine, valids));
		}

		[TestMethod]
		public void RetreiveCameraProperty()
		{
			string result = "";
			Property prop = Property.AE_Mode;

			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0].Connect();
				var size = EDSDK.PropertySize(cam, prop);
				IntPtr ptr = EDSDK.GetPropertyData(cam, prop, size);
				var res = (AEMode)Marshal.PtrToStructure(ptr, typeof(uint));
				result = res.ToString();
				Marshal.FreeHGlobal(ptr);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}

			Assert.Inconclusive("\r\n" + prop.ToString() + " = " + result.ToString());
		}

		[TestMethod]
		public void CameraProperties_MultiValuesProperties()
		{
			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0].Connect();
				var sels = cam.Selections;
				bool bp = true;
			}
			catch(Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		public void CameraProperties_SetProperties()
		{
			try
			{
				_Svc.Connect();
				var cam = _Svc.ConnectedCameras[0].Connect();
				cam.Settings.AperatureSize = AperatureSize.F14;
				System.Threading.Thread.Sleep(1000);
				cam.Settings.AperatureSize = AperatureSize.F3p5_1d3;
				bool bp = true;
			}
			catch(Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
