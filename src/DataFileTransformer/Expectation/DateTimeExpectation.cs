using System;
using System.Globalization;

namespace DataFileTransformer.Expectation
{
    public class DateTimeExpectation : IExpectationAccessor
    {
        private readonly string _dateFormat;

        public DateTimeExpectation(string dateFormat)
        {
            if (dateFormat == null)
            {
                throw new ArgumentNullException("dateFormat");
            }

            _dateFormat = dateFormat;
        }

        private static bool IsValidDate(string input, string dateFormat)
        {
            DateTime parsedDateTime;
            return DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                                          out parsedDateTime);
        }

        #region Implementation of IExpectationAccessor

        public Func<string, bool> Expectation
        {
            get { return input => IsValidDate(input, _dateFormat); }
        }

        #endregion
    }
}