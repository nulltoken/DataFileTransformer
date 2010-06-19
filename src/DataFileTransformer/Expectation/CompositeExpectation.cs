using System.Collections.Generic;

namespace DataFileTransformer.Expectation
{
    public class CompositeExpectation : CompositeBase<IExpectation>, IExpectation
    {
        public CompositeExpectation(IExpectation expectation)
            : this(new[] {expectation})
        {
        }

        private CompositeExpectation(IEnumerable<IExpectation> expectations)
            : base(expectations)
        {
        }

        #region IExpectation Members

        public ExpectationResult VerifyFulfillmentOf(string input)
        {
            var combinedresult = new ExpectationResult();

            foreach (IExpectation expectation in Components)
            {
                ExpectationResult result = expectation.VerifyFulfillmentOf(input);
                combinedresult = combinedresult.CombineWith(result);
            }

            return combinedresult;
        }

        #endregion

        protected override CompositeBase<IExpectation> BuildComposite(IEnumerable<IExpectation> components)
        {
            return new CompositeExpectation(components);
        }

        public override IExpectation Build()
        {
            return this;
        }
    }
}