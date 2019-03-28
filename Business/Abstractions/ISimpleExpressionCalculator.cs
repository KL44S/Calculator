using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface ISimpleExpressionCalculator
    {
        /// <summary>Evaluates the simple expression and gets the result
        /// </summary>
        double EvaluateSimpleExpression(String simpleExpression);
    }
}
