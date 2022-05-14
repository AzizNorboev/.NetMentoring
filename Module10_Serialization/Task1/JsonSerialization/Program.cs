using JsonSerialization.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace JsonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = DepartmentSeeder.GetDepartment();
            JsonSerializerService.ExportJson("Department.json", department);
            var result = JsonSerializerService.ImportJson("Department.json");

            Console.WriteLine($"Department name: {result.DepartmentName}, Num of Employees: {result.Employees.Count}");
            Console.ReadLine();
        }   
    }
}
