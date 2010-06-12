using System;
using System.Collections.Generic;
using System.Linq;
using DataFileTransformer.Parsing;
using MbUnit.Framework;

namespace DataFileTransformer.Tests.Parsing
{
    [TestFixture]
    public class RowParserFixture
    {
        private const char TAB = (char) 9;

        [Test]
        [Row("a\tb", AdditionalColumnsProcessing.Skip, 5)]
        [Row("a\tb", AdditionalColumnsProcessing.Merge, 5)]
        [Row("", AdditionalColumnsProcessing.Skip, 5)]
        [Row("", AdditionalColumnsProcessing.Merge, 5)]
        [Row("", AdditionalColumnsProcessing.Skip, 2)]
        [Row("", AdditionalColumnsProcessing.Merge, 2)]
        [Row("a\tb\tc\td", AdditionalColumnsProcessing.Skip, 2)]
        [Row("a\tb\tc\td", AdditionalColumnsProcessing.Merge, 2)]
        public void ParseReturnsTheExpectedNumberOfColumns(string input,
                                                           AdditionalColumnsProcessing additionalColumnsProcessing,
                                                           int expectedNumberOfColumns)
        {
            IRowParser rowParser = CreateSUT(expectedNumberOfColumns, additionalColumnsProcessing,
                                             new DelimitedColumnExploder(TAB));

            IEnumerable<string> columns = rowParser.Parse(input);

            Assert.AreEqual(expectedNumberOfColumns, columns.Count());
        }

        [Test]
        [Row("a\tb", AdditionalColumnsProcessing.Skip, 5, "")]
        [Row("a\tb", AdditionalColumnsProcessing.Merge, 5, "")]
        [Row("a\tb", AdditionalColumnsProcessing.Skip, 2, "b")]
        [Row("a\tb", AdditionalColumnsProcessing.Merge, 2, "b")]
        [Row("a\tb\tc", AdditionalColumnsProcessing.Skip, 2, "b")]
        [Row("a\tb\tc", AdditionalColumnsProcessing.Merge, 2, "bc")]
        public void ParseCorrectlyHandleProcessingOfAdditionalColumns(string input,
                                                                      AdditionalColumnsProcessing
                                                                          additionalColumnsProcessing,
                                                                      int expectedNumberOfColumns,
                                                                      string expectedLastColumn)
        {
            IRowParser rowParser = CreateSUT(expectedNumberOfColumns, additionalColumnsProcessing,
                                             new DelimitedColumnExploder(TAB));
            string[] columns = rowParser.Parse(input).ToArray();
            Assert.AreEqual(expectedLastColumn, columns[expectedNumberOfColumns - 1]);
        }

        [Test]
        public void ParseThrowsWhenNullParametersIsPassed()
        {
            IRowParser rowParser = CreateSUT(5, AdditionalColumnsProcessing.Skip, new DelimitedColumnExploder((char)9));

            Assert.Throws<ArgumentNullException>(() => rowParser.Parse(null));
        }

        [Test]
        public void ConstructorThrowsWhenNullIColumnExploderIsPassed()
        {
            Assert.Throws<ArgumentNullException>(() => CreateSUT(5, AdditionalColumnsProcessing.Skip, null));
        }

        private static IRowParser CreateSUT(int numberOfColumns, AdditionalColumnsProcessing additionalColumnsProcessing,
                                            IColumnExploder columnExploder)
        {
            return new RowParser(numberOfColumns, additionalColumnsProcessing, columnExploder);
        }
    }
}