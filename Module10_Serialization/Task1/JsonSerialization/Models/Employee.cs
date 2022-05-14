using Newtonsoft.Json;
using System;

namespace JsonSerialization.Models
{
    [Serializable]
    public class Employee
    {
        [JsonProperty("employeeName")]
        public string EmployeeName { get; set; }

        public Employee(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public Employee()  {  }
    }
}
