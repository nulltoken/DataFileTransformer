using System;

namespace DataFileTransformer.Transformation
{
    public class JoinTransformer : ITransformer
    {
        private readonly string _separator;


        public JoinTransformer(string separator)
        {
            _separator = separator;
        }

        #region Implementation of ITransformer

        public ChunkContainer Transform(ChunkContainer source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return new ChunkContainer(new[] {string.Join(_separator, source.ToArray())});
        }

        #endregion
    }
}