using System;

namespace DataFileTransformer.Expectation
{
    public interface IExpectationAccessor
    {
        Func<string, bool> Expectation { get; }
    }
}