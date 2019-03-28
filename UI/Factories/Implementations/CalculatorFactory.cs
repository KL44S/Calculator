using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstractions;
using Business.Implementations;
using UI.Factories.Abstractions;

namespace UI.Factories.Implementations
{
    public class CalculatorFactory : ICalculatorFactory
    {
        private ISimpleExpressionCalculatorFactory _simpleExpressionCalculatorFactory;

        public CalculatorFactory(ISimpleExpressionCalculatorFactory simpleExpressionCalculatorFactory)
        {
            this._simpleExpressionCalculatorFactory = simpleExpressionCalculatorFactory;
        }

        public ICalculator CreateAndGetInstance()
        {
            ISimpleExpressionCalculator simpleExpressionCalculator = this._simpleExpressionCalculatorFactory
                                                                        .CreateAndGetInstance();

            ICalculator calculator = new Calculator(simpleExpressionCalculator);

            return calculator;
        }
    }
}
