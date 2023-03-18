using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerScriptFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            //validate input
            switch(args.Length)
            {
                case 0:
                    Console.WriteLine("Missing argument: RootFolder, OutputFile, SearchItems");
                    return;
                case 1:
                    Console.WriteLine("Missing Argument: FindString, SearchItems");
                    return;
                case 2:
                    Console.WriteLine("Missing Argument: SearchItems");
                    return;
                default:
                    break;
            }

            //validate directory
            DirectoryInfo rDir = new DirectoryInfo(args[0]);
            if(!rDir.Exists)
            {
                Console.WriteLine("Root Folder was not found: " + rDir.FullName);
                return;
            }

            //search files for search string
            var foundFiles = new List<string>();
            foreach(FileInfo fi in rDir.EnumerateFiles("*.*", SearchOption.AllDirectories))
            {
                string content = System.IO.File.ReadAllText(fi.FullName);
                for (int i = 2; i < args.Length; i++)
                {
                    if (content.ToLower().Contains(args[i].ToLower()))
                    {
                        foundFiles.Add(fi.FullName);
                        break;
                    }
                }
            }

            //output result
            foundFiles.ForEach(f => Console.WriteLine(f));
            using (var sw = new StreamWriter(args[1]))
                foundFiles.ForEach(f => sw.WriteLine(f));
        }
    }
}
