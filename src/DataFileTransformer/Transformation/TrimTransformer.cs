using System;
using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class TrimTransformer : TransformerBase
    {
        protected override Func<ChunkContainer, ChunkContainer> Transformer
        {
            get { return Trimmer; }
        }

        private static ChunkContainer Trimmer(ChunkContainer source)
        {
            var chunks = new List<string>();

            foreach (string data in source.ToArray())
            {
                chunks.Add(data.Trim());
            }

            return new ChunkContainer(chunks);
        }
    }
}