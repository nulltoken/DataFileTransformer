using DataFileTransformer.Transformation;

namespace DataFileTransformer.Mapping
{
    public class UnaryTransformationMapper : MapperBase<IUnaryTransformer>
    {
        public UnaryTransformationMapper(IUnaryTransformer transformer, Placeholder source, Placeholder target)
            : base(transformer, source, target)
        {
        }

        protected override string PerformTransformation(string data)
        {
            return Transformer.Transform(data);
        }
    }
}