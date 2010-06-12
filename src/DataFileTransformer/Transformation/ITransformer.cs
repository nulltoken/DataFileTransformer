namespace DataFileTransformer.Transformation
{
    public interface ITransformer
    {
        ChunkContainer Transform(ChunkContainer source);
    }
}