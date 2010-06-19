using System;

namespace DataFileTransformer.Transformation
{
    public class JoinTransformer : TransformerBase
    {
        private readonly string _separator;

        public JoinTransformer(string separator)
        {
            _separator = separator;
        }

        protected override Func<ChunkContainer, ChunkContainer> Transformer
        {
            get { return input => new ChunkContainer(new[] {string.Join(_separator, input.ToArray())}); }
        }
    }
}