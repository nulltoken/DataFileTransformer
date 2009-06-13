using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFileTransformer.Expectation
{
    public class RestrictedValuesExpectationEvaluator : IExpectationEvaluator
    {
        private readonly IEqualityComparer<string> _comparer;
        private readonly IEnumerable<string> _restrictedValues;

        #region Implementation of IExpectationEvaluator

        public RestrictedValuesExpectationEvaluator(IEnumerable<string> restrictedValues, bool isCaseSensitive)
        {
            if (restrictedValues == null)
            {
                throw new ArgumentNullException("restrictedValues");
            }

            _comparer = BuildStringComparerFrom(isCaseSensitive);

            _restrictedValues = restrictedValues;
        }

        public bool IsFulfilled(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return _restrictedValues.Contains(input, _comparer);
        }

        private static StringComparer BuildStringComparerFrom(bool isCaseSensitive)
        {
            return isCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
        }

        #endregion
    }
}