namespace DataFileTransformer.Expectation
{
    public interface IExpectationEvaluator
    {
        EvaluationResult Evaluate(string input);
    }
}