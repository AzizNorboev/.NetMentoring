using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MockStub.Program;

namespace MockStub
{
    public class FileChecker
    {
        IExtensionManager objmanager = null;
        //Default constructor  
        public FileChecker()
        {
            objmanager = new ExtensionManager();
        }
        //parameterized constructor  
        public FileChecker(IExtensionManager tmpManager)
        {
            objmanager = tmpManager;
        }

        public Boolean CheckFile(String FileName)
        {
            return objmanager.CheckExtension(FileName);
        }
    }
}
