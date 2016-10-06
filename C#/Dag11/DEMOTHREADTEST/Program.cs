using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DemoThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread.CurrentThread.Name = "Main thread";

                Worker w1 = new Worker(80);

                Thread workThread = new Thread(new ThreadStart(w1.Work));
                //workThread.Priority = ThreadPriority.Lowest;
                //workThread.IsBackground = true;
                workThread.Name = "   Worker thread";
                workThread.Start(); //both threads is executing

                Worker w2 = new Worker(30);

                w2.Work(); //both threads is executing the work()-method

                workThread.Abort();
                //workThread.Join(); //let current thread (Main thread) wait for 
                                     //the Working thread to finish   
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " aborted");
            }

            Console.WriteLine("Main has finished");
            Console.ReadLine();
        }
    }

    public class Worker
    {
        private int limit;

        public Worker(int limit)
        {
            this.limit = limit;
        }

        public void Work()
        {
          do
          {
            try
            {
              int interval = 1000000;
              Console.WriteLine(Thread.CurrentThread.Name + ": Work() starter...");
              for (int i = 0; i <= limit * interval; i++)
              {
                if (i % interval == 0)
                {
                  Thread.Sleep(40);
                  Console.WriteLine(Thread.CurrentThread.Name + " " + i / interval);
                }
              }
              Console.WriteLine(Thread.CurrentThread.Name + ": Work() stopper");
            }
            catch (ThreadAbortException)
            {
              Console.WriteLine(Thread.CurrentThread.Name + " aborted");
            }
            finally
            {
              Console.WriteLine(Thread.CurrentThread.Name + " i finally");
            }

          } while (Thread.CurrentThread.Name != "Main thread");
        }
    }

}
