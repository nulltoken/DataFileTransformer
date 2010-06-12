using System;

namespace DataFileTransformer.Transformation
{
    public class CopyTransformer : ITransformer
    {
        #region Implementation of ITransformer

        public ChunkContainer Transform(ChunkContainer source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source;
        }

        #endregion
    }
}