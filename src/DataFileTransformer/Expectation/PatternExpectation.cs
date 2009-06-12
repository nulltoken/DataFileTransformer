using System;
using System.Text.RegularExpressions;

namespace DataFileTransformer.Expectation
{
    public class PatternExpectation : IExpectationEvaluator
    {
        private readonly Regex _pattern;

        #region Implementation of IExpectationEvaluator

        public PatternExpectation(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            _pattern = new Regex(pattern, RegexOptions.Compiled);
        }

        public bool IsFulfilled(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return _pattern.IsMatch(input);
        }

        #endregion
    }
}