using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstractions
{
    //Chain of responsability
    public abstract class OperationSolver : IOperationSolver
    {
        #region Attributes & Properties

        protected String _symbolHandled;

        public IOperationSolver NextOperationSolver { get; set; }

        #endregion

        #region Protected methods

        protected abstract double DoResolve(double firstOperand, double secondOperand);

        protected OperationSolver(String symbolHandled)
        {
            this._symbolHandled = symbolHandled;
        }

        #endregion

        #region Private methods

        private Boolean CanHandle(string operationSymbol)
        {
            Boolean canIhandle = (this._symbolHandled.Equals(operationSymbol));

            return canIhandle;
        }

        #endregion

        #region Public methods

        public double Solve(string operationSymbol, double firstOperand, double secondOperand)
        {
            double result = 0;

            if (this.CanHandle(operationSymbol))
            {
                result = this.DoResolve(firstOperand, secondOperand);
            }
            else if (this.NextOperationSolver != null)
            {
                result = this.NextOperationSolver.Solve(operationSymbol, firstOperand, secondOperand);
            }
            else
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        #endregion
    }
}
