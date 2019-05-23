using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class DynamicUsageTests
    {
        [TestMethod]
        public void DynamicObjectInjection_Demo()
        {
            LogFromDynamic(new Person("Dolas") { FirstName = "Franek" });
            LogFromDynamic(new PrivatePerson { LastName = "PrivateClass", FirstName = "Franek" });
            LogFromDynamic(new PrivatePersonValueType { LastName = 112, FirstName = 987 });

            LogFromDynamic(new { FirstName="Goran", LastName = new { AnyProperty = "Look at this", OtherProperty = "... and at this ..."} });
            LogFromDynamic(new { FirstName = "Goran", LastName = new { AnyProperty = "Look at this", OtherProperty = "... and at this ..."} });
        }

        private static void LogFromDynamic(dynamic fullName)
        {
            Console.WriteLine($"FN: {fullName.FirstName} LN: {fullName.LastName}");
        }

        private class PrivatePerson
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private struct PrivatePersonValueType
        {
            public int FirstName { get; set; }
            public int LastName { get; set; }
        }
    }
}
