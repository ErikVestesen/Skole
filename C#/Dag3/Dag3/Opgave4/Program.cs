using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave4
{
    class Program
    {
        static void Main(string[] args)
        {
            Classes c = new Classes();
            c[1] = "Jan";
            c[2] = "Feb";
            c[3] = "Mar";
            c[4] = "Apr";
            c[5] = "May";
            c[6] = "Jun";
            c[7] = "Jul";
            c[8] = "Aug";
            c[9] = "Sep";
            c[10] = "Oct";
            c[11] = "Nov";
            c[12] = "Dec";

            for (int i = 0; i < 13; i++)
            {
                Console.WriteLine(c[i]);
                Console.ReadLine();

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
