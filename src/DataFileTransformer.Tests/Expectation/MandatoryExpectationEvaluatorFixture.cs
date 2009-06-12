using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class MandatoryExpectationEvaluatorFixture
    {
        [Test]
        [Row("", false)]
        [Row(" ", true)]
        [Row("duMMy", true)]
        [Row("3.5", true)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValues(string input, bool expectedResult)
        {
            MandatoryExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT();
            Assert.AreEqual(expectedResult, mandatoryExpectationEvaluator.IsFulfilled(input));
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            MandatoryExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectationEvaluator.IsFulfilled(null));
        }

        private static MandatoryExpectationEvaluator CreateSUT()
        {
            return new MandatoryExpectationEvaluator();
        }
    }
}