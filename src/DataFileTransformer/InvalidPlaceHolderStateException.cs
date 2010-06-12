using System;
using System.Runtime.Serialization;

namespace DataFileTransformer.Mapping
{
    [Serializable]
    public class InvalidPlaceholderStateException : Exception
    {
        public InvalidPlaceholderStateException(string message) : base(message)
        {
        }

        public InvalidPlaceholderStateException(string message, Exception innerException) :
            base(message, innerException)
        {
        }

        protected InvalidPlaceholderStateException(SerializationInfo info,
                                                   StreamingContext context) : base(info, context)
        {
        }

        public InvalidPlaceholderStateException()
        {
        }
    }
}