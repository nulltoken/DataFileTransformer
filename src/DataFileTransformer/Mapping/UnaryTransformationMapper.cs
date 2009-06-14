using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class UnaryTransformationMapper : MapperBase
    {
        private readonly IUnaryTransformer _transformer;

        public UnaryTransformationMapper(IUnaryTransformer transformer, Placeholder source, Placeholder target)
            : base(source, target)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException("transformer");
            }

            _transformer = transformer;
        }

        protected override object Transformer
        {
            get { return _transformer; }
        }

        public override void Map()
        {
            string data = ExtractDataFrom(Source);
            string transformedData = PerformTransformation(data);
            StoreInto(Target, transformedData);
        }

        private string PerformTransformation(string data)
        {
            return _transformer.Transform(data);
        }
    }
}