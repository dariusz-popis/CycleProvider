using System;
using CycleProvider.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class ICycleProviderTests
    {
        private class FakeCycleProvider<T> : ICycleProvider<T>
        {
            private T _item;

            public T CurrentItem => _item;

#pragma warning disable CS0067
            public event Action<object, CycleProviderEventArgs> OnLastItem;
#pragma warning restore CS0067

            public void Add(T item)
            {
                _item = item;
            }

            T ICycleProvider<T>.Next()
            {
                return _item;
            }

            public void AdditionalMethodOutsideOfInterfaceDefinition() { }
        }

        [TestMethod]
        public void TDD_PreTestsPreparation_Demo()
        {
            //ICycleProvider<int> iFakeCycleProvider = new FakeCycleProvider<int>();
            //iFakeCycleProvider.AdditionalMethodOutsideOfInterfaceDefinition(); // Compilation Error

            FakeCycleProvider<int> fakeCycleProvider = new FakeCycleProvider<int>();
            fakeCycleProvider.AdditionalMethodOutsideOfInterfaceDefinition();
            //fakeCycleProvider.Next(); // Compilation Error

            ICycleProvider<int> cycleProvider = new FakeCycleProvider<int>();
            cycleProvider.Add(10);
            var actual = cycleProvider.Next();

            Assert.AreEqual(10, actual);
        }
    }
}
