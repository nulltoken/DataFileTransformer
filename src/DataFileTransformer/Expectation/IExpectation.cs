using System;

namespace DataFileTransformer.Expectation
{
    public interface IExpectation
    {
        bool IsFulfilledBy(string input);
    }
}