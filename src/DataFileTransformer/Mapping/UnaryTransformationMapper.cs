using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class UnaryTransformationMapper : MapperBase<IUnaryTransformer>
    {
        private readonly IUnaryTransformer _transformer;

        public UnaryTransformationMapper(IUnaryTransformer transformer, Placeholder source, Placeholder target)
            : base(transformer, source, target)
        {
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