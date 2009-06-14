using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class DateTimeExpectationEvaluatorFixture
    {
        [Test]
        [Row("31/12/2009", "dd/MM/yyyy", Status.Passed)]
        [Row("1/2/2009", "d/M/yyyy", Status.Passed)]
        [Row("01/02/2009", "d/M/yyyy", Status.Passed)]
        [Row("31/12/09", "dd/MM/yy", Status.Passed)]
        [Row("duMMY", "dd/MM/yy", Status.Failed)]
        [Row("34/12/09", "dd/MM/yy", Status.Failed)]
        [Row("29/02/09", "dd/MM/yy", Status.Failed)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValues(string input, string dateTimeFormat,
                                                                 Status expectedResult)
        {
            DateTimeExpectationEvaluator dateTimeExpectationEvaluator = CreateSUT(dateTimeFormat);
            Assert.AreEqual(expectedResult, dateTimeExpectationEvaluator.Evaluate(input).Status);
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            DateTimeExpectationEvaluator mandatoryExpectationEvaluator = CreateSUT("duMMy");
            Assert.Throws<ArgumentNullException>(() => mandatoryExpectationEvaluator.Evaluate(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null));
        }

        private static DateTimeExpectationEvaluator CreateSUT(string dateFormat)
        {
            return new DateTimeExpectationEvaluator(dateFormat);
        }
    }
}