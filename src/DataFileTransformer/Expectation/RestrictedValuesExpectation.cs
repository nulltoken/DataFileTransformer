using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFileTransformer.Expectation
{
    public class RestrictedValuesExpectation : IExpectation
    {
        private readonly IEqualityComparer<string> _comparer;
        private readonly IEnumerable<string> _restrictedValues;

        public RestrictedValuesExpectation(IEnumerable<string> restrictedValues, bool isCaseSensitive)
        {
            if (restrictedValues == null)
            {
                throw new ArgumentNullException("restrictedValues");
            }

            _comparer = BuildStringComparerFrom(isCaseSensitive);
            _restrictedValues = restrictedValues;
        }

        private static StringComparer BuildStringComparerFrom(bool isCaseSensitive)
        {
            return isCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
        }


        #region Implementation of IExpectation

        public Func<string, bool> IsFulfilledBy
        {
            get { return input => _restrictedValues.Contains(input, _comparer); }
        }

        #endregion
    }
}