using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleProvider.Contracts;

namespace CycleProvider.Library
{
    public class GenericInv<T> : IGenericInvOut<T>, IGenericInvIn<T>
    {
        private T _item;

        public T Get() { return _item; }
        public void Put(T item) { _item = item; }
    }
}
