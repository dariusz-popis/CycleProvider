using CycleProvider.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CycleProvider.Library
{
    public class CycleProvider<T> : ICycleProvider<T>, INotifyPropertyChanged
    {
        private List<T> _items = new List<T>();
        private int _currentItem = -1;

        public T CurrentItem => _currentItem == -1
            ? throw new InvalidOperationException(InvalidOperationExceptionMessages.EmptyCycleProviderList)
            : _items[_currentItem];

        public void Add(T item)
        {
            _items.Add(item);
        }

        public event Action<object, CycleProviderEventArgs> OnLastItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public T Next()
        {
            int totalItems = _items.Count;
            if (totalItems == 0) throw new InvalidOperationException(InvalidOperationExceptionMessages.EmptyCycleProviderList);

            _currentItem = ++_currentItem > totalItems - 1 ? 0 : _currentItem;

            var returnItem = _items[_currentItem];
            if (_currentItem == totalItems - 1)
                OnLastItem?.Invoke(this, new CycleProviderEventArgs { LastItem = returnItem, TotalItems = totalItems });

            PropertyChanged?.Invoke(this, _currentItemArgs);

            return returnItem;
        }

        private static readonly PropertyChangedEventArgs _currentItemArgs = new PropertyChangedEventArgs(nameof(CurrentItem));
    }
}
