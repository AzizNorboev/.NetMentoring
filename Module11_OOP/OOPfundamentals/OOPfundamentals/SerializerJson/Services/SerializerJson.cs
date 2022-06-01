using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SerializerJson.Interfaces;
using System.IO;

namespace SerializerJson.Services
{
    public class SerializerJson<T> : ISerializerJson<T> where T : class
    {
        private string fileName;
        private JsonSerializer formatter = new();

        public SerializerJson(T item, string fileName)
        {
            this.fileName = fileName;
        }

        public SerializerJson()
        {
        }

        public void Serialize(T item, string jsonObjects)
        {
            using (var fileStream = new StreamWriter(jsonObjects))
            {
                using (var jsonWriter = new JsonTextWriter(fileStream))
                {
                    formatter.Serialize(jsonWriter, item);
                }
            }
        }

        public T Deserialize(string jsonObjects)
        {
            JObject value = null;

            using (var fileStream = new StreamReader(jsonObjects))
            {
                using (var jsonReader = new JsonTextReader(fileStream))
                {
                    value = (JObject)formatter.Deserialize(jsonReader);
                }
            }

            return (T)value.ToObject(typeof(T));
        }
    }
}
