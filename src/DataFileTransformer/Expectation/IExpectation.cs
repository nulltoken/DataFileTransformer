using System;

namespace DataFileTransformer.Expectation
{
    public interface IExpectation
    {
        Func<string, bool> IsFulfilledBy { get; }
    }
}