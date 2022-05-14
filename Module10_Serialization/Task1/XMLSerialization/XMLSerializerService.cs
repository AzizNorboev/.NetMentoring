using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLSerialization.Models;

namespace XMLSerialization
{
    public static class XMLSerializerService
    {
        public static void ExportXML(string filename, Department department)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Department));
            TextWriter writer = new StreamWriter(filename);

            serializer.Serialize(writer, department);
            writer.Close();
        }
        public static Department Import(string path)
        {
            using (FileStream stream = new FileStream(
                path: path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                XmlSerializer xmlSerializer =
                    new XmlSerializer(typeof(Department));

                return (Department)xmlSerializer.Deserialize(stream);
            }
        }
    }
}
