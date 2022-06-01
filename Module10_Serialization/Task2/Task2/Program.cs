using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(10881, "Aziz");

            MyBinarySerialization binarySerializer =
                new MyBinarySerialization(path: "student.bin");

            binarySerializer.Serialize(student);

            Student deserializedStudent =
                binarySerializer.Deserialize();

            Console.WriteLine(deserializedStudent);
        }
    }
}
