using BinarySerialization.Models;
using System.Collections.Generic;

namespace BinarySerialization
{
    public static class DepartmentSeeder
    {
        public static Department GetDepartment()
        {
            return new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Aziz" },
                    new Employee { EmployeeName = "Petr" }
                }
            };
        }
    }
}
