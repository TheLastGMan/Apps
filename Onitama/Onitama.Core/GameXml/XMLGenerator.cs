using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Onitama.Core.GameXml
{
    public class XMLGenerator
    {
        public static string Serialize<T>(T obj)
        {
            string xml = String.Empty;
            using (var ms = new MemoryStream())
            {
                SerializeToStream(obj, ms);
                xml = Encoding.UTF8.GetString(ms.ToArray());
            }
            return xml;
        }

        public static void SerializeToStream<T>(T obj, Stream stream)
        {
            var ser = new XmlSerializer(typeof(T));
            ser.Serialize(stream, obj);
        }

        public static T Deserialize<T>(Stream stream)
        {
            var ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(stream);
        }

        public static T Deserialize<T>(string content)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(content), false))
                return Deserialize<T>(ms);
        }
    }
}
