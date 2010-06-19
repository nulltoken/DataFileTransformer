using System.Linq;
using DataFileTransformer.Expectation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    [TestFixture]
    public class ValidExpectationResultFixture
    {
        [Test]
        public void DefaultConstructorUsageShouldRenderDefaultProperties()
        {
            ExpectationResult result = CreateSUT();

            Assert.AreEqual(true, result.HasExpectationBeenFulfilled);
            Assert.AreEqual(1, result.Messages.Count());
            Assert.AreEqual(ExpectationResult.EXPECTATION_MET, result.Messages.First());
        }

        private static ExpectationResult CreateSUT()
        {
            return new ExpectationResult();
        }
    }
}