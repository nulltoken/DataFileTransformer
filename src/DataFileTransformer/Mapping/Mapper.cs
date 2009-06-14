using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class Mapper : IMapper
    {
        private readonly Placeholder _source;
        private readonly Placeholder _target;
        private readonly IUnaryTransformer _transformer;

        public Mapper(IUnaryTransformer transformer, Placeholder source, Placeholder target)
        {
            if (transformer == null)
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

        #region IMapper Members

        public void Map()
        {
            string data = ExtractDataFrom(_source);
            string transformedData = PerformTransformation(data);
            StoreInto(_target, transformedData);
        }

        private string PerformTransformation(string data)
        {
            return _transformer.Transform(data);
        }

        #endregion

        private void StoreInto(Placeholder placeholder, string data)
        {
            try
            {
                placeholder.FillWith(data);
            }
            catch (InvalidPlaceholderStateException e)
            {
                throw new InvalidOperationException(
                    string.Format("Can not apply '{0}' transformation.", _transformer.GetType().FullName), e);
            }
        }

        private string ExtractDataFrom(Placeholder placeholder)
        {
            try
            {
                return placeholder.RetrieveContent();
            }
            catch (InvalidPlaceholderStateException e)
            {
                throw new InvalidOperationException(
                    string.Format("Can not apply '{0}' transformation.", _transformer.GetType().FullName), e);
            }
        }
    }
}