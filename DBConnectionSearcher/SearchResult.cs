using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnectionSearcher
{
	public class SearchResult
	{
		public SearchResult()
		{
			FullFileName = String.Empty;
			ConnectionStrings = new List<ConnectionInfo>();
		}

		public string FullFileName { get; set; }

		public List<ConnectionInfo> ConnectionStrings { get; set; }
	}
}
