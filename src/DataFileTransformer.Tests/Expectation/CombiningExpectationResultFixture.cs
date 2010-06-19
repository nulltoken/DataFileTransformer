using System.Linq;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class CombiningExpectationResultFixture
    {
        [Test]
        public void ValidWithValidWithValid()
        {
            ExpectationResult a = CreateValidSUT();
            ExpectationResult b = CreateValidSUT();
            ExpectationResult c = CreateValidSUT();

            ExpectationResult result = a.CombineWith(b).CombineWith(c);

            Assert.AreEqual(true, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreEqual(ExpectationResult.EXPECTATION_MET, result.Messages.First());
        }

        [Test]
        public void InvalidWithValidWithValid()
        {
            ExpectationResult a = CreateInvalidSUT("a");
            ExpectationResult b = CreateValidSUT();
            ExpectationResult c = CreateValidSUT();

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"a"}, result.Messages);
        }

        [Test]
        public void ValidWithInvalidWithValid()
        {
            ExpectationResult a = CreateValidSUT();
            ExpectationResult b = CreateInvalidSUT("b");
            ExpectationResult c = CreateValidSUT();

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"b"}, result.Messages);
        }

        [Test]
        public void ValidWithValidWithInvalid()
        {
            ExpectationResult a = CreateValidSUT();
            ExpectationResult b = CreateValidSUT();
            ExpectationResult c = CreateInvalidSUT("c");

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"c"}, result.Messages);
        }

        [Test]
        public void InvalidWithInvalidWithValid()
        {
            ExpectationResult a = CreateInvalidSUT("a");
            ExpectationResult b = CreateInvalidSUT("b");
            ExpectationResult c = CreateValidSUT();

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(2, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"a", "b"}, result.Messages);
        }

        [Test]
        public void ValidWithInvalidWithInvalid()
        {
            ExpectationResult a = CreateValidSUT();
            ExpectationResult b = CreateInvalidSUT("b");
            ExpectationResult c = CreateInvalidSUT("c");

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(2, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"b", "c"}, result.Messages);
        }

        [Test]
        public void InvalidWithInvalidWithInvalid()
        {
            ExpectationResult a = CreateInvalidSUT("a");
            ExpectationResult b = CreateInvalidSUT("b");
            ExpectationResult c = CreateInvalidSUT("c");

            ExpectationResult result = a.CombineWith(b).CombineWith(c);
            Assert.AreEqual(false, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(3, result.Messages.Count());
            Assert.AreElementsEqual(new[] {"a", "b", "c"}, result.Messages);
        }

        private static ExpectationResult CreateValidSUT()
        {
            return new ExpectationResult();
        }

        private static ExpectationResult CreateInvalidSUT(string message)
        {
            return new ExpectationResult(message);
        }
    }
}