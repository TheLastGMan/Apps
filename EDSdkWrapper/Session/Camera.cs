using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Session
{
	public class Camera : BasePointer
	{
		public Camera(IntPtr CameraRef)
		{
			Reference = CameraRef;
		}
	}
}
