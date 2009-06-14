using System.Globalization;

namespace DataFileTransformer.Mapping
{
    public class Placeholder
    {
        private readonly object _locker = new object();
        private string _content;
        private bool _isFilled;

        public bool IsFilled
        {
            get { return _isFilled; }
        }

        public string RetrieveContent()
        {
            lock (_locker)

            {
                EnsureIsFilled();
                return _content;
            }
        }

        private void EnsureIsFilled()
        {
            if (_isFilled)
            {
                return;
            }

            throw new InvalidPlaceholderStateException(string.Format(CultureInfo.InvariantCulture,
                                                                     "Nothing can be retrieved from this {0} instance. It is currently empty.",
                                                                     GetType().Name));
        }

        public void FillWith(string input)
        {
            lock (_locker)
            {
                EnsureIsNotFilled(input);

                _content = input;
                _isFilled = true;
            }
        }

        private void EnsureIsNotFilled(string input)
        {
            if (!_isFilled)
            {
                return;
            }

            throw new InvalidPlaceholderStateException(string.Format(CultureInfo.InvariantCulture,
                                                                     "This {0} instance can not be filled with '{1}'. It already contains '{2}'.",
                                                                     GetType().Name, input, _content));
        }
    }
}