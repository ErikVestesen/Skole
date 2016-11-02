using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            opgave1();

            Dag14Entities db = new Dag14Entities();


            //3
            var t3 = from p in db.people
                     from f in p.firmas
                     select new { p.navn, f.firmanavn };
            foreach (var x in t3)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();


        }


        private static void opgave1()
        {
            Dag14Entities db = new Dag14Entities();

            //1
            //Console.WriteLine("Indtast beløb");
            //int beloeb = Convert.ToInt32(Console.ReadLine());
            var t = db.people
                .Where(c => c.loen > 200000)
                .Select(c => c.navn + c.loen);
            
            foreach (var k in t)
                Console.WriteLine(k);
            Console.ReadLine();

            //2
        }
    }
}
