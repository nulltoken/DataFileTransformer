using System;
using System.Globalization;

namespace DataFileTransformer.Expectation
{
    public class DateTimeExpectation : IExpectation
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

        #region Implementation of IExpectation

        public Func<string, bool> IsFulfilledBy
        {
            get { return input => IsValidDate(input, _dateFormat); }
        }

        #endregion
    }
}