using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestureControl
{
    public static class Extentions
    {
        public static bool IsNull(this object source)
        {
            return source == null;
        }

        public static bool IsNotNull(this object source)
        {
            return source != null;
        }

        public static string SerializeObjectToXML<T>(this T item)
        {
            var xs = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                xs.Serialize(stringWriter, item);
                return stringWriter.ToString();
            }
        }

        public static T DeserializeFromXml<T>(this string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }
    }
}
