using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public abstract class ExpressionFilter : IExpressionFilter
    {
        public IExpressionFilter NextExpressionFilter { get; set; }

        protected abstract string DoFilterExpression(string expression);

        public string FilterExpression(string expression)
        {
            expression = this.DoFilterExpression(expression);
            
            if (this.NextExpressionFilter != null)
            {
                expression = this.NextExpressionFilter.FilterExpression(expression);
            }

            return expression;
        }
    }
}
