using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IExpressionFilter
    {
        String FilterExpression(String expression);
    }
}
