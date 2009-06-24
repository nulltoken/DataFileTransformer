using System.Collections.Generic;

namespace DataFileTransformer.Parsing
{
    public interface IRowParser
    {
        IEnumerable<string> Parse(string row);
    }
}