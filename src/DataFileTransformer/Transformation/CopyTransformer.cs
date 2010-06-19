using System;

namespace DataFileTransformer.Transformation
{
    public class CopyTransformer : TransformerBase
    {
        protected override Func<ChunkContainer, ChunkContainer> Transformer
        {
            get { return input => input; }
        }
    }
}