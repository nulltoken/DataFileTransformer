﻿using System;
using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class SplitTransformer : TransformerBase
    {
        private readonly char _separator;

        public SplitTransformer(char separator)
        {
            _separator = separator;
        }

        protected override Func<ChunkContainer, ChunkContainer> Transformer
        {
            get { return Splitter; }
        }

        private ChunkContainer Splitter(ChunkContainer source)
        {
            var splitted = new List<string>();

            foreach (string data in source.ToArray())
            {
                splitted.AddRange(data.Split(_separator));
            }

            return new ChunkContainer(splitted);
        }
    }
}