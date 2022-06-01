using System;
using System.Collections.Generic;
using System.Text.Json;

namespace BinarySerialization.Models
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
