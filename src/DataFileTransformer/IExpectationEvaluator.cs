using DataFileTransformer.Expectation;

namespace DataFileTransformer
{
    public interface IExpectationEvaluator
    {
        EvaluationResult Evaluate(IExpectationAccessor expectation, Placeholder input);
    }
}