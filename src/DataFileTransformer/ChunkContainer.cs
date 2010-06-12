using System.Collections.Generic;

namespace DataFileTransformer
{
    public class ChunkContainer
    {
        private readonly List<string> _chunks;

        public ChunkContainer(IEnumerable<string> data)
        {
            _chunks = new List<string>(data);
        }

        public int Count
        {
            get { return _chunks.Count; }
        }

        public string this[int index]
        {
            get { return _chunks[index]; }
        }

        public string[] ToArray()
        {
            return _chunks.ToArray();
        }

        public ChunkContainer Add(string[] inputs)
        {
            return InternalAdd(inputs);
        }

        public ChunkContainer Add(string input)
        {
            return Add(new[] {input});
        }

        public ChunkContainer Add(ChunkContainer container)
        {
            return InternalAdd(container.ToArray());
        }

        public ChunkContainer GetRange(int index, int count)
        {
            return new ChunkContainer(_chunks.GetRange(index, count));
        }

        private ChunkContainer InternalAdd(IEnumerable<string> addtionalChunks)
        {
            var newChunks = new List<string>(_chunks.ToArray());
            newChunks.AddRange(addtionalChunks);
            return new ChunkContainer(newChunks);
        }
    }
}