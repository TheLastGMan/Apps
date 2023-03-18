using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DBConnectionSearcher.ConfigStructure
{
	public class connectionStrings
	{
		public connectionStrings()
		{
			Connections = new List<add>();
		}

		[XmlElement("add")]
		public List<add> Connections { get; set; }
	}
}
