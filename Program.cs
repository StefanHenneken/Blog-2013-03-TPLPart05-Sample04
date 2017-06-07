using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Main");
            try
            {
                Task task1 = Task.Factory.StartNew(Do);
                task1.Wait();
            }
            catch (AggregateException aex)
            {
                Console.WriteLine("Exception Main: " + aex.Message);
                aex.Flatten();
                foreach (Exception ex in aex.InnerExceptions)
                    Console.WriteLine("  Exception in Main: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("End Main");
                Console.ReadLine();
            }
        }
        static public void Do()
        {
            Console.WriteLine("Start Do");
            Thread.Sleep(1000);
            int a = 1;
            a = a / --a;
            Console.WriteLine("End Do");
        }
    }
}
