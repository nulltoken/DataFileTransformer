using System.Collections.Generic;

namespace DataFileTransformer.Parsing
{
    public interface IColumnExploder
    {
        ICollection<string> Explode(string row);
    }
}