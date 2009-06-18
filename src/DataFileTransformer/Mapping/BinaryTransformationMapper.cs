using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class BinaryTransformationMapper : MapperBase<IBinaryTransformer>
    {
        private readonly Placeholder _additionalSource;

        public BinaryTransformationMapper(IBinaryTransformer transformer, Placeholder source,
                                          Placeholder additionalSource, Placeholder target)
            : base(transformer, source, target)
        {
            if (additionalSource == null)
            {
                throw new ArgumentNullException("additionalSource");
            }

            _additionalSource = additionalSource;
        }

        protected override string PerformTransformation(string data)
        {
            string additionalData = ExtractDataFrom(_additionalSource);
            return Transformer.Transform(data, additionalData);
        }
    }
}