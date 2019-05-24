using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CycleProvider.CalculatorService
{
    public enum Operation { Add = 1, Sub = 2 }

    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        Calculation Add(decimal left, decimal right);
        [OperationContract]
        Calculation Sub(decimal left, decimal right);
    }

    [DataContract]
    public class Calculation
    {
        [DataMember]
        public decimal LeftOperand { get; set; }
        [DataMember]
        public decimal RightOperand { get; set; }
        [DataMember]
        public decimal Result { get; set; }
        [DataMember]
        public Operation Operation { get; set; }
    }
}
