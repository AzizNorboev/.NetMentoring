using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravarseTreeOfFolders
{
    public class FileSystemVisitor
    {
        public delegate void Notify(string message);
        public event Notify ProcessStatus;

        private readonly string _root;
        private readonly Predicate<string> _filter = (x) => true;

        private readonly bool _flag = false;

        public FileSystemVisitor(string root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException();
            }

            _root = root;
        }

        public FileSystemVisitor(string root, Predicate<string> filter) : this(root)
        {
            if (filter == null) { throw new ArgumentNullException(nameof(filter)); }
            _filter = filter;
            _flag = true;
        }

        //1
        public virtual IEnumerable<string> GetFilesAndFolders(string root)
        {
            //ProcessStatus?.Invoke("Process Started");
            foreach (var item in VisitFiles(root))
            {
                yield return item;
            }

            foreach (var item in VisitDirectory(root))
            {
                yield return item;
            }
            //ProcessStatus?.Invoke("Process Finished");
        }

        //2
        private List<string> VisitFiles(string root)
        {
            int counter = 0;
            var fileList = new List<string>();

            foreach (var filePath in Directory.EnumerateFiles(root))
            {
                if (_filter(filePath))
                {
                    var file = filePath.Split('\\');
                    fileList.Add(file[file.Length - 1]);
                    counter++;

                    // SimulateSearchAbort();
                }
            }

            //ProcessStatus?.Invoke(GetStatusMessage("file", counter));
            return fileList;
        }
        //4
        private List<string> VisitDirectory(string root)
        {
            int counter = 0;
            var dirList = new List<string>();

            foreach (var subDirectory in Directory.EnumerateDirectories(root))
            {
                var directory = subDirectory.Split('\\');
                if (_filter(directory[directory.Length - 1]))
                {
                    dirList.Add(directory[directory.Length - 1]);
                    counter++;
                    // SimulateSearchAbort();
                }
            }

            //ProcessStatus?.Invoke(GetStatusMessage("folder", counter));
            return dirList;
        }
        //3
        private string GetStatusMessage(string type, int counter)
        {
            string message = String.Empty;

            if (counter == 0)
            {
                message = $"No {type} was found";
            }
            else
            {
                if (type.ToLower() == "file")
                {
                    message = _flag ? "Filtered File Found" : "File Found";
                }
                if (type.ToLower() == "folder")
                {
                    message = _flag ? "Filtered Folder Found" : "Folder Found";
                }
            }

            return message;
        }
    }


        //public class FileSystemVisitor
        //{
        //    public FileSystemVisitor(string root)
        //    {
        //        TraverseTree(root);
        //    }
        //    public FileSystemVisitor(string root, string filter)
        //    {
        //        TraverseTreeFilter(root, filter);
        //    }

        //    public void TraverseTree(string root)
        //    {
        //        // Data structure to hold names of subfolders to be
        //        // examined for files.
        //        Stack<string> dirs = new Stack<string>(20);

        //        if (!System.IO.Directory.Exists(root))
        //        {
        //            throw new ArgumentException();
        //        }
        //        dirs.Push(root);

        //        while (dirs.Count > 0)
        //        {
        //            string currentDir = dirs.Pop();
        //            string[] subDirs;
        //            try
        //            {
        //                subDirs = System.IO.Directory.GetDirectories(currentDir);
        //            }
        //            // An UnauthorizedAccessException exception will be thrown if we do not have
        //            // discovery permission on a folder or file. It may or may not be acceptable
        //            // to ignore the exception and continue enumerating the remaining files and
        //            // folders. It is also possible (but unlikely) that a DirectoryNotFound exception
        //            // will be raised. This will happen if currentDir has been deleted by
        //            // another application or thread after our call to Directory.Exists. The
        //            // choice of which exceptions to catch depends entirely on the specific task
        //            // you are intending to perform and also on how much you know with certainty
        //            // about the systems on which this code will run.
        //            catch (UnauthorizedAccessException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }
        //            catch (System.IO.DirectoryNotFoundException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }

        //            string[] files = null;
        //            try
        //            {
        //                files = System.IO.Directory.GetFiles(currentDir);
        //            }

        //            catch (UnauthorizedAccessException e)
        //            {

        //                Console.WriteLine(e.Message);
        //                continue;
        //            }

        //            catch (System.IO.DirectoryNotFoundException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }
        //            // Perform the required action on each file here.
        //            // Modify this block to perform your required task.
        //            foreach (string file in files)
        //            {
        //                try
        //                {
        //                    // Perform whatever action is required in your scenario.
        //                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
        //                    Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
        //                }
        //                catch (System.IO.FileNotFoundException e)
        //                {
        //                    // If file was deleted by a separate application
        //                    //  or thread since the call to TraverseTree()
        //                    // then just continue.
        //                    Console.WriteLine(e.Message);
        //                    continue;
        //                }
        //            }

        //            // Push the subdirectories onto the stack for traversal.
        //            // This could also be done before handing the files.
        //            foreach (string str in subDirs)
        //                dirs.Push(str);
        //        }
        //    }

        //    public void TraverseTreeFilter(string root, string filter)
        //    {
        //        // Data structure to hold names of subfolders to be
        //        // examined for files.
        //        Stack<string> dirs = new Stack<string>(20);

        //        if (!System.IO.Directory.Exists(root))
        //        {
        //            throw new ArgumentException();
        //        }
        //        dirs.Push(root);

        //        while (dirs.Count > 0)
        //        {
        //            string currentDir = dirs.Pop();
        //            string[] subDirs;
        //            try
        //            {
        //                subDirs = System.IO.Directory.GetDirectories(currentDir);
        //            }
        //            // An UnauthorizedAccessException exception will be thrown if we do not have
        //            // discovery permission on a folder or file. It may or may not be acceptable
        //            // to ignore the exception and continue enumerating the remaining files and
        //            // folders. It is also possible (but unlikely) that a DirectoryNotFound exception
        //            // will be raised. This will happen if currentDir has been deleted by
        //            // another application or thread after our call to Directory.Exists. The
        //            // choice of which exceptions to catch depends entirely on the specific task
        //            // you are intending to perform and also on how much you know with certainty
        //            // about the systems on which this code will run.
        //            catch (UnauthorizedAccessException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }
        //            catch (System.IO.DirectoryNotFoundException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }

        //            string[] files = null;
        //            try
        //            {
        //                files = System.IO.Directory.GetFiles(currentDir);
        //            }

        //            catch (UnauthorizedAccessException e)
        //            {

        //                Console.WriteLine(e.Message);
        //                continue;
        //            }

        //            catch (System.IO.DirectoryNotFoundException e)
        //            {
        //                Console.WriteLine(e.Message);
        //                continue;
        //            }
        //            // Perform the required action on each file here.
        //            // Modify this block to perform your required task.
        //            foreach (string file in files)
        //            {
        //                try
        //                {
        //                    if (file.Contains(filter))
        //                    {
        //                        // Perform whatever action is required in your scenario.
        //                        System.IO.FileInfo fi = new System.IO.FileInfo(file);
        //                        Console.WriteLine("{0}: {1}, {2}", fi.Name, fi.Length, fi.CreationTime);
        //                    }
        //                }
        //                catch (System.IO.FileNotFoundException e)
        //                {
        //                    // If file was deleted by a separate application
        //                    //  or thread since the call to TraverseTree()
        //                    // then just continue.
        //                    Console.WriteLine(e.Message);
        //                    continue;
        //                }
        //            }

        //            // Push the subdirectories onto the stack for traversal.
        //            // This could also be done before handing the files.
        //            foreach (string str in subDirs)
        //                dirs.Push(str);
        //        }
        //    }
        //}
}
