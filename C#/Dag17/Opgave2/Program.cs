using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            string loc = @"C: \Users\User\Desktop\TestMappe";

            DirectoryInfo dir = new DirectoryInfo(loc);
            FileInfo[] allFiles = dir.GetFiles();


            FileInfo[] bigFiles = dir.GetFiles(f => f.Length > 9000000);
            FileInfo[] oldFiles = dir.GetFiles(f => f.CreationTime < DateTime.Now.AddDays(-1));
            FileInfo[] readOnlyFiles = dir.GetFiles(f => f.IsReadOnly);
            
            foreach(var x in bigFiles)
            {
                Console.WriteLine(x.FullName);
            }
            Console.ReadLine();
        }
    }

    static class MyExtension
    {
        public static FileInfo[] GetFiles(this DirectoryInfo something, Predicate<FileInfo> match) {
            IEnumerable<FileInfo> files = something.EnumerateFiles();
            files = files.Where(match.Invoke);
            return files.ToArray();
        }
    }
}
