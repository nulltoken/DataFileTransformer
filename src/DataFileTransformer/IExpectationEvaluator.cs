using DataFileTransformer.Expectation;

namespace DataFileTransformer
{
    public interface IExpectationEvaluator
    {
        EvaluationResult Evaluate(IExpectation expectation, Placeholder input);
    }
}