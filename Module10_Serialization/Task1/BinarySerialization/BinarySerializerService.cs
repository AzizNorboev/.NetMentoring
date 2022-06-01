using BinarySerialization.Models;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    static class BinarySerializerService
    {
        public static void ExportBinary(Department department, string fileName)
        {
            //Create the stream to add object into it.  
            Stream ms = File.OpenWrite(fileName);
            //Format the object as Binary  

            BinaryFormatter formatter = new BinaryFormatter();
            //It serialize the employee object  
            formatter.Serialize(ms, department);
            ms.Flush();
            ms.Close();
            ms.Dispose();
        }

        public static void ImportBinary(string filename)
        {
            //Format the object as Binary  
            BinaryFormatter formatter = new BinaryFormatter();

            //Reading the file from the server  
            FileStream fs = File.Open(filename, FileMode.Open);

            object obj = formatter.Deserialize(fs);
            Department dep = (Department)obj;
            fs.Flush();
            fs.Close();
            fs.Dispose();

            Console.WriteLine($"{dep.DepartmentName}, Num of employees {dep.Employees.Count}");
        }
    }
}
