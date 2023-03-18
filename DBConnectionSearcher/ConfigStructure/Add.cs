using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DBConnectionSearcher.ConfigStructure
{
	public class add
	{
		public add()
		{
			name = String.Empty;
			connectionString = String.Empty;
			providerName = String.Empty;
		}

		[XmlAttribute()]
		public string name { get; set; }

		[XmlAttribute()]
		public string connectionString { get; set; }

		[XmlAttribute()]
		public string providerName { get; set; }

		[XmlElement()]
		public string trial { get; set; }
	}
}
