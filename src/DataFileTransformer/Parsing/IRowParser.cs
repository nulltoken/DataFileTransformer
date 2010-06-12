namespace DataFileTransformer.Parsing
{
    public interface IRowParser
    {
        ChunkContainer Parse(string row);
    }
}