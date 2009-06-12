namespace DataFileTransformer.Expectation
{
    public interface IExpectationEvaluator
    {
        bool IsFulfilled(string input);
    }
}