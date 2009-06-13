using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFileTransformer.Expectation
{
    public class RestrictedValuesExpectationEvaluator : IExpectationEvaluator
    {
        private readonly List<string> _restrictedValues;
        private readonly IEqualityComparer<string> _comparer;

        #region Implementation of IExpectationEvaluator

        public RestrictedValuesExpectationEvaluator(IEnumerable<string> restrictedValues, bool isCaseSensitive)
        {
            if (restrictedValues == null)
            {
                throw new ArgumentNullException("restrictedValues");
            }

            _comparer = isCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;

            _restrictedValues = new List<string>(restrictedValues);
        }

        public bool IsFulfilled(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return _restrictedValues.Contains(input, _comparer);
        }

        #endregion
    }
}