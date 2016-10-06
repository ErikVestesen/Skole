using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opgave1
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            Thread t1 = new Thread(new ThreadStart(worker.work)); t1.Name = "Th1";
            Thread t2 = new Thread(new ThreadStart(worker.work)); t2.Name = "Th2";
            Thread t3 = new Thread(new ThreadStart(worker.work)); t3.Name = "Th3";
            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadLine();
        }
    }
    public class Worker
    {
        ////Opgave 1a
        //Lock sætter indholdet i kritisk section, hvor kun én tråd kan tilgå og/eller bruge det. ==> Mutual exclusion
        //I det her tilfælde er det kun én tråd ad gangen der kan komme ind og køre forloopet.
        //public void work()
        //{
        //    lock (this)
        //    {
        //        for (int i = 1; i <= 40; i++)
        //        {
        //            // udskriv en linje
        //            Console.Write("Output from");
        //            Console.Write(Thread.CurrentThread.Name);
        //            Console.Write(": " + i);
        //            Console.WriteLine();
        //        }
        //    }
        //}

        //Opgave 1b
        public void work()
        {
            Monitor.Enter(this);
            try
            {
                for (int i = 1; i <= 40; i++)
                {
                    // udskriv en linje
                    Console.Write("Output from");
                    Console.Write(Thread.CurrentThread.Name);
                    Console.Write(": " + i);
                    Console.WriteLine();
                }
            } finally {
                Monitor.Exit(this);
            }
        }

    }
}
