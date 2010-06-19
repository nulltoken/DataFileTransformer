using System;

namespace DataFileTransformer.Transformation
{
    public abstract class TransformerBase : ITransformer
    {
        protected abstract Func<ChunkContainer, ChunkContainer> Transformer { get; }

        #region ITransformer Members

        public ChunkContainer Transform(ChunkContainer source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return Transformer(source);
        }

        #endregion
    }
}