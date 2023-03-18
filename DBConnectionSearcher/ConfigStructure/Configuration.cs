using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DBConnectionSearcher.ConfigStructure
{
	[XmlRoot()]
	public class configuration
	{
		public configuration()
		{
			connectionStrings = new connectionStrings();
		}

		[XmlElement()]
		public connectionStrings connectionStrings { get; set; }
	}
}
