using System;
using System.Text.RegularExpressions;

namespace DataFileTransformer.Expectation
{
    public class PatternExpectation : IExpectationAccessor
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

        #region Implementation of IExpectationAccessor

        public Func<string, bool> Expectation
        {
            get { return input => _pattern.IsMatch(input); }
        }

        #endregion
    }
}