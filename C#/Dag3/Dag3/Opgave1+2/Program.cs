﻿using System;
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
            Time t1, t2;
            t1 = new Time("08:30");
            t2 = t1;
            t2.Hour = t2.Hour + 2;
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
            Console.ReadLine();
        }
    }
}
