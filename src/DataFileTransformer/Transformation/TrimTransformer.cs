﻿using System;
using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class TrimTransformer : ITransformer
    {
        #region Implementation of ITransformer

        public ChunkContainer Transform(ChunkContainer source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var chunks = new List<string>();

            foreach (string data in source.ToArray())
            {
                chunks.Add(data.Trim());
            }

            return new ChunkContainer(chunks);
        }

        #endregion
    }
}