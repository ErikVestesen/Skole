using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };

            var query = from tal in numbers
                        where tal.ToString().Length == 2
                        orderby tal //descending // <-- opgave b
                        //select tal // opgave a-c
                        select (tal % 2 == 0 ? tal + " lige" : tal + " ulige"); // opgave d
            Console.WriteLine();
            foreach (var k in query) {
                    bool jajajajaja = false;
                    if (Convert.ToInt32(k.Substring(0,1)) % 2 == 0) {
                        jajajajaja = true;
                    }
                    Console.WriteLine("Tal={0}, Lige={1}", k.Substring(0,2),jajajajaja);
               
            }
            Console.ReadLine();


        }
    }
}
