using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    public interface IOperandFounder
    {
        double GetFirstOperandFromOperationIndex(string expression, int index);
        double GetSecondOperandFromOperationIndex(string expression, int index);
    }
}
