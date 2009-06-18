using System;
using System.Collections.Generic;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class RestrictedValuesExpectationFixture
    {
        [Test]
        [Row(new[] {"Hole", "in", "one"}, "golf", false)]
        [Row(new[] {"Hole", "in", "one"}, "In", false)]
        [Row(new[] {"Hole", "in", "one"}, "in", true)]
        [Row(new[] {"Hole", "in", " one"}, "one", false)]
        [Row(new[] {"Hole", "in", "one"}, "one ", false)]
        public void IsFullFilledByCorrectlyDealsWithNonNullsValuesInCaseSensitiveComparisonContext(
            string[] restrictedValues, string input, bool expectedResult)
        {
            IExpectation restrictedValuesExpectation = CreateSUT(restrictedValues, true);
            Assert.AreEqual(expectedResult, restrictedValuesExpectation.IsFulfilledBy(input));
        }

        [Test]
        [Row(new[] {"Hole", "in", "one"}, "golf", false)]
        [Row(new[] {"Hole", "in", "one"}, "In", true)]
        [Row(new[] {"Hole", "in", "one"}, "in", true)]
        [Row(new[] {"Hole", "in", " one"}, "one", false)]
        [Row(new[] {"Hole", "in", "one"}, "one ", false)]
        public void IsFullFilledByCorrectlyDealsWithNonNullsValuesInCaseInsensitiveComparisonContext(
            string[] restrictedValues, string input, bool expectedResult)
        {
            IExpectation restrictedValuesExpectation = CreateSUT(restrictedValues,
                                                                 false);
            Assert.AreEqual(expectedResult, restrictedValuesExpectation.IsFulfilledBy(input));
        }

        [Test]
        public void IsFullFilledByThrowsWhenNullValueIsPassed()
        {
            IExpectation restrictedValuesExpectation =
                CreateSUT(new[] {"Hole", "in", "one"}, true);
            Assert.Throws<ArgumentNullException>(() => restrictedValuesExpectation.IsFulfilledBy(null));
        }

        [Test]
        public void ConstructorhrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null, true));
        }

        private static IExpectation CreateSUT(IEnumerable<string> restrictedValues,
                                              bool isCaseSentive)
        {
            return new RestrictedValuesExpectation(restrictedValues, isCaseSentive);
        }
    }
}