using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class MandatoryExpectationEvaluatorFixture
    {
        [Test]
        [Row("", Status.Failed)]
        [Row(" ", Status.Passed)]
        [Row("duMMy", Status.Passed)]
        [Row("3.5", Status.Passed)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValues(string input, Status expectedResult)
        {
            MandatoryExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT();
            Assert.AreEqual(expectedResult, mandatoryExpectationEvaluator.Evaluate(input).Status);
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            MandatoryExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectationEvaluator.Evaluate(null));
        }

        private static MandatoryExpectationEvaluator CreateSUT()
        {
            return new MandatoryExpectationEvaluator();
        }
    }
}