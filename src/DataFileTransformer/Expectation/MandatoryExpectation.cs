using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectation : IExpectationEvaluator
    {
        #region Implementation of IExpectationEvaluator

        public bool IsFulfilled(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input == string.Empty)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}