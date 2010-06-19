using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataFileTransformer.Expectation
{
    public class PatternExpectation : ExpectationBase
    {
        private readonly Regex _pattern;

        public PatternExpectation(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            _pattern = new Regex(pattern, RegexOptions.Compiled);
        }

        protected override string ErrorMessageFormat
        {
            get { return "Input data '{0}' does not match pattern '{1}'."; }
        }

        protected override Func<string, bool> ExpectationVerifier
        {
            get { return input => _pattern.IsMatch(input); }
        }

        protected override IEnumerable<string> ErrorMessageAdditionalParameters
        {
            get { yield return _pattern.ToString(); }
        }
    }
}