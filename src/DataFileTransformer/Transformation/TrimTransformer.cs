using System;

namespace DataFileTransformer.Transformation
{
    public class TrimTransformer : IUnaryTransformer
    {
        #region Implementation of IUnaryTransformer

        public string Transform(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            return input.Trim();
        }

        #endregion
    }
}