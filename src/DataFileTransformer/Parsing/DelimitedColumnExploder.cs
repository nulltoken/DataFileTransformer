using System;
using System.Collections.Generic;

namespace DataFileTransformer.Parsing
{
    public class DelimitedColumnExploder : IColumnExploder
    {
        private readonly char _columnDelimiter;

        public DelimitedColumnExploder(char columnDelimiter)
        {
            _columnDelimiter = columnDelimiter;
        }

        #region IColumnExploder Members

        public ICollection<string> Explode(string row)
        {
            if (row == null)
            {
                throw new ArgumentNullException("row");
            }
            string[] t = row.Split(new[] {_columnDelimiter}, StringSplitOptions.None);
            return t;
        }

        #endregion
    }
}