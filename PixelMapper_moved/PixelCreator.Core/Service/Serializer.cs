using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PixelMapper.Core
{
	public class Serializer
	{
		public string SerializeXML<T>(T input) where T : class
		{
			var ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
			string output = String.Empty;
			using(var ms = new System.IO.MemoryStream())
			{
				ser.Serialize(ms, input);
				ms.Position = 0;
				output = System.Text.UTF8Encoding.UTF8.GetString(ms.ToArray());
			}
			return output;
		}

		public T DeserializeXML<T>(string content) where T : class
		{
			var des = new System.Xml.Serialization.XmlSerializer(typeof(T));
			T output = null;
			using(var ms = new System.IO.MemoryStream())
			{
				ms.Write(System.Text.UTF8Encoding.UTF8.GetBytes(content), 0, content.Length);
				ms.Position = 0;
				using(var xrdr = System.Xml.XmlReader.Create(ms))
				{
					if(des.CanDeserialize(xrdr))
						output = des.Deserialize(xrdr) as T;
					else
						throw new Exception("Can not deserialize xml");
				}
			}
			return output;
		}
	}
}
