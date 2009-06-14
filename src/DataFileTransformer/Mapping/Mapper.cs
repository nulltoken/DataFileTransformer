using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class Mapper : IMapper
    {
        private readonly PlaceHolder _source;
        private readonly PlaceHolder _target;
        private readonly IUnaryTransformer _transformer;

        public Mapper(IUnaryTransformer transformer, PlaceHolder source, PlaceHolder target)
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
            _target.FillWith(_transformer.Transform(_source.RetrieveContent()));
        }

        #endregion
    }
}