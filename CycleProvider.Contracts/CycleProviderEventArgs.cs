using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleProvider.Contracts
{
    public class CycleProviderEventArgs : EventArgs
    {
        public object LastItem { get; set; }
        public int TotalItems { get; set; }
    }
}
