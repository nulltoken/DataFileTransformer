using System;
using System.Globalization;

namespace DataFileTransformer.Expectation
{
    public class DateTimeExpectationEvaluator : IExpectationEvaluator
    {
        private readonly string _dateFormat;

        public DateTimeExpectationEvaluator(string dateFormat)
        {
            if (dateFormat == null)
            {
                throw new ArgumentNullException("dateFormat");
            }
            _dateFormat = dateFormat;
        }

        #region Implementation of IExpectationEvaluator

        public EvaluationResult Evaluate(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (!IsValidDate(input, _dateFormat))
            {
                return new EvaluationResult(Status.Failed);
            }

            return new EvaluationResult(Status.Passed);
        }

        private static bool IsValidDate(string input, string dateFormat)
        {
            DateTime parsedDateTime;
            return DateTime.TryParseExact(input, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                                          out parsedDateTime);
        }

        #endregion
    }
}