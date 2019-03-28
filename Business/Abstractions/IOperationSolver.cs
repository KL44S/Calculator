using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IOperationSolver
    {
        /// <summary>Solves a simple arithmetic operation
        /// </summary>
        double Solve(String operationSymbol, double firstOperand, double secondOperand);
    }
}
