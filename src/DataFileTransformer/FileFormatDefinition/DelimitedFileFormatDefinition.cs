namespace DataFileTransformer.FileFormatDefinition
{
    public class DelimitedFileFormatDefinition : FileFormatDefinitionBase, IDelimitedFileFormatDefinition
    {
        private readonly char _delimiter;


        public DelimitedFileFormatDefinition(char delimiter, int numberOfColumns, int numberOfHeaderRowsToSkip,
                                             int numberOfFooterRowsToSkip, bool shouldDiscardEmptyRows)
            : base(numberOfColumns, numberOfHeaderRowsToSkip, numberOfFooterRowsToSkip, shouldDiscardEmptyRows)
        {
            _delimiter = delimiter;
        }

        #region Implementation of IDelimitedFileFormatDefinition

        public char Delimiter
        {
            get { return _delimiter; }
        }

        #endregion
    }
}