using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ThreadExtensionTests
    {
        [TestMethod]
        public void Sleep_Demo()
        {
            ThreadExtensions.Sleep(500, true, 
                () => Console.WriteLine($"This method is assync: {2000.Sleep()}"));
            500.Sleep(true);
            Console.WriteLine($"Returned from Sleep: {1000.Sleep()}");

            Console.WriteLine($"int: {float.MaxValue} {float.MaxValue.ToString().Length}");
            Console.WriteLine($"uint: {uint.MaxValue} {uint.MaxValue.ToString().Length}");
        }
    }
}
