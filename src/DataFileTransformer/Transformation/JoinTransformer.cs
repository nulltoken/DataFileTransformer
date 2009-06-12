using System;

namespace DataFileTransformer.Transformation
{
    public class JoinTransformer : IBinaryTransformer
    {
        #region Implementation of IBinaryTransformer

        public string Transform(string input, string otherInput)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (otherInput == null)
            {
                throw new ArgumentNullException("otherInput");
            }
            return string.Concat(input, otherInput);
        }

        #endregion
    }
}