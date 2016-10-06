using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace DemoThreadSynchronization
{
    class Program
    {
        private static int count = 0;

        [STAThread]
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(countUp));
            t1.Name = "tUp";
            Thread t2 = new Thread(new ThreadStart(countDown));
            t2.Name = "tDn1";
            Thread t3 = new Thread(new ThreadStart(countDown));
            t3.Name = "tDn2";

            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadLine();
        }

        static Random rnd = new Random();

        // count up 20 times
        public static void countUp()
        {
            for (int i = 0; i < 20; i++)
            {
                inc();
                // simulate some time is spend
                DateTime dt = DateTime.Now;
                TimeSpan t = DateTime.Now.Subtract(dt);
                int delay = rnd.Next(20,40);
                while (t.Milliseconds < delay) //simulate thread is working
                {
                    t = DateTime.Now.Subtract(dt);
                }
            }
        }

        // count down 10 times
        public static void countDown()
        {
            for (int i = 0; i < 10; i++)
            {
                dec();
                // simulate some time is spend
                DateTime dt = DateTime.Now;
                TimeSpan t = DateTime.Now.Subtract(dt);
                int delay = rnd.Next(45, 90);
                while (t.Milliseconds < delay) //simulate thread is working
                {
                    t = DateTime.Now.Subtract(dt);
                }
            }
        }


        private static object oSync = new object();

        public static void inc()
        {
            lock (oSync)
            {
                while (count == 2) 
                {
                    Console.WriteLine("   " + Thread.CurrentThread.Name + " waiting ...");
                    Monitor.Wait(oSync);
                }
                count++;

                Console.WriteLine(Thread.CurrentThread.Name + ": up to " + count);
                Monitor.PulseAll(oSync);
            }
        }

        public static void dec()
        {
            lock (oSync)
            {
                while (count == 0) 
                {
                    Console.WriteLine("   " + Thread.CurrentThread.Name + " waiting ...");
                    Monitor.Wait(oSync);
                }
                count--;
                Console.WriteLine(Thread.CurrentThread.Name + ": down to " + count);
                Monitor.PulseAll(oSync);
            }
        }
    }
}
