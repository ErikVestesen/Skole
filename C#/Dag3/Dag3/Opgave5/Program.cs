using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave5
{
    class Program
    {
        static void Main(string[] args)
        {
            GrowableArray g = new GrowableArray();
            g[0] = 7;
            g[3] = 9;
            g[10] = 13;
            g[25] = 26;
            Console.WriteLine(g[0]);
            Console.WriteLine(g[3]);
            Console.WriteLine(g[10]);
            Console.WriteLine(g[25]);
            Console.ReadLine();
        }
    }
}
