using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectation : IExpectation
    {
        #region Implementation of IExpectation

        bool IExpectation.IsFulfilledBy(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return input.Length > 0;
        }

        #endregion
    }
}