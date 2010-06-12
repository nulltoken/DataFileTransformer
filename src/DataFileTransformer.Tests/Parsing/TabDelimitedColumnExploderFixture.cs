using System;
using System.Collections.Generic;
using DataFileTransformer.Transformation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Parsing
{
    [TestFixture]
    public class TabDelimitedColumnExploderFixture
    {
        private const char TAB = ((char) 9);
        private readonly ITransformer _columnExploder = CreateSUT(TAB);

        [Test]
        [Row("a\tb", new[] {"a", "b"})]
        [Row("", new[] {""})]
        [Row("\t", new[] {"", ""})]
        [Row("aaa", new[] {"aaa"})]
        [Row("a\tb\tc", new[] {"a", "b", "c"})]
        [Row("a\tb\tc\t", new[] {"a", "b", "c", ""})]
        public void ExplodeShouldReturnExpectedListOfPieces(string input, ICollection<string> expectedOutput)
        {
            Assert.AreEqual(expectedOutput, _columnExploder.Transform(new ChunkContainer(new[] {input})).ToArray());
        }

        [Test]
        public void ExplodeThrowsWhenNullParametersIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => _columnExploder.Transform(null));
        }

        private static ITransformer CreateSUT(char delimiter)
        {
            return new SplitTransformer(delimiter);
        }
    }
}