using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    [Serializable]
    public class Department : ICloneable
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public object Clone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.GetType().IsSerializable)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, this);
                    stream.Position = 0;
                    return formatter.Deserialize(stream);
                }
                return null;
            }
        }

        public override string ToString()
        {
            return $"DepartmentName: {this.DepartmentName}" + Environment.NewLine +
                $"Employees: {string.Join(", ", this.Employees)}";
        }
    }
}
