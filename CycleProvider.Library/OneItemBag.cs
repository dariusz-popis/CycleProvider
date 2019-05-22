using CycleProvider.Contracts;

namespace CycleProvider.Library
{
    public class OneItemBag<TClass> where TClass : class
    {
        private TClass _item;
        private bool _isEmpty = true;

        public void Put(TClass item)
        {
            if (!_isEmpty) throw new OneItemBagException(InvalidOperationExceptionMessages.BagIsNotEmpty);

            _isEmpty = false;
            _item = item;
        }

        public TClass Get()
        {
            if (_isEmpty) throw new OneItemBagException(InvalidOperationExceptionMessages.BagIsEmpty);

            _isEmpty = true;
            var returnValue = _item;
            _item = null;
            return returnValue;
        }
    }
}
