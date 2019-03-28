using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Implementations
{
    public class AdditionSolver : OperationSolver
    {
        public AdditionSolver() : base("+") { }

        protected override double DoResolve(double firstOperand, double secondOperand)
        {
            double result = firstOperand + secondOperand;

            return result;
        }
    }
}
