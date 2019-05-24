using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Contracts
{
    public interface IGenericInvOut<out T>
    {
        T Get();
    }
}
