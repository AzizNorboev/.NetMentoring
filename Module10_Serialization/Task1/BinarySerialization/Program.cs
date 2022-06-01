using System;

namespace BinarySerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var department = DepartmentSeeder.GetDepartment();

            BinarySerializerService.ExportBinary(department, "department.bin");
            BinarySerializerService.ImportBinary("department.bin");

            Console.ReadKey();
        }
    }
}
