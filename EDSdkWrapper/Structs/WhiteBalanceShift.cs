using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct WhiteBalanceShift
	{
		/// <summary>
		/// 9 to -9 (+ towards Amber and - towards blue)
		/// 0x7FFFFFFF means invalid value
		/// </summary>
		public int AmberBlue;

		/// <summary>
		/// 9 to -9 (+ towards Magenta and - towards Green)
		/// 0x7FFFFFFF means invalid value
		/// </summary>
		public int MagentaGreen;
	}
}
