using System;
using DataFileTransformer.Transformation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Transformation
{
    [TestFixture]
    public class TrimTransformerFixture
    {
        [Test]
        [Row(new[] {""}, new[] {""})]
        [Row(new[] {" "}, new[] {""})]
        [Row(new[] {"duMMy"}, new[] {"duMMy"})]
        [Row(new[] {" 3.5"}, new[] {"3.5"})]
        [Row(new[] {" 3.5 "}, new[] {"3.5"})]
        [Row(new[] {"3.5 "}, new[] {"3.5"})]
        public void TransformCorrectlyDealsWithNonNullsValues(string[] input, string[] expectedResult)
        {
            TrimTransformer trimTransformer = CreateSUT();
            Assert.AreEqual(expectedResult, trimTransformer.Transform(new ChunkContainer(input)).ToArray());
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