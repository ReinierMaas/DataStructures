using System;

namespace DataStructures.Array
{
    /// <summary>
    /// TODO: Not completed implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Dequeu<T>
    {
        /// <summary>
        /// Storage of the deque, the backing array
        /// </summary>
        private T[] _storage;

        /// <summary>
        /// Number of elements in the deque
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Front of the stored items???
        /// </summary>
        public int Tail { get; private set; }

        /// <summary>
        /// Size of the deque's backing array
        /// </summary>
        private int _size = 4;

        /// <summary>
        /// Grow ratio of the backing array
        /// </summary>
        private const int GROW = 2;

        /// <summary>
        /// Initialise a new deque
        /// </summary>
        public Dequeu()
        {
            _storage = new T[_size];
        }

        /// <summary>
        /// Pushes the item on the end of the queue
        /// Resizes the internal array if needed
        /// Amortized O(1)
        /// </summary>
        /// <param name="item">Item to enqueue on the queue</param>
        public void Enqueue(T item)
        {
            if (Count == _size)
            {
                _size *= GROW;
                T[] prevArray = _storage;
                _storage = new T[_size];
                System.Array.Copy(prevArray, Tail, _storage, 0, Count - Tail);
                System.Array.Copy(prevArray, 0, _storage, Count - Tail, Tail);
                Tail = 0;
            }
            int begin = (Tail + Count) % _size;
            _storage[begin] = item;
            Count++;
        }

        /// <summary>
        /// Dequeue the item from the end of the queue
        /// O(1)
        /// Possible: InvalidOperationException
        /// </summary>
        /// <returns>Item that got dequeued from the queue</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T tmp = _storage[Tail];
            Count--;
            Tail = (Tail + 1) % _size;
            return tmp;
        }

        /// <summary>
        /// Peek at the item at the end of the array
        /// O(1)
        /// Possible: InvalidOperationException
        /// </summary>
        /// <returns>Item that is next to pop from the stack</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return _storage[Tail];
        }

        /// <summary>
        /// Index on the internal array
        /// Possible: IndexOutOfRangeException
        /// </summary>
        /// <param name="index">Index in the array to change</param>
        /// <returns>Item in the array at the index</returns>
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    index = (Tail + index) % _size;
                    return _storage[index];
                }
                throw new IndexOutOfRangeException("Queue count: " + Count + " index: " + index);
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    index = (Tail + index) % _size;
                    _storage[index] = value;
                }
                throw new IndexOutOfRangeException("Queue count: " + Count + " index: " + index);
            }
        }
    }
}