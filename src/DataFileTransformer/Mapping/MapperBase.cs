using System;
using System.Globalization;

namespace DataFileTransformer.Mapping
{
    public abstract class MapperBase<TTransformer> : IMapper
    {
        private readonly Placeholder _source;
        private readonly Placeholder _target;
        private readonly TTransformer _transformer;


        protected MapperBase(TTransformer transformer, Placeholder source, Placeholder target)
        {
            if (Equals(transformer, default(TTransformer)))
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

        public void Map()
        {
            string data = ExtractDataFrom(Source);
            string transformedData = PerformTransformation(data);
            StoreInto(Target, transformedData);
        }

        #endregion

        protected abstract string PerformTransformation(string data);


        protected void StoreInto(Placeholder placeholder, string data)
        {
            Perform(() => placeholder.FillWith(data));
        }

        protected string ExtractDataFrom(Placeholder placeholder)
        {
            string content = null;
            Perform(() => content = placeholder.RetrieveContent());

            return content;
        }

        private void Perform(Action codeBlock)
        {
            try
            {
                codeBlock();
            }
            catch (InvalidPlaceholderStateException e)
            {
                throw BuildException(e);
            }
        }

        private Exception BuildException(Exception exception)
        {
            return
                new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Can not apply '{0}' transformation.",
                                  _transformer.GetType().FullName), exception);
        }
    }
}