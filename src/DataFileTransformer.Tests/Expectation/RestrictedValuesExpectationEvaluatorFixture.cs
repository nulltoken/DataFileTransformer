using System;
using System.Collections.Generic;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class RestrictedValuesExpectationEvaluatorFixture
    {
        [Test]
        [Row(new[] {"Hole", "in", "one"}, "golf", false)]
        [Row(new[] {"Hole", "in", "one"}, "In", false)]
        [Row(new[] {"Hole", "in", "one"}, "in", true)]
        [Row(new[] {"Hole", "in", " one"}, "one", false)]
        [Row(new[] {"Hole", "in", "one"}, "one ", false)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValuesInCaseSensitiveComparisonContext(
            string[] restrictedValues, string input, bool expectedResult)
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator = CreateSUT(restrictedValues, true);
            Assert.AreEqual(expectedResult, restrictedValuesExpectationEvaluator.IsFulfilled(input));
        }

        [Test]
        [Row(new[] {"Hole", "in", "one"}, "golf", false)]
        [Row(new[] {"Hole", "in", "one"}, "In", true)]
        [Row(new[] {"Hole", "in", "one"}, "in", true)]
        [Row(new[] {"Hole", "in", " one"}, "one", false)]
        [Row(new[] {"Hole", "in", "one"}, "one ", false)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValuesInCaseInsensitiveComparisonContext(
            string[] restrictedValues, string input, bool expectedResult)
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator = CreateSUT(restrictedValues,
                                                                                                  false);
            Assert.AreEqual(expectedResult, restrictedValuesExpectationEvaluator.IsFulfilled(input));
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator =
                CreateSUT(new[] {"Hole", "in", "one"}, true);
            Assert.Throws<ArgumentNullException>(() => restrictedValuesExpectationEvaluator.IsFulfilled(null));
        }

        [Test]
        public void ConstructorhrowsWhenNullValueIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(null, true));
        }

        private static RestrictedValuesExpectationEvaluator CreateSUT(IEnumerable<string> restrictedValues,
                                                                      bool isCaseSentive)
        {
            return new RestrictedValuesExpectationEvaluator(restrictedValues, isCaseSentive);
        }
    }
}