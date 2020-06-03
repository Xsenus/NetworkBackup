using System.IO;
using System.Xml.Serialization;

namespace NB.Core.Controller
{
    public static class SerializationController<T> where T: class
    {
        public static void Serialize(T data, string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(T));

            using (var file = new FileStream(fileName, FileMode.Create))
            {
                xmlFormatter.Serialize(file, data);
            }
        }

        public static T Deserialize(string fileName)
        {
            var xmlFormatter = new XmlSerializer(typeof(T));

            if (File.Exists(fileName))
            {
                using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    return xmlFormatter.Deserialize(file) as T;
                }
            }

            return default;
        }
    }
}
