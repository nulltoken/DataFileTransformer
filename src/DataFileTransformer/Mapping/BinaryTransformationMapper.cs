using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class BinaryTransformationMapper : MapperBase<IBinaryTransformer>
    {
        private readonly Placeholder _additionalSource;
        private readonly IBinaryTransformer _transformer;

        public BinaryTransformationMapper(IBinaryTransformer transformer, Placeholder source,
                                          Placeholder additionalSource, Placeholder target)
            : base(transformer, source, target)
        {
            if (additionalSource == null)
            {
                throw new ArgumentNullException("additionalSource");
            }

            _transformer = transformer;
            _additionalSource = additionalSource;
        }

        public override void Map()
        {
            string data = ExtractDataFrom(Source);
            string additionalData = ExtractDataFrom(_additionalSource);
            string transformedData = PerformTransformation(data, additionalData);
            StoreInto(Target, transformedData);
        }

        private string PerformTransformation(string data, string additionalData)
        {
            return _transformer.Transform(data, additionalData);
        }
    }
}