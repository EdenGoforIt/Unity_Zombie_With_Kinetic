using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class Program
    {

        
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
               {

                   return Thread.CurrentThread.ManagedThreadId;
               }
            );
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < _field.Value; i++)
            {
                Console.WriteLine("threadProc:{0}", i);
                Thread.Sleep(10);
            }
        }
        public static void Main(string[] args)
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(()=> {
                Thread.Sleep(1000);
          
                return 1;

            });

            tasks[1] = Task.Run(()=> {
                Thread.Sleep(1000);
         
                return 2;
            });
            tasks[2] = Task.Run(()=> {
                Thread.Sleep(1000);
               
                return 3;
            });

            while (tasks.Length > 0)
            {
                int i = Task.WaitAny(tasks);
                Task<int>
            }

        }
    }
}
