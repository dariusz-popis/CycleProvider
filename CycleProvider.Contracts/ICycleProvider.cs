using System;

namespace CycleProvider.Contracts
{
    public interface ICycleProvider<T>
    {
        event Action<object, CycleProviderEventArgs> OnLastItem;

        void Add(T item);
        T Next();
    }
}