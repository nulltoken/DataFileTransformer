using System;
using System.Text.RegularExpressions;

namespace DataFileTransformer.Expectation
{
    public class PatternExpectation : IExpectation
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

        #region Implementation of IExpectation

        bool IExpectation.IsFulfilledBy(string input)
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