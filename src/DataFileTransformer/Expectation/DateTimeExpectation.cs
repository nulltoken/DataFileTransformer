using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataFileTransformer.Expectation
{
    public class DateTimeExpectation : ExpectationBase
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

        protected override string ErrorMessageFormat
        {
            get { return "Input data '{0}' is not a valid date according to format '{1}'."; }
        }

        protected override Func<string, bool> ExpectationVerifier
        {
            get { return input => IsDateValid(input, _dateFormat); }
        }

        protected override IEnumerable<string> ErrorMessageAdditionalParameters
        {
            get { yield return _dateFormat; }
        }

        private static bool IsDateValid(string input, string dateFormat)
        {
            DateTime parsedDateTime;
            return DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                                          out parsedDateTime);
        }
    }
}