using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave2
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");
            names.ForEach(i => Console.WriteLine(i));  
            Console.ReadLine();
        }
    }
}
