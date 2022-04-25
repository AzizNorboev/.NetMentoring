using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MockStub.Program;

namespace MockStub
{
    //Stub implementation to bypass actual Extension manager class. 
    public class StubExtensionManager : IExtensionManager
    {
        public bool CheckExtension(string FileName)
        {
            return true;
        }
    }
}
