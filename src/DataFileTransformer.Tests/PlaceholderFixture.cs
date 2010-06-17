using System;
using MbUnit.Framework;

namespace DataFileTransformer.Tests
{
    public class PlaceholderFixture
    {
        [Test]
        public void IsFilledReturnsFalseWhenPlaceHolderIsNotFilled()
        {
            Placeholder placeholder = CreateSUT();
            Assert.IsFalse(placeholder.IsFilled);
        }

        [Test]
        public void IsFilledReturnsTrueWhenPlaceHolderIsFilled()
        {
            Placeholder placeholder = CreateSUT();
            placeholder.FillWith("dummy");
            Assert.IsTrue(placeholder.IsFilled);
        }

        [Test]
        public void RetrieveContentReturnsWhatThePlaceHolderHasBeenFilledWith()
        {
            Placeholder placeholder = CreateSUT();
            string randomData = Guid.NewGuid().ToString();
            placeholder.FillWith(randomData);
            Assert.AreEqual(randomData, placeholder.RetrieveContent());
        }

        [Test]
        public void RetrieveContentThrowsWhenPlaceHolderIsNotFilled()
        {
            Placeholder placeholder = CreateSUT();
            Assert.Throws<InvalidPlaceholderStateException>(() => placeholder.RetrieveContent());
        }

        [Test]
        public void FillWithThrowsWhenPlaceHolderIsAlreadyFilled()
        {
            Placeholder placeholder = CreateSUT();
            placeholder.FillWith("dummy");

            Assert.Throws<InvalidPlaceholderStateException>(() => placeholder.FillWith("more dummy"));
        }

        private static Placeholder CreateSUT()
        {
            return new Placeholder();
        }
    }
}