using System;

namespace CycleProvider.Contracts
{
    public interface ICycleProvider
    {
        event Action<object, CycleProviderEventArgs> OnLastItem;

        void Add(object item);
        object Next();
    }
}