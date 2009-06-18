using DataFileTransformer.FileFormatDefinition;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.FileFormatDefinition
{
    [TestFixture]
    public class DelimitedFileFormatDefinitionFixture
    {
        [Test]
        public void PropertiesSendBackWhatTheConstrcutorIsBeingInitializedWith()
        {
            const char delimiter = (char) 9;
            const int numberOfColumns = 3;
            const int numberOfHeaderRowsToSkip = 1;
            const int numberOfFooterRowsToSkip = 2;
            const bool shouldDiscardEmptyRows = true;

            IDelimitedFileFormatDefinition delimitedFileFormatDefinition = CreateSut(delimiter, numberOfColumns,
                                                                                     numberOfHeaderRowsToSkip,
                                                                                     numberOfFooterRowsToSkip,
                                                                                     shouldDiscardEmptyRows);

            Assert.AreEqual(delimiter, delimitedFileFormatDefinition.Delimiter);
            Assert.AreEqual(numberOfColumns, delimitedFileFormatDefinition.NumberOfColumns);
            Assert.AreEqual(numberOfHeaderRowsToSkip, delimitedFileFormatDefinition.NumberOfHeaderRowsToSkip);
            Assert.AreEqual(numberOfFooterRowsToSkip, delimitedFileFormatDefinition.NumberOfFooterRowsToSkip);
            Assert.AreEqual(shouldDiscardEmptyRows, delimitedFileFormatDefinition.ShouldDiscardEmptyRows);
        }

        private static IDelimitedFileFormatDefinition CreateSut(char delimiter, int numberOfColumns,
                                                                int numberOfHeaderRowsToSkip,
                                                                int numberOfFooterRowsToSkip,
                                                                bool shouldDiscardEmptyRows)
        {
            return new DelimitedFileFormatDefinition(delimiter, numberOfColumns, numberOfHeaderRowsToSkip,
                                                     numberOfFooterRowsToSkip, shouldDiscardEmptyRows);
        }
    }
}