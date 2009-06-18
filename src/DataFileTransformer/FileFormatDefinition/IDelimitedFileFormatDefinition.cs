namespace DataFileTransformer.FileFormatDefinition
{
    public interface IDelimitedFileFormatDefinition : IFileFormatDefinition
    {
        char Delimiter { get; }
    }
}