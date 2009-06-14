using System;

namespace DataFileTransformer.Mapping
{
    public class PlaceHolder
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
                if (!_isFilled)
                {
                    throw new InvalidOperationException("Content has not been initialized yet.");
                }
                return _content;
            }
        }

        public void FillWith(string input)
        {
            lock (_locker)
            {
                if (_isFilled)
                {
                    throw new InvalidOperationException("Content has already been initialized.");
                }
                _content = input;
                _isFilled = true;
            }
        }
    }
}