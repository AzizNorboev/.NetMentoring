using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
                {
                 new Employee { EmployeeName = "Aziz" },
                 new Employee { EmployeeName = "Petr" }
                }           
            };

            Department clonedDepartment = (Department)department.Clone();

            if(clonedDepartment != null)
            {
                Console.WriteLine(clonedDepartment.DepartmentName);
                foreach(var item in clonedDepartment.Employees)
                {
                    Console.WriteLine(item.EmployeeName);
                }
            }
            else
            {
                Console.WriteLine("clonedDepartment is null");
            }
            Console.ReadLine();
        }
    }
}
