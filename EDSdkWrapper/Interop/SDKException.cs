using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDSdkWrapper.Interop
{
	[Serializable]
	public class SDKException : Exception
	{
		private SDKResponse _Response;

		public SDKException(SDKResponse Response, string Message)
			: base(Message)
		{
			_Response = Response;
		}

		public SDKException(SDKResponse Response, string Message, Exception InnerException)
			: base(Message, InnerException)
		{
			_Response = Response;
		}

		public override string Message
		{
			get
			{
				return "SDK Error: " + _Response.Code.ToString() + " : " + base.Message;
			}
		}
	}
}
