using CycleProvider.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.ConsoleParallel
{
    class Program
    {
        static void Main()
        {
            var sim = "55555666666777777788888888999999999AAAAAAAAAABBBBBBBBBBB";

            Console.WriteLine("\n-----------------------\nParallel thread foreach:");
            Parallel.ForEach(sim, c => Console.WriteLine($"Request for [{c}] "
                + $"| Response is: {GetFromOutsources(c)}"));

            Console.WriteLine("\n-----------------------\nSingle thread foreach:");
            //SingleThreadForeach(sim);
        }

        private static void SingleThreadForeach(string sim)
        {
            foreach (var item in sim)
            {
                if (item % 2 == 0 || item % 3 == 0) continue;

                Console.WriteLine($"Request for [{item}] | Response is: {GetFromOutsources(item)}");
            }
        }

        private static string GetFromOutsources(char item)
        {
            return (4000).Sleep();
        }
    }
}
