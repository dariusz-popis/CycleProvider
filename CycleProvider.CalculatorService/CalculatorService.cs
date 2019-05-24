using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CycleProvider.CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        public Calculation Add(decimal left, decimal right)
        {
            return new Calculation
            {
                LeftOperand = left,
                RightOperand = right,
                Result = left + right,
                Operation = Operation.Add
            };
        }

        public Calculation Sub(decimal left, decimal right)
        {
            return new Calculation
            {
                LeftOperand = left,
                RightOperand = right,
                Result = left - right,
                Operation = Operation.Sub
            };
        }
    }
}
