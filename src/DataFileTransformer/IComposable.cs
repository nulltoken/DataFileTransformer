namespace DataFileTransformer
{
    public interface IComposable<T>
    {
        IComposable<T> ComposeWith(T component);
        T Build();
    }
}