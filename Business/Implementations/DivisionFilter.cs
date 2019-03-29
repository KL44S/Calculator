using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class DivisionFilter : OperationFilter
    {
        public DivisionFilter(IOperandFounder operandFounder) : base(operandFounder, "/") { }

        protected override double GetOperationResult(double firstOperand, double secondOperand)
        {
            double result = firstOperand / secondOperand;

            return result;
        }
    }
}
