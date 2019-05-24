using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Contracts
{
    public interface IGenericInvIn<in T>
    {
        void Put(T item);
    }
}
