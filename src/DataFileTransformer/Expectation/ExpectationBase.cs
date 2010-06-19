using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataFileTransformer.Expectation
{
    public abstract class ExpectationBase : IExpectation
    {
        #region Implementation of IExpectation

        public ExpectationResult VerifyFulfillmentOf(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return BuildResult(input);
        }

        #endregion

        protected abstract string ErrorMessageFormat { get; }

        protected abstract Func<string, bool> ExpectationVerifier { get; }

        protected abstract IEnumerable<string> ErrorMessageAdditionalParameters { get; }

        private ExpectationResult BuildResult(string input)
        {
            bool hasExpectationBeenMet = ExpectationVerifier(input);

            if (hasExpectationBeenMet)
            {
                return new ExpectationResult();
            }

            return BuildInvalidResult(input);
        }

        protected ExpectationResult BuildInvalidResult(string input)
        {
            object[] errorMessageParameters = BuildErrorMessageParameters(input);

            return new ExpectationResult(string.Format(CultureInfo.InvariantCulture,
                                                                   ErrorMessageFormat,
                                                                   errorMessageParameters));
        }

        private object[] BuildErrorMessageParameters(string input)
        {
            var errorMessageParameters = new List<string> {input};
            errorMessageParameters.AddRange(ErrorMessageAdditionalParameters);
            return errorMessageParameters.ToArray();
        }
    }
}