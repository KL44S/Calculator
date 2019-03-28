using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstractions;
using Business.Implementations;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class SimpleExpressionCalculatorFactory : ISimpleExpressionCalculatorFactory
    {
        private IOperationSolverFactory _operationSolverFactory;

        public SimpleExpressionCalculatorFactory(IOperationSolverFactory operationSolverFactory)
        {
            this._operationSolverFactory = operationSolverFactory;
        }

        public ISimpleExpressionCalculator CreateAndGetInstance()
        {
            IOperationSolver operationSolver = this._operationSolverFactory.CreateAndGetInstance();
            ISimpleExpressionCalculator simpleExpressionCalculator = new SimpleExpressionCalculator(operationSolver);

            return simpleExpressionCalculator;
        }
    }
}
