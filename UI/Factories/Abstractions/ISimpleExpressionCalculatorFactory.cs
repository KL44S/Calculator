﻿using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Factories.Abstractions
{
    public interface ISimpleExpressionCalculatorFactory : IFactory<ISimpleExpressionCalculator>
    {
    }
}
