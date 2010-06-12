using System;
using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class SplitTransformer : ITransformer
    {
        private readonly char _separator;

        public SplitTransformer(char separator)
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

            var splitted = new List<string>();

            foreach (string data in source.ToArray())
            {
                splitted.AddRange(data.Split(_separator));
            }

            return new ChunkContainer(splitted);
        }

        #endregion
    }
}