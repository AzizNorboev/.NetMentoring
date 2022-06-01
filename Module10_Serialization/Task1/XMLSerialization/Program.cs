using System;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = DepartmentSeeder.GetDepartment();
            XMLSerializerService.ExportXML("Department.xml", department);
            var result = XMLSerializerService.Import("Department.xml");

            Console.WriteLine($"Department name: {result.DepartmentName}, Num of Employees: {result.Employees.Count}");
            Console.ReadLine();
        }           
    }
}
