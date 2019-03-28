using Business.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Business.Implementations
{
    public class SimpleExpressionCalculator : ISimpleExpressionCalculator
    {
        #region Attributes

        private static String _culture = "en-US";
        private static int _operationSymbolLength = 1;
        private static IList<char> _validNumberChars = new List<char>()
        {
            '0',
            '1',
            '2',
            '3',
            '4',
            '5',
            '6',
            '7',
            '8',
            '9',
            '.'
        };

        private IOperationSolver _operationSolver;

        #endregion

        #region Private methods

        private int GetNumberLength(string subExpression, int indexFrom)
        {
            //This allows to avoid parsing numbers with length 1.
            //This way, I can start to parse one char behind to avoid the possible minus forward the number.
            int charsToEndNumber = (subExpression.Length - indexFrom);
            if (charsToEndNumber.Equals(1))
            {
                return charsToEndNumber;
            }

            //Setting index one char behind the start
            int index = indexFrom + 1;

            Boolean numberHasFinished = false;

            while (index < subExpression.Length && !numberHasFinished)
            {
                char currentChar = subExpression[index];
                numberHasFinished = !_validNumberChars.Contains(currentChar);

                if (!numberHasFinished)
                {
                    index++;
                }
            }

            int numberLength = (index - indexFrom);

            return numberLength;
        }

        private KeyValuePair<double, int> GetNumberWithItsLength(string simpleExpression, int indexFrom)
        {
            int numberLength = this.GetNumberLength(simpleExpression, indexFrom);
            String numberAsText = simpleExpression.Substring(indexFrom, numberLength);

            double result = double.Parse(numberAsText, CultureInfo.GetCultureInfo(_culture));

            KeyValuePair<double, int> numberWithItsLength = new KeyValuePair<double, int>(result, numberLength);

            return numberWithItsLength;
        }

        #endregion

        #region Public methods

        public SimpleExpressionCalculator(IOperationSolver operationSolver)
        {
            this._operationSolver = operationSolver;
        }

        public double EvaluateSimpleExpression(string simpleExpression)
        {
            int index = 0;

            //Getting the first number
            KeyValuePair<double, int> numberWithItsLength = this.GetNumberWithItsLength(simpleExpression, index);
            double result = numberWithItsLength.Key;

            //Updating index to keep reading the expression
            index += numberWithItsLength.Value;

            Boolean isEndOfExpression = simpleExpression.Length.Equals(index);

            //If there is more text in the expression, then is a full operation
            //Else it was just a number
            if (!isEndOfExpression)
            {
                while (index < simpleExpression.Length)
                {
                    //Getting the operation
                    String operationSymbol = simpleExpression.Substring(index, _operationSymbolLength);
                    index += _operationSymbolLength;

                    //Getting the second operation (number)
                    KeyValuePair<double, int> secondOperandWithItsLength = this.GetNumberWithItsLength(simpleExpression, index);
                    double secondOperand = secondOperandWithItsLength.Key;

                    //Getting and accumulating the result
                    result = this._operationSolver.Solve(operationSymbol, result, secondOperand);

                    //Updating index to keep reading the expression
                    index += secondOperandWithItsLength.Value;
                }
            }

            return result;
        }

        #endregion
    }
}
