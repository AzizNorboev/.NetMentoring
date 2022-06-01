using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    [Serializable]
    public class Employee
    {
        public string EmployeeName { get; set; }

        public override string ToString()
        {
            return this.EmployeeName;
        }
    }
}
