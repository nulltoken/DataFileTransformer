using System;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class PatternExpectationFixture
    {
        [Test]
        [Row("regex", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("regexp", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("regexp!", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("regexes", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("regular Expression", "reg(ular expressions?|ex(p|es)?)", false)]
        [Row("regular expression", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("-regular expression", "reg(ular expressions?|ex(p|es)?)", true)]
        [Row("regular expressions", "reg(ular expressions?|ex(p|es)?)", true)]
        public void IsFullFilledByCorrectlyDealsWithNonNullsValues(string input, string pattern,
                                                                   bool expectedResult)
        {
            IExpectation patternExpectation = CreateSUT(pattern);
            Assert.AreEqual(expectedResult, patternExpectation.VerifyFulfillmentOf(input).HasExpectationBeenFulfilled);
        }

        [Test]
        public void IsFullFilledByThrowsWhenNullValueIsPassed()
        {
            IExpectation patternExpectation = CreateSUT("duMMy");
            Assert.Throws<ArgumentNullException>(() => patternExpectation.VerifyFulfillmentOf(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null));
        }

        private static IExpectation CreateSUT(string pattern)
        {
            return new PatternExpectation(pattern);
        }
    }
}