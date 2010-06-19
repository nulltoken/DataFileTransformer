using System.Collections.Generic;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectation : PatternExpectation
    {
        private static string pattern = ".+";

        public MandatoryExpectation() : base(pattern)
        {
        }

        protected override string ErrorMessageFormat
        {
            get { return "Input data is empty."; }
        }

        protected override IEnumerable<string> ErrorMessageAdditionalParameters
        {
            get { yield break; }
        }
    }
}