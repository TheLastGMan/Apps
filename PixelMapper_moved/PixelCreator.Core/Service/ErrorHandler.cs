using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public delegate void MessageEventHandler(string Message);
	public delegate void RedrawImageEventHandler();

	public class ErrorHandler
	{
		public static event MessageEventHandler MessageEvent;
		public static void RaiseMessageEvent(string Message)
		{
			if (MessageEvent != null)
				MessageEvent(Message);
		}

		public static event RedrawImageEventHandler RedrawImageEvent;
		public static void RaiseRedrawImageEvent()
		{
			if (RedrawImageEvent != null)
				RedrawImageEvent();
		}
	}
}
