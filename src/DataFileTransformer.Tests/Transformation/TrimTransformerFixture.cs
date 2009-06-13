using System;
using DataFileTransformer.Transformation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Transformation
{
    [TestFixture]
    public class TrimTransformerFixture
    {
        [Test]
        [Row("", "")]
        [Row(" ", "")]
        [Row("duMMy", "duMMy")]
        [Row(" 3.5", "3.5")]
        [Row(" 3.5 ", "3.5")]
        [Row("3.5 ", "3.5")]
        public void TransformCorrectlyDealsWithNonNullsValues(string input, string expectedResult)
        {
            TrimTransformer trimTransformer = CreateSUT();
            Assert.AreEqual(expectedResult, trimTransformer.Transform(input));
        }

        [Test]
        public void TransformThrowsWhenNullValueIsPassed()
        {
            TrimTransformer trimTransformer = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => trimTransformer.Transform(null));
        }

        private static TrimTransformer CreateSUT()
        {
            return new TrimTransformer();
        }
    }
}