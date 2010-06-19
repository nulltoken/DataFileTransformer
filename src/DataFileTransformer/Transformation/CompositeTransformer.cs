using System.Collections.Generic;

namespace DataFileTransformer.Transformation
{
    public class CompositeTransformer : CompositeBase<ITransformer>, ITransformer
    {
        public CompositeTransformer(ITransformer transformer)
            : this(new[] {transformer})
        {
        }

        private CompositeTransformer(IEnumerable<ITransformer> transformers)
            : base(transformers)
        {
        }

        #region ITransformer Members

        public ChunkContainer Transform(ChunkContainer source)
        {
            ChunkContainer result = source;

            foreach (ITransformer transformer in Components)
            {
                result = transformer.Transform(result);
            }

            return result;
        }

        #endregion

        protected override CompositeBase<ITransformer> BuildComposite(IEnumerable<ITransformer> components)
        {
            return new CompositeTransformer(components);
        }

        public override ITransformer Build()
        {
            return this;
        }
    }
}