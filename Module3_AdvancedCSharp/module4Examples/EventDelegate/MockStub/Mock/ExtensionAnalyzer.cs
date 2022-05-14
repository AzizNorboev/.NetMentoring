using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockStub.Mock
{
    public class ExtensionAnalyzer
    {
        public IServiceProvider provider = null;
        public ExtensionAnalyzer(IServiceProvider tmpProvider)
        {
            provider = tmpProvider;
        }

        public void ExtensionCheck(string fileName)
        {
            provider.extensionService(fileName);
        }
    }
}
