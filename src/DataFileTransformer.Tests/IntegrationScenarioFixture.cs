using DataFileTransformer.Parsing;
using DataFileTransformer.Transformation;
using MbUnit.Framework;

namespace DataFileTransformer.Tests
{
    [TestFixture]
    public class IntegrationScenarioFixture
    {
        [Test]
        [Row("a,b,c", "ba-c")]
        [Row(" a  , b,c   ", "ba-c")]
        public void Scenario1(string input, string expectedOutput)
        {
            var splitter = new SplitTransformer(',');
            var trimmer = new TrimTransformer();
            ITransformer compositeTransformer =
                new CompositeTransformerBuilder(splitter)
                    .ComposeWith(trimmer)
                    .Build();

            var parser = new RowParser(3, AdditionalColumnsProcessing.Skip, compositeTransformer);
            ChunkContainer splittedChunks = parser.Parse(input);

            ITransformer emptyJoiner = new JoinTransformer("");
            ChunkContainer joined =
                emptyJoiner.Transform(new ChunkContainer(new[] {splittedChunks[1], splittedChunks[0]}));

            ITransformer dashJoiner = new JoinTransformer("-");
            ChunkContainer joined2 = dashJoiner.Transform(joined.Add(splittedChunks[2]));

            Assert.AreEqual(1, joined2.Count);
            Assert.AreEqual(expectedOutput, joined2[0]);
        }
    }
}