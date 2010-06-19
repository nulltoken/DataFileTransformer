namespace DataFileTransformer.Expectation
{
    public interface IExpectation
    {
        ExpectationResult VerifyFulfillmentOf(string input);
    }
}