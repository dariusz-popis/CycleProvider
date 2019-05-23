using System;
using System.Threading;
using System.Threading.Tasks;

namespace CycleProvider.Library
{
    public static class ThreadExtensions
    {
        private static string Sleep(this int milliseconds, bool withLog = false)
        {
            string returnValue;
            var start = DateTime.Now;
            Thread.Sleep(milliseconds);
            returnValue = $"Slept: {start:hh:mm:ss:ms} to {DateTime.Now:hh:mm:ss:ms}";
            if (withLog) Console.WriteLine(returnValue);

            return returnValue;
        }

        public static string Sleep<TStruct>(this TStruct @struct, bool withLog = false, Action action = null) where TStruct : struct
        {
            if (action != null) Task.Run(action);

            int milliseconds = 0;
            if (@struct is int || @struct is decimal)
            {
                milliseconds = Convert.ToInt32(@struct);
            }

            return Sleep(milliseconds, withLog);
        }
    }
}
