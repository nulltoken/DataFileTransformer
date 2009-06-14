using System;
using System.Globalization;

namespace DataFileTransformer.Mapping
{
    public abstract class MapperBase : IMapper
    {
        private readonly Placeholder _source;
        private readonly Placeholder _target;


        protected MapperBase(Placeholder source, Placeholder target)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (target == null)
            {
                throw new ArgumentNullException("target");
            }

            _source = source;
            _target = target;
        }

        protected abstract object Transformer { get; }

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
                    BuildExceptionMessage(Transformer), e);
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
                    BuildExceptionMessage(Transformer), e);
            }
        }


        private static string BuildExceptionMessage(object transformer)
        {
            return string.Format(CultureInfo.InvariantCulture, "Can not apply '{0}' transformation.", transformer.GetType().FullName);
        }
    }
}