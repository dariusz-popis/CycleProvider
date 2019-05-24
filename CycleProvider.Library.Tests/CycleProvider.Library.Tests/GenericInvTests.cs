using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleProvider.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace CycleProvider.Library.Tests
{
    [TestClass]
    public class GenericInvTests
    {
        private class Animal { public string Kind { get; set; } }
        private class Tiger : Animal { public int Strips { get; set; } }

        [TestMethod]
        public void VariableParadigm()
        {
            var generic = new GenericInv<string>();

            DoWithObject("ok");
            DoWithObject(generic);
            //DoWithGenericOfObject(generic); // Compile error
            //DoWithGenericInterfaceInOfObject(generic); // Compile error
            DoWithGenericInterfaceOutOfObject(generic);

            var table = new List<Tiger>();
            LinqQuery(table);
        }

        private void DoWithObject(object obj) { }

        private void DoWithGenericOfObject(GenericInv<object> genericInv) { }

        private IGenericInvOut<object> DoWithGenericInterfaceInOfObject(IGenericInvIn<string> genericInv)
        {
            genericInv.Put("aabcd");
            return (IGenericInvOut<object>)genericInv;
        }

        private void DoWithGenericInterfaceOutOfObject(IGenericInvOut<object> genericInv)
        {
            var anything = genericInv.Get();
        }

        private void LinqQuery(IEnumerable<Animal> table)
        {
            table.FirstOrDefault(a=>a.Kind == "Predator");
        }
    }
}
