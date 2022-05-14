using System;
using System.Runtime.Serialization;

namespace Task2
{
    [Serializable]
    public class Student : ISerializable
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public Student(int studentId, string studentName)
        {
            StudentId = studentId;
            StudentName = studentName;
        }

        /// <summary>
        /// The special constructor is used to deserialize values
        /// </summary>
        /// <param name="serializationInfo"></param>
        /// <param name="streamingContext"></param>
        public Student(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            StudentId = (int)serializationInfo.GetValue(
                name: "StudentId",
                type: typeof(int));

            StudentName = (string)serializationInfo.GetValue(
                name: "StudentName",
                type: typeof(string));
        }

        /// <summary>
        /// This method is to serialize data
        /// The method is called on serialization
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StudentId", StudentId);
            info.AddValue("StudentName", StudentName);
        }

        public override string ToString()
        {
            return $"StudentId: {StudentId}, Name: {StudentName}";
        }
    }
}
