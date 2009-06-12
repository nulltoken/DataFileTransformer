using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests
{
    [TestFixture]
    public class DateTimeExpectationEvaluatorFixture
    {
        [Test]
        [Row("31/12/2009", "dd/MM/yyyy", true)]
        [Row("1/2/2009", "d/M/yyyy", true)]
        [Row("01/02/2009", "d/M/yyyy", true)]
        [Row("31/12/09", "dd/MM/yy", true)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValues(string input, string dateTimeFormat, bool expectedResult)
        {
            DateTimeExpectationEvaluator dateTimeExpectationEvaluator = CreateSUT(dateTimeFormat);
            Assert.AreEqual(expectedResult, dateTimeExpectationEvaluator.IsFulfilled(input));
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            DateTimeExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT("duMMy");
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectationEvaluator.IsFulfilled(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed()
        {
            
            Assert.Throws<ArgumentNullException>(() =>  CreateSUT(null));
        }

        private static DateTimeExpectationEvaluator CreateSUT(string dateFormat)
        {
            return new DateTimeExpectationEvaluator(dateFormat);
        }
    }
}
