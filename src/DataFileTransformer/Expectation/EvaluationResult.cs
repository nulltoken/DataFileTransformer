namespace DataFileTransformer.Expectation
{
    public class EvaluationResult
    {
        private readonly Status _status;

        public EvaluationResult(Status status)
        {
            _status = status;
        }

        public Status Status
        {
            get { return _status; }
        }
    }
}