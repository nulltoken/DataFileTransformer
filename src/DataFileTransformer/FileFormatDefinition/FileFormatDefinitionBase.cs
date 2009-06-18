namespace DataFileTransformer.FileFormatDefinition
{
    public abstract class FileFormatDefinitionBase : IFileFormatDefinition
    {
        private readonly int _numberOfColumns;

        private readonly int _numberOfFooterRowsToSkip;
        private readonly int _numberOfHeaderRowsToSkip;

        private readonly bool _shouldDiscardEmptyRows;

        protected FileFormatDefinitionBase(int numberOfColumns, int numberOfHeaderRowsToSkip,
                                           int numberOfFooterRowsToSkip, bool shouldDiscardEmptyRows)
        {
            _numberOfColumns = numberOfColumns;
            _shouldDiscardEmptyRows = shouldDiscardEmptyRows;
            _numberOfFooterRowsToSkip = numberOfFooterRowsToSkip;
            _numberOfHeaderRowsToSkip = numberOfHeaderRowsToSkip;
        }

        #region Implementation of IFileFormatDefinition

        public int NumberOfColumns
        {
            get { return _numberOfColumns; }
        }

        public int NumberOfHeaderRowsToSkip
        {
            get { return _numberOfHeaderRowsToSkip; }
        }

        public int NumberOfFooterRowsToSkip
        {
            get { return _numberOfFooterRowsToSkip; }
        }

        public bool ShouldDiscardEmptyRows
        {
            get { return _shouldDiscardEmptyRows; }
        }

        #endregion
    }
}