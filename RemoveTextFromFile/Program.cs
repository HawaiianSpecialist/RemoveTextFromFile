using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveTextFromFile
{
    class Program
    {
        private static FileManager fm;

        static void Main(string[] args)
        {
            if(args.Length >= 2)
            {
                fm = new FileManager();

                if(Directory.Exists(args[0]))
                {
                    fm.renameFile(args[0], args[1], args[2] == null ? "" : args[2]);
                }
                else
                {
                    Console.Write("Invalid path: " + args[0]);
                }
            }
            else
            {
                Console.WriteLine("Usage:");
                Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName + " <Source Path> <Search Criteria to Replace> (Replacement text)");
                Console.WriteLine("");
                Console.WriteLine("Example:");
                Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName + " \"C:\\My Music\" \" - \"");
            }
        }
    }
}
