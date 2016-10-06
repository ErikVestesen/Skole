using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace opg2
{
    class Program
    {
        public class Buffer
        {
            List<string> buffer = new List<string>();

            object lockObject = new object();

            public string Get()
            {
                lock (lockObject)
                {
                    while (buffer.Count == 0)
                    {
                        Monitor.Wait(lockObject);
                    }
                    string s = buffer[0];
                    buffer.RemoveAt(0);
                    Console.WriteLine(Thread.CurrentThread.Name + " get " + s + " new buffer.Count=" + buffer.Count);

                    return s;
                }
            }

            public void Put(string s)
            {
                lock (lockObject)
                {
                    if(buffer.Count < 5) { // opgave b?
                        buffer.Insert(buffer.Count, s);
                        Console.WriteLine(Thread.CurrentThread.Name + " put " + s + " new buffer.Count=" + buffer.Count);
                        Monitor.PulseAll(lockObject);
                    }
                }
            }

        }

        private static Random rnd = new Random();
        private static string RandomString()
        {
            int size = rnd.Next(3, 12);

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private static void Produce(object buffer)
        {
            for (int i = 0; i < 40; i++)
            {
                string s = RandomString();
                (buffer as Buffer).Put(s);
                Thread.Sleep(100);
            }
        }

        private static void Consume(object buffer)
        {
            for (int i = 0; i < 80; i++)
            {
                string s = (buffer as Buffer).Get();
                Thread.Sleep(100); // Desto mere tid, desto mere mutual exclusion
            }
        }


        static void Main(string[] args)
        {
            Buffer buffer = new Buffer();

            Thread pro1 = new Thread(new ParameterizedThreadStart(Produce));
            pro1.Name = "Producer 1";

            Thread pro2 = new Thread(new ParameterizedThreadStart(Produce));
            pro2.Name = "Producer 2";

            Thread con1 = new Thread(new ParameterizedThreadStart(Consume));
            con1.Name = "Consumer 1";

            pro1.Start(buffer);
            pro2.Start(buffer);
            con1.Start(buffer);
           
            Console.ReadLine();
        }

    }
}
