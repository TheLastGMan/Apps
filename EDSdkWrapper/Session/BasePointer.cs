using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Session
{
	public abstract class BasePointer
	{
		public virtual IntPtr Reference { get; protected set; }
	}
}
