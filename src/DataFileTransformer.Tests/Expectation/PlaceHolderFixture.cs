using System;
using DataFileTransformer.Mapping;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Expectation
{
    public class PlaceHolderFixture
    {
        [Test]
        public void IsFilledReturnsFalseWhenPlaceHolderIsNotFilled()
        {
            PlaceHolder placeHolder = CreateSUT();
            Assert.IsFalse(placeHolder.IsFilled);
        }

        [Test]
        public void IsFilledReturnsTrueWhenPlaceHolderIsFilled()
        {
            PlaceHolder placeHolder = CreateSUT();
            placeHolder.FillWith("dummy");
            Assert.IsTrue(placeHolder.IsFilled);
        }

        [Test]
        public void RetrieveContentReturnsWhatThePlaceHolderHasBeenFilledWith()
        {
            PlaceHolder placeHolder = CreateSUT();
            string randomData = Guid.NewGuid().ToString();
            placeHolder.FillWith(randomData);
            Assert.AreEqual(randomData, placeHolder.RetrieveContent());
        }

        [Test]
        public void RetrieveContentThrowsWhenPlaceHolderIsNotFilled()
        {
            PlaceHolder placeHolder = CreateSUT();
            Assert.Throws<InvalidOperationException>(() => placeHolder.RetrieveContent());
        }

        [Test]
        public void FillWithThrowsWhenPlaceHolderIsAlreadyFilled()
        {
            PlaceHolder placeHolder = CreateSUT();
            placeHolder.FillWith("dummy");

            Assert.Throws<InvalidOperationException>(() => placeHolder.FillWith("more dummy"));
        }

        private PlaceHolder CreateSUT()
        {
            return new PlaceHolder();
        }
    }
}