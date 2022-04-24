using System;
using System.Collections.Generic;

namespace TravarseTreeOfFolders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Console.ReadLine();
            var filterParameter = Console.ReadLine();
            Predicate<string> predicate = (info) => info.Contains(filterParameter);

            FileSystemVisitor visitor = new FileSystemVisitor(path, predicate);

            //visitor.ProcessStatus += DisplayMessage;

            //void DisplayMessage(string message) => Console.WriteLine("==========" + message + "==========");
            var files = visitor.GetFilesAndFolders(path);

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }


            //Console.WriteLine("Enter Directory");
            //string input = Console.ReadLine();
            //FileSystemVisitor fsv = new(input);
            //Console.WriteLine("-------------");

            //Console.Write("Enter File name: ");
            //string fileName = Console.ReadLine();
            //FileSystemVisitor fsw = new(input, fileName);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
      
        
    }
}
