using System;
using System.Collections.Generic;

namespace DataFileTransformer.Parsing
{
    public class RowParser : IRowParser
    {
        private readonly AdditionalColumnsProcessing _additionalColumnsProcessing;
        private readonly IColumnExploder _columnExploder;
        private readonly List<string> _emptyColumns;
        private readonly int _numberOfColumns;


        public RowParser(int numberOfColumns, AdditionalColumnsProcessing additionalColumnsProcessing,
                         IColumnExploder columnExploder)
        {
            if (columnExploder == null)
            {
                throw new ArgumentNullException("columnExploder");
            }

            _numberOfColumns = numberOfColumns;
            _additionalColumnsProcessing = additionalColumnsProcessing;
            _columnExploder = columnExploder;
            _emptyColumns = BuildEmptryColumnsList(_numberOfColumns);
        }

        #region IRowParser Members

        public IEnumerable<string> Parse(string row)
        {
            if (row == null)
            {
                throw new ArgumentNullException("row");
            }

            ICollection<string> columns = _columnExploder.Explode(row);
            int count = columns.Count;

            if (count == _numberOfColumns)
            {
                return columns;
            }

            if (count > _numberOfColumns)
            {
                return HandleMoreColumnsThanExpected(columns);
            }

            return HandleLessColumnsThanExpected(columns);
        }

        #endregion

        private IEnumerable<string> HandleLessColumnsThanExpected(ICollection<string> columns)
        {
            var u = new List<string>(columns);
            u.AddRange(_emptyColumns.GetRange(0, _numberOfColumns - columns.Count));
            return u;
        }

        private static List<string> BuildEmptryColumnsList(int numberOfColumns)
        {
            var list = new List<string>(numberOfColumns);
            for (int i = 0; i < numberOfColumns; i++)
            {
                list.Add(string.Empty);
            }

            return list;
        }

        private IEnumerable<string> HandleMoreColumnsThanExpected(ICollection<string> columns)
        {
            if (_additionalColumnsProcessing == AdditionalColumnsProcessing.Merge)
            {
                return MergeAdditionalTrailingColumns(columns);
            }

            return SkipAdditionalTrailingColumns(columns);
        }

        private IEnumerable<string> MergeAdditionalTrailingColumns(ICollection<string> collection)
        {
            List<string> t = new List<string>(collection).GetRange(0, _numberOfColumns - 1);
            List<string> u = new List<string>(collection).GetRange(_numberOfColumns - 1,
                                                                   collection.Count -
                                                                   _numberOfColumns + 1);
            string v = string.Join(string.Empty, u.ToArray());
            t.Add(v);
            return t;
        }

        private IEnumerable<string> SkipAdditionalTrailingColumns(IEnumerable<string> collection)
        {
            return new List<string>(collection).GetRange(0, _numberOfColumns);
        }
    }
}