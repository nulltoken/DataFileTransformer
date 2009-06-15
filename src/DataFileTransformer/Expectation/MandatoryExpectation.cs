using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectation : IExpectationAccessor
    {
        #region Implementation of IExpectationAccessor

        public Func<string, bool> Expectation
        {
            get { return input => input.Length > 0; }
        }

        #endregion
    }
}