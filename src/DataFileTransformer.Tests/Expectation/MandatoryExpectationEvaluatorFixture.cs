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
            IExpectationAccessor mandatoryExpectation = CreateSUT();
            Assert.AreEqual(expectedResult, mandatoryExpectation.Expectation(input));
        }

        [Test]
        [Explicit]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            IExpectationAccessor mandatoryExpectation = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectation.Expectation(null));
        }

        private static IExpectationAccessor CreateSUT()
        {
            return new MandatoryExpectation();
        }
    }
}