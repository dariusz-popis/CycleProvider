using System;

namespace CycleProvider.Contracts
{
    [Serializable]
    public class HRException : Exception
    {
        public HRException() { }
        public HRException(string message) : base(message) { }
        public HRException(string message, Exception inner) : base(message, inner) { }
        protected HRException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
