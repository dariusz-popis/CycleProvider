using CycleProvider.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var @lock = new CycleProvider<ConsoleColor>();
            @lock.Add(ConsoleColor.Red);
            @lock.Add(ConsoleColor.Green);
            @lock.Add(ConsoleColor.Blue);
            @lock.Add(ConsoleColor.Yellow);
            @lock.Add(ConsoleColor.Cyan);
            @lock.Add(ConsoleColor.White);
            //@lock.OnLastItem += (s, a) => { lock (@lock) { Console.Clear(); } };
            @lock.OnLastItem += (s, a) => Console.Clear();

            var t1 = new Task(() =>
            {
                string log;
                int i = 0;
                while (++i < 20)
                {
                    log = 1000.Sleep();
                    lock (@lock)
                    {
                        Console.ForegroundColor = @lock.Next();
                        Console.WriteLine($"▓▓▓ t1 [{i}] => {log} ▓▓▓");
                        Console.Title = log;
                    }
                }
            });
            var t2 = new Task(() =>
            {
                string log;
                int i = 0;
                while (++i < 20)
                {
                    log = 1500.Sleep();
                    lock (@lock)
                    {
                        Console.ForegroundColor = @lock.Next();
                        Console.WriteLine($"███ t2 [{i}] => {log} ███");
                        Console.Title = log;
                    }
                }
            });
            var t3 = new Task(() =>
            {
                string log;
                int i = 0;
                while (++i < 20)
                {
                    log = 2000.Sleep();
                    lock (@lock)
                    {
                        Console.ForegroundColor = @lock.Next();
                        Console.WriteLine($"▒▒▒ t3 [{i}] => {log} ▒▒▒");
                        Console.Title = log;
                    }
                }
            });
            t1.Start();
            t2.Start();
            t3.Start();

            Task.WaitAll(t1, t2, t3);
        }
    }
}
