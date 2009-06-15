using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class DateTimeExpectationEvaluatorFixture
    {
        [Test]
        [Row("31/12/2009", "dd/MM/yyyy", true)]
        [Row("1/2/2009", "d/M/yyyy", true)]
        [Row("01/02/2009", "d/M/yyyy", true)]
        [Row("31/12/09", "dd/MM/yy", true)]
        [Row("duMMY", "dd/MM/yy", false)]
        [Row("34/12/09", "dd/MM/yy", false)]
        [Row("29/02/09", "dd/MM/yy", false)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValues(string input, string dateTimeFormat,
                                                                 bool expectedResult)
        {
            IExpectationAccessor dateTimeExpectation = CreateSUT(dateTimeFormat);
            Assert.AreEqual(expectedResult, dateTimeExpectation.Expectation(input));
        }

        [Test]
        [Explicit]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            IExpectationAccessor dateTimeExpectation = CreateSUT("duMMy");
            Assert.Throws<ArgumentNullException>(() => dateTimeExpectation.Expectation(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null));
        }

        private static IExpectationAccessor CreateSUT(string dateFormat)
        {
            return new DateTimeExpectation(dateFormat);
        }
    }
}