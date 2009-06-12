using System;
using System.Text.RegularExpressions;

namespace DataFileTransformer.Expectation
{
    public class PatternExpectationEvaluator : IExpectationEvaluator
    {
        private readonly Regex _pattern;

        #region Implementation of IExpectationEvaluator

        public PatternExpectationEvaluator(string pattern)
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