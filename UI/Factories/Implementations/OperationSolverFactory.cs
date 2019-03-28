using Business.Abstractions;
using Business.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class OperationSolverFactory : IOperationSolverFactory
    {
        public IOperationSolver CreateAndGetInstance()
        {
            OperationSolver additionSolver = new AdditionSolver();

            OperationSolver subtractionSolver = new SubtractionSolver();
            subtractionSolver.NextOperationSolver = additionSolver;

            OperationSolver multiplicationSolver = new MultiplicationSolver();
            multiplicationSolver.NextOperationSolver = subtractionSolver;

            OperationSolver divisionSolver = new DivisionSolver();
            divisionSolver.NextOperationSolver = multiplicationSolver;

            return divisionSolver;
        }
    }
}
