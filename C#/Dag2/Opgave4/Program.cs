using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4 {
    class Program {
        static void Main(string[] args)
        {
            Person p = new Person();
            try
            {
                Console.WriteLine(p.CPR = "1234567890");
                Console.WriteLine(p.CPR = "1234567");
                
            }
            catch (IllegalCPRException e) {
                Console.WriteLine(e.Message);
            }

            try
            {
                Console.WriteLine(p.CPR = "123WWW6789");
            } catch (IllegalCPRException e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
