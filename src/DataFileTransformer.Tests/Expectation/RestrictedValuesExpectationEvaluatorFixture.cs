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
        [Row(new[] {"Hole", "in", "one"}, "golf", Status.Failed)]
        [Row(new[] {"Hole", "in", "one"}, "In", Status.Failed)]
        [Row(new[] {"Hole", "in", "one"}, "in", Status.Passed)]
        [Row(new[] {"Hole", "in", " one"}, "one", Status.Failed)]
        [Row(new[] {"Hole", "in", "one"}, "one ", Status.Failed)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValuesInCaseSensitiveComparisonContext(
            string[] restrictedValues, string input, Status expectedResult)
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator = CreateSUT(restrictedValues, true);
            Assert.AreEqual(expectedResult, restrictedValuesExpectationEvaluator.Evaluate(input).Status);
        }

        [Test]
        [Row(new[] {"Hole", "in", "one"}, "golf", Status.Failed)]
        [Row(new[] {"Hole", "in", "one"}, "In", Status.Passed)]
        [Row(new[] {"Hole", "in", "one"}, "in", Status.Passed)]
        [Row(new[] {"Hole", "in", " one"}, "one", Status.Failed)]
        [Row(new[] {"Hole", "in", "one"}, "one ", Status.Failed)]
        public void IsFullFilledCorrectlyDealsWithNonNullsValuesInCaseInsensitiveComparisonContext(
            string[] restrictedValues, string input, Status expectedResult)
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator = CreateSUT(restrictedValues,
                                                                                                  false);
            Assert.AreEqual(expectedResult, restrictedValuesExpectationEvaluator.Evaluate(input).Status);
        }

        [Test]
        public void IsFullFilledThrowsWhenNullValueIsPassed()
        {
            RestrictedValuesExpectationEvaluator restrictedValuesExpectationEvaluator =
                CreateSUT(new[] {"Hole", "in", "one"}, true);
            Assert.Throws<ArgumentNullException>(() => restrictedValuesExpectationEvaluator.Evaluate(null));
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