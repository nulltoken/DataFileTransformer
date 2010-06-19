using System;
using System.Collections.Generic;
using System.Linq;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class InvalidExpectationResultFixture
    {
        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed1()
        {
            const IEnumerable<string> input = null;
            Assert.Throws<ArgumentNullException>(() => CreateSUT(input));
        }

        [Test]
        public void ConstructorThrowsWhenNullValueIsPassed2()
        {
            IEnumerable<string> input = new[] {"a", null};
            Assert.Throws<ArgumentException>(() => CreateSUT(input));
        }

        [Test]
        public void ConstructorThrowsWhenEmptyValueIsPassed1()
        {
            const string input = "";
            Assert.Throws<ArgumentException>(() => CreateSUT(input));
        }

        [Test]
        public void ConstructorThrowsWhenEmptyValueIsPassed2()
        {
            IEnumerable<string> input = new[] {"a", string.Empty};
            Assert.Throws<ArgumentException>(() => CreateSUT(input));
        }

        [Test]
        [Row("Other_duMMY")]
        public void PropertiesMatchConstructorParameters1(string expectedMessage)
        {
            ExpectationResult result = CreateSUT(expectedMessage);

            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreEqual(expectedMessage, result.Messages.First());
        }

        [Test]
        [Row("", new[] {"Other_duMMY"})]
        public void PropertiesMatchConstructorParameters2(string huh, string[] expectedMessages)
        {
            ExpectationResult result = CreateSUT(expectedMessages);

            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(expectedMessages.Count(), result.Messages.Count());
            Assert.AreElementsEqual(expectedMessages, result.Messages);
        }

        [Test]
        [Row("d", "u", "m", new[] {"d", "u", "m"})]
        public void CombineWithProperlyOrderTheMessages1(string message1, string message2, string message3,
                                                         string[] expectedMessages)
        {
            ExpectationResult result = CreateSUT(message1);
            result = result.CombineWith(CreateSUT(message2));
            result = result.CombineWith(CreateSUT(message3));

            Assert.AreElementsEqual(expectedMessages, result.Messages);
        }

        [Test]
        [Row(new[] {"d"}, new[] {"u"}, new[] {"m"}, new[] {"d", "u", "m"})]
        [Row(new[] {"d", "u"}, new[] {"m"}, new[] {"M", "y"}, new[] {"d", "u", "m", "M", "y"})]
        public void CombineWithProperlyOrderTheMessages1(string[] message1, string[] message2, string[] message3,
                                                         string[] expectedMessages)
        {
            ExpectationResult result = CreateSUT(message1);
            result = result.CombineWith(CreateSUT(message2));
            result = result.CombineWith(CreateSUT(message3));

            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreElementsEqual(expectedMessages, result.Messages);
        }

        private static ExpectationResult CreateSUT(IEnumerable<string> messages)
        {
            return new ExpectationResult(messages);
        }

        private static ExpectationResult CreateSUT(string message)
        {
            return new ExpectationResult(message);
        }
    }
}