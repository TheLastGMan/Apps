using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace RPGCor.USPS
{
    public static class XmlParser
    {
        public static string Serialize<T>(T obj)
        where T : class
        {
            var ser = new XmlSerializer(obj.GetType(), "");
            using (var ms = new MemoryStream())
            {
                ser.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                string content = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Length);
                content = content.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");
                return content;
            }
        }

        public static T DeSerialize<T>(string content)
        where T : class
        {
            var ser = new XmlSerializer(typeof(T), "");
            using (var ms = new MemoryStream())
            {
                var contentArray = Encoding.UTF8.GetBytes(content);
                ms.Write(contentArray, 0, contentArray.Length);
                ms.Seek(0, SeekOrigin.Begin);
                T res = ser.Deserialize(ms) as T;
                return res;
            }
        }
    }
}
