using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace EDSdkWrapper.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Rational
	{
		public int Numerator;
		public uint Denominator;

		public decimal Fraction
		{
			get { return Numerator / (decimal)Denominator; }
		}
	}
}
