using JsonSerialization.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerialization
{
    public static class JsonSerializerService
    {
        public static void ExportJson(string fileName, Department department)
        {
            //Serializes the specified object to a JSON string.
            string serializedDepartment = JsonConvert.SerializeObject(department);

            //writes the specified string to the file
            File.WriteAllText(fileName, serializedDepartment);
        }

        public static Department ImportJson(string fileName)
        {
            string serializedDepartment = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<Department>(serializedDepartment);
        }
    }
}
