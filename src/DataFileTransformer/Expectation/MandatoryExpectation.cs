using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectation : IExpectation
    {
        #region Implementation of IExpectation

        public Func<string, bool> IsFulfilledBy
        {
            get { return input => input.Length > 0; }
        }

        #endregion
    }
}