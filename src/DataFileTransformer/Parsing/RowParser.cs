using System;
using DataFileTransformer.Transformation;

namespace DataFileTransformer.Parsing
{
    public class RowParser : IRowParser
    {
        private readonly AdditionalColumnsProcessing _additionalColumnsProcessing;
        private readonly ITransformer _columnExploder;
        private readonly int _numberOfColumns;


        public RowParser(int numberOfColumns, AdditionalColumnsProcessing additionalColumnsProcessing,
                         ITransformer columnExploder)
        {
            if (columnExploder == null)
            {
                throw new ArgumentNullException("columnExploder");
            }

            _numberOfColumns = numberOfColumns;
            _additionalColumnsProcessing = additionalColumnsProcessing;
            _columnExploder = columnExploder;
        }

        #region IRowParser Members

        public ChunkContainer Parse(string row)
        {
            if (row == null)
            {
                throw new ArgumentNullException("row");
            }

            ChunkContainer columns = _columnExploder.Transform(new ChunkContainer(new[] {row}));

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

        private ChunkContainer HandleLessColumnsThanExpected(ChunkContainer columns)
        {
            var emptyColumns = (string[]) Array.CreateInstance(typeof (string), _numberOfColumns - columns.Count);
            for (int i = 0; i < emptyColumns.Length; i++)
            {
                emptyColumns[i] = string.Empty;
            }

            return columns.Add(emptyColumns);
        }

        private ChunkContainer HandleMoreColumnsThanExpected(ChunkContainer columns)
        {
            if (_additionalColumnsProcessing == AdditionalColumnsProcessing.Merge)
            {
                return MergeAdditionalTrailingColumns(columns);
            }

            return SkipAdditionalTrailingColumns(columns);
        }

        private ChunkContainer MergeAdditionalTrailingColumns(ChunkContainer collection)
        {
            ChunkContainer toKeepSplitted = collection.GetRange(0, _numberOfColumns - 1);
            ChunkContainer toMerge = collection.GetRange(_numberOfColumns - 1, collection.Count - _numberOfColumns + 1);

            string mergedColumns = string.Join(string.Empty, toMerge.ToArray());

            ChunkContainer result = toKeepSplitted.Add(mergedColumns);
            return result;
        }

        private ChunkContainer SkipAdditionalTrailingColumns(ChunkContainer collection)
        {
            return collection.GetRange(0, _numberOfColumns);
        }
    }
}