using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class DateTimeExpectationFixture
    {
        [Test]
        [Row("31/12/2009", "dd/MM/yyyy", true)]
        [Row("1/2/2009", "d/M/yyyy", true)]
        [Row("01/02/2009", "d/M/yyyy", true)]
        [Row("31/12/09", "dd/MM/yy", true)]
        [Row("duMMY", "dd/MM/yy", false)]
        [Row("34/12/09", "dd/MM/yy", false)]
        [Row("29/02/09", "dd/MM/yy", false)]
        public void IsFullFilledByCorrectlyDealsWithNonNullsValues(string input, string dateTimeFormat,
                                                                   bool expectedResult)
        {
            IExpectation dateTimeExpectation = CreateSUT(dateTimeFormat);
            Assert.AreEqual(expectedResult, dateTimeExpectation.VerifyFulfillmentOf(input).HasExpectationBeenFulfilled);
        }

        [Test]
        public void IsFullFilledByThrowsWhenNullValueIsPassed()
        {
            IExpectation dateTimeExpectation = CreateSUT("duMMy");
            Assert.Throws<ArgumentNullException>(() => dateTimeExpectation.VerifyFulfillmentOf(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null));
        }

        private static IExpectation CreateSUT(string dateFormat)
        {
            return new DateTimeExpectation(dateFormat);
        }
    }
}