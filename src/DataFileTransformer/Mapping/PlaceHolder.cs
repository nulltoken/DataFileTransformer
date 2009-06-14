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
                    throw new InvalidOperationException(
                        string.Format("Nothing can be retrieved from this {0} instance. It is currently empty.",
                                      GetType().Name));
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
                    throw new InvalidOperationException(
                        string.Format("This {0} instance can not be filled with '{1}'. It already contains '{2}'.",
                                      GetType().Name, input, _content));
                }

                _content = input;
                _isFilled = true;
            }
        }
    }
}