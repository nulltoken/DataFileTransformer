namespace DataFileTransformer.FileFormatDefinition
{
    public interface IFileFormatDefinition
    {
        int NumberOfColumns { get; }
        int NumberOfHeaderRowsToSkip { get; }
        int NumberOfFooterRowsToSkip { get; }
        bool ShouldDiscardEmptyRows { get; }
    }
}