using System;

namespace DataFileTransformer.Expectation
{
    public class MandatoryExpectationEvaluator : IExpectationEvaluator
    {
        #region Implementation of IExpectationEvaluator

        public EvaluationResult Evaluate(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (input.Length == 0)
            {
                return new EvaluationResult(Status.Failed);
                ;
            }

            return new EvaluationResult(Status.Passed);
            ;
            ;
        }

        #endregion
    }
}