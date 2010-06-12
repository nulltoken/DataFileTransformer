using System;
using DataFileTransformer.Transformation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Transformation
{
    [TestFixture]
    public class CopyTransformerFixture
    {
        [Test]
        [Row(new[] {""}, new[] {""})]
        [Row(new[] {" "}, new[] {" "})]
        [Row(new[] {"duMMy"}, new[] {"duMMy"})]
        [Row(new[] {" duMMy"}, new[] {" duMMy"})]
        [Row(new[] {" duMMy "}, new[] {" duMMy "})]
        [Row(new[] {"duMMy "}, new[] {"duMMy "})]
        public void TransformCorrectlyDealsWithNonNullsValues(string[] input, string[] expectedResult)
        {
            CopyTransformer trimTransformer = CreateSUT();
            Assert.AreEqual(expectedResult, trimTransformer.Transform(new ChunkContainer(input)).ToArray());
        }

        [Test]
        public void TransformThrowsWhenNullValueIsPassed()
        {
            CopyTransformer trimTransformer = CreateSUT();
            Assert.Throws<ArgumentNullException>(() => trimTransformer.Transform(null));
        }

        private static CopyTransformer CreateSUT()
        {
            return new CopyTransformer();
        }
    }
}