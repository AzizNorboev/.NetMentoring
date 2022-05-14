using System;

namespace MockStub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
       

        public class ExtensionManager : IExtensionManager
        {
            public bool CheckExtension(string FileName)
            {
                //Some complex business logic might goes here. May be DB operation or file system handling  
                return false;
            }
        }

 
 

       
    }
}
