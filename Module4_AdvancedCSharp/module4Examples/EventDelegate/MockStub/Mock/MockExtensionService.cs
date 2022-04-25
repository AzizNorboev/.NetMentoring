using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStub.Mock
{
    //Mock extenison service provider  
    public class MockExtensionService : IServiceProvider
    {
        public string ErrorMessage = null;
        public void extensionService(string fileName)
        {
            if (fileName.Split('.')[1] != "myType")
            {
                ErrorMessage = "Wrong Type";
            }
        }
    }
}
