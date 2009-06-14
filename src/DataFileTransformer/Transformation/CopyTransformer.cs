using System;

namespace DataFileTransformer.Transformation
{
    public class CopyTransformer : IUnaryTransformer
    {
        #region Implementation of IUnaryTransformer

        public string Transform(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return input;
        }

        #endregion
    }
}