using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonSerialization.Models
{
    [Serializable]
    public class Department
    {
        [JsonProperty("departmentName")]
        public string DepartmentName { get; set; }
        [JsonProperty("employees")]
        public List<Employee> Employees { get; set; }
    }
}
