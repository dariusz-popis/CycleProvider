﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class PersonBaseTests
    {
        [TestMethod]
        public void Constructor_IdIsAutogenerated()
        {
            PersonBase person1 = new Person("Gates_1");
            PersonBase person2 = new Person("Gates_2");
            PersonBase person3 = new Person("Gates_3");
            PersonBase person4 = new Person("Gates_4");

            Assert.AreEqual(1, person1.Id); Console.WriteLine(person1);
            Assert.AreEqual(2, person2.Id); Console.WriteLine(person2);
            Assert.AreEqual(3, person3.Id); Console.WriteLine(person3);
            Assert.AreEqual(4, person4.Id); Console.WriteLine(person4);
            Assert.AreEqual(4, PersonBase.Counter);
        }
    }
}
