using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ampf.Logging;

namespace ERMService
{
	class NLogging : Core.Logging.ILogger
	{
		private OperationsLogger _Logger;

		public NLogging()
		{
			_Logger = new OperationsLogger(typeof(NLogging));
		}

		public void Debug(string Message)
		{
			_Logger.Debug(Message);
		}

		public void Info(string Message)
		{
			_Logger.Info(Message);
		}

		public void Error(string Message)
		{
			_Logger.Error(Message);
		}
	}
}
