using System;
using CycleProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ICycleProviderTests
    {
        private class FakeCycleProvider : ICycleProvider
        {
            public event Action<object, CycleProviderEventArgs> OnLastItem;

            public void Add(object item)
            {
            }

            object ICycleProvider.Next()
            {
                return 10;
            }

            public void AdditionalMethodOutsideOfInterfaceDefinition() { }
        }

        [TestMethod]
        public void TDD_PreTestsPreparation_Demo()
        {
            FakeCycleProvider fakeCycleProvider = new FakeCycleProvider();
            fakeCycleProvider.AdditionalMethodOutsideOfInterfaceDefinition();
            //fakeCycleProvider.Next(); // Compilation Error

            ICycleProvider cycleProvider = new FakeCycleProvider();
            var actual = cycleProvider.Next();

            Assert.AreEqual(10, actual);
        }
    }
}
