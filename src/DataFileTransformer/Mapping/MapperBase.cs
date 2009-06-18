using System;
using System.Globalization;

namespace DataFileTransformer.Mapping
{
    public abstract class MapperBase<TTransformer> : IMapper
    {
        private readonly TTransformer _transformer;
        private readonly Placeholder _source;
        private readonly Placeholder _target;


        protected MapperBase(TTransformer transformer, Placeholder source, Placeholder target)
        {
            if (Equals(transformer,default(TTransformer)))
            {
                throw new ArgumentNullException("transformer");
            }
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            _transformer = transformer;
            _source = source;
            _target = target;
        }

        protected TTransformer Transformer
        {
            get { return _transformer; }
        }

        protected Placeholder Target
        {
            get { return _target; }
        }

        protected Placeholder Source
        {
            get { return _source; }
        }

        #region Implementation of IMapper

        public abstract void Map();

        #endregion

        protected void StoreInto(Placeholder placeholder, string data)
        {
            try
            {
                placeholder.FillWith(data);
            }
            catch (InvalidPlaceholderStateException e)
            {
                throw new InvalidOperationException(
                    BuildExceptionMessage(), e);
            }
        }

        protected string ExtractDataFrom(Placeholder placeholder)
        {
            try
            {
                return placeholder.RetrieveContent();
            }
            catch (InvalidPlaceholderStateException e)
            {
                throw new InvalidOperationException(
                    BuildExceptionMessage(), e);
            }
        }


        private string BuildExceptionMessage()
        {
            return string.Format(CultureInfo.InvariantCulture, "Can not apply '{0}' transformation.",
                                 _transformer.GetType().FullName);
        }
    }
}