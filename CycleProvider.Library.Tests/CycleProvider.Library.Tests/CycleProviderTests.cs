using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class CycleProviderTests
    {
        [TestMethod]
        public void Next_AfterLastElement_ReturnsFirst()
        {
            var cycleProvider = new CycleProvider();
            cycleProvider.Add("First Item");
            cycleProvider.Add("Second Item");
            cycleProvider.Add("Third Item");

            cycleProvider.Next();
            cycleProvider.Next();
            cycleProvider.Next();
            object actual = cycleProvider.Next();

            Assert.AreEqual("First Item", actual);
        }

        [TestMethod]
        public void Next_FirstUse_ReturnsFirstItem()
        {
            var cycleProvider = new CycleProvider();
            cycleProvider.Add("First Item");

            object actual = cycleProvider.Next();

            Assert.AreEqual("First Item", actual);
        }

        [TestMethod]
        public void Next_ThreeItems_ReturnsLastItem()
        {
            var cycleProvider = new CycleProvider();
            cycleProvider.Add("First Item");
            cycleProvider.Add("Second Item");
            cycleProvider.Add("Third Item");
            cycleProvider.Next();
            cycleProvider.Next();

            object actual = cycleProvider.Next();

            Assert.AreEqual("Third Item", actual);
        }

        [TestMethod]
        public void Next_NoItem_ThrowsException()
        {
            var cycleProvider = new CycleProvider();

            var actual = Assert.ThrowsException<InvalidOperationException>(() => cycleProvider.Next());
            Assert.AreEqual("CycleProvider has no item", actual.Message);
        }

        [TestMethod]
        public void Next_LastItem_EventOnLastItemFired()
        {
            const string lastItem = "Last Item";
            var actualWasInvoked = false;
            var cycleProvider = new CycleProvider();
            cycleProvider.Add("First Item");
            cycleProvider.Add(lastItem);
            cycleProvider.OnLastItem += (s, a) =>
            {
                actualWasInvoked = true;
                Assert.AreEqual(cycleProvider, s);
                Assert.AreEqual(lastItem, a.LastItem);
                Assert.AreEqual(2, a.TotalItems);
            };
            cycleProvider.Next();

            object actual = cycleProvider.Next();

            Assert.AreEqual(true, actualWasInvoked, "Event handler was never invoked");
            Assert.AreEqual(lastItem, actual);
        }
    }
}
