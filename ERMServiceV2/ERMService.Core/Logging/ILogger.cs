using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Core.Logging
{
	public interface ILogger
	{
		void Debug(string Message);

		void Info(string Message);

		void Error(string Message);
	}
}
