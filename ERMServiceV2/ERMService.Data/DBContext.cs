using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERMService.Data
{
	public class DBContext
	{
		//public static string ConnectionString { get; set; }

		public static ERMReportingConnection NewContext
		{
			get
			{
				var ctx = new ERMReportingConnection();
				//ctx.Database.Connection.ConnectionString = ConnectionString;
				return ctx;
			}
		}
	}
}
