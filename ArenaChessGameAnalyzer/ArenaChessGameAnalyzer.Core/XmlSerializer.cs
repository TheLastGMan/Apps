using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaChessGameAnalyzer.Core
{
    public class XmlSerializer
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
            var ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            ser.Serialize(stream, obj);
        }
    }
}
