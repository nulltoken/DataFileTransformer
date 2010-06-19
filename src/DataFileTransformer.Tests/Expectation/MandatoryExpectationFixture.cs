using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class MandatoryExpectationFixture
    {
        [Test]
        [Row("", false)]
        [Row(" ", true)]
        [Row("duMMy", true)]
        [Row("3.5", true)]
        public void IsFullFilledByCorrectlyDealsWithNonNullsValues(string input,
                                                                   bool expectedResult)
        {
            IExpectation mandatoryExpectation = CreateSUT();
            Assert.AreEqual(expectedResult, mandatoryExpectation.VerifyFulfillmentOf(input).HasExpectationBeenFulfilled);
        }

        [Test]
        public void IsFullFilledByThrowsWhenNullValueIsPassed()
        {
            IExpectation mandatoryExpectation = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectation.VerifyFulfillmentOf(null));
        }

        private static IExpectation CreateSUT()
        {
            return new MandatoryExpectation();
        }
    }
}