using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2
{
    public class MyBinarySerialization : ISerializer<Student>
    {
        private readonly string _path;

        public MyBinarySerialization(string path)
        {
            _path = path;
        }

        public void Serialize(Student student)
        {
            using (FileStream stream = new FileStream(
                path: _path,
                mode: FileMode.Create,
                access: FileAccess.Write))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(stream, student);
            }
        }

        public Student Deserialize()
        {
            using (FileStream stream = new FileStream(
                path: _path,
                mode: FileMode.Open,
                access: FileAccess.Read))
            {
                IFormatter binaryFormatter = new BinaryFormatter();

                return (Student)binaryFormatter.Deserialize(stream);
            }
        }

    }
}
