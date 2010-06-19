using System;
using System.Collections.Generic;

namespace DataFileTransformer.Expectation
{
    public class ExpectationResult
    {
        public const string EXPECTATION_MET = "Expectation has been fulfilled.";

        private readonly bool _hasExpectationBeenFulfilled;
        private readonly IEnumerable<string> _messages;

        public ExpectationResult(IEnumerable<string> messages) : this(false, messages)
        {
        }

        public ExpectationResult(string message)
            : this(false, new[] {message})
        {
        }

        private ExpectationResult(bool hasExpectationBeenFulfilled, IEnumerable<string> messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException("messages");
            }

            EnsureNoNullEntryIn(messages);

            _hasExpectationBeenFulfilled = hasExpectationBeenFulfilled;
            _messages = messages;
        }

        public ExpectationResult() : this(true, new[] {EXPECTATION_MET})
        {
        }

        public bool HasExpectationBeenFulfilled
        {
            get { return _hasExpectationBeenFulfilled; }
        }

        public IEnumerable<string> Messages
        {
            get { return _messages; }
        }

        private static void EnsureNoNullEntryIn(IEnumerable<string> messages)
        {
            foreach (string message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    continue;
                }

                throw new ArgumentException("Null or empty messages are not allowed.", "messages");
            }
        }

        public ExpectationResult CombineWith(ExpectationResult result)
        {
            if (result.HasExpectationBeenFulfilled)
            {
                return this;
            }

            if (!result.HasExpectationBeenFulfilled && HasExpectationBeenFulfilled)
            {
                return result;
            }

            IEnumerable<string> messages = BuildMessageList(result.Messages);
            return new ExpectationResult(messages);
        }

        private IEnumerable<string> BuildMessageList(IEnumerable<string> messages)
        {
            var resultingMessages = new List<string>(_messages);
            resultingMessages.AddRange(messages);
            return resultingMessages;
        }
    }
}