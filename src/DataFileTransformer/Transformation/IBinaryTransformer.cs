namespace DataFileTransformer.Transformation
{
    public interface IBinaryTransformer
    {
        string Transform(string input, string otherInput);
    }
}