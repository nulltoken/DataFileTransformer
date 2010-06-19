using System;
using System.Collections.Generic;
using System.Linq;

namespace DataFileTransformer.Expectation
{
    public class RestrictedValuesExpectation : ExpectationBase
    {
        private readonly IEqualityComparer<string> _comparer;
        private readonly HashSet<string> _restrictedValues;

        public RestrictedValuesExpectation(IEnumerable<string> restrictedValues, bool isCaseSensitive)
        {
            if (restrictedValues == null)
            {
                throw new ArgumentNullException("restrictedValues");
            }

            _comparer = BuildStringComparerFrom(isCaseSensitive);
            _restrictedValues = new HashSet<string>(restrictedValues);
        }

        protected override Func<string, bool> ExpectationVerifier
        {
            get { return (input => _restrictedValues.Contains(input, _comparer)); }
        }

        protected override string ErrorMessageFormat
        {
            get { return "Input data '{0}' is not contained in allowed values '{1}'."; }
        }

        protected override IEnumerable<string> ErrorMessageAdditionalParameters
        {
            get { yield return string.Join(",", _restrictedValues.ToArray()); }
        }

        private static StringComparer BuildStringComparerFrom(bool isCaseSensitive)
        {
            return isCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase;
        }
    }
}