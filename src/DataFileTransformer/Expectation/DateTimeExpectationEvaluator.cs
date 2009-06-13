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

            DateTime parsedDateTime;
            if (!DateTime.TryParseExact(input, _dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None,
                                        out parsedDateTime))
            {
                return new EvaluationResult(Status.Failed);
            }

            return new EvaluationResult(Status.Passed);
        }

        #endregion
    }
}