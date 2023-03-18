using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Logging
{
	public class Logger
	{
		public static void Debug(string Message)
		{
			if (Common.Logger != null)
				Common.Logger.Debug(Message);
		}

		public static void Info(string Message)
		{
			if (Common.Logger != null)
				Common.Logger.Info(Message);
		}

		public static void Error(string Message)
		{
			if (Common.Logger != null)
				Common.Logger.Error(Message);
		}
	}
}
