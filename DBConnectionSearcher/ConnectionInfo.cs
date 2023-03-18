using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnectionSearcher
{
	public class ConnectionInfo
	{
		public ConnectionInfo()
		{
			Name = String.Empty;
			Server = String.Empty;
			TableName = String.Empty;
		}

		public string Name { get; set; }

		public string Server { get; set; }

		public string TableName { get; set; }
	}
}
