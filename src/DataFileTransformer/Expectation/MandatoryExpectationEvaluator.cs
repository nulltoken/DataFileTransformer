using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectationEvaluator : IExpectationEvaluator
    {
        #region Implementation of IExpectationEvaluator

        public bool IsFulfilled(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length == 0)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}