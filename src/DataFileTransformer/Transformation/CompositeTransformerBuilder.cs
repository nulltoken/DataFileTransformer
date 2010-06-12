using System;
using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class CompositeTransformerBuilder
    {
        private readonly IList<ITransformer> _transformers = new List<ITransformer>();

        public CompositeTransformerBuilder(ITransformer transformer)
        {
            ComposeWith(transformer);
        }

        public CompositeTransformerBuilder ComposeWith(ITransformer transformer)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException("transformer");
            }

            _transformers.Add(transformer);

            return this;
        }

        public ITransformer Build()
        {
            return new CompositeTransformer(_transformers);
        }

        #region Nested type: CompositeTransformer

        private class CompositeTransformer : ITransformer
        {
            private readonly IList<ITransformer> _transformers = new List<ITransformer>();

            public CompositeTransformer(IList<ITransformer> transformers)
            {
                if (transformers == null)
                {
                    throw new ArgumentNullException("transformers");
                }

                _transformers = transformers;
            }

            #region ITransformer Members

            public ChunkContainer Transform(ChunkContainer source)
            {
                ChunkContainer result = source;

                foreach (ITransformer transformer in _transformers)
                {
                    result = transformer.Transform(result);
                }

                return result;
            }

            #endregion
        }

        #endregion
    }
}