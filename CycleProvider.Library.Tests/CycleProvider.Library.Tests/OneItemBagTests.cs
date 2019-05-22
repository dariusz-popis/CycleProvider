using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class OneItemBagTests
    {
        [TestMethod]
        public void Put_OneItemBagIsNotEmpty_ThrowsException()
        {
            var bag = new OneItemBag<object>();
            bag.Put(new object());

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Put(null));

            Assert.AreEqual("Invalid operation. Bag is not empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBagIsEmpty_ThrowsException()
        {
            var bag = new OneItemBag<object>();

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Get());

            Assert.AreEqual("Invalid operation. Bag is empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBagIsEmptyAfterPutAndGet_ThrowsException()
        {
            var bag = new OneItemBag<string>();
            bag.Put("1");
            bag.Get();

            var actual = Assert.ThrowsException<OneItemBagException>(() => bag.Get());

            Assert.AreEqual("Invalid operation. Bag is empty", actual.Message);
        }

        [TestMethod]
        public void Get_OneItemBahHasAnItem_ReturnsItem()
        {
            var bag = new OneItemBag<TestItem>();
            bag.Put(new TestItem { Id = 777, Name = "Test Item", Description = "Description of Test Item" });

            TestItem actual = bag.Get();

            Assert.AreEqual(777, actual.Id);
            Assert.AreEqual("Test Item", actual.Name);
            Assert.AreEqual("Description of Test Item", actual.Description);
        }

        private class TestItem
        {
            public int Id;
            public string Name;
            public string Description;
        }
    }
}
