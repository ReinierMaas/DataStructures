using System;

namespace DataStructures.Array
{
    public class Stack<T>
    {
        /// <summary>
        /// Storage of the stack, the backing array
        /// </summary>
        private T[] _storage;

        /// <summary>
        /// Size of the stacks array
        /// </summary>
        private int _size = 4;

        /// <summary>
        /// Grow ratio of the backing array
        /// </summary>
        private const int GROW = 2;

        /// <summary>
        /// Number of elements in the stack
        /// </summary>
        public int Count { get; private set; }

        public Stack()
        {
            _storage = new T[_size];
        }

        /// <summary>
        /// Pushes the item on the end of the array
        /// Resizes the array if needed
        /// Amortized O(1)
        /// </summary>
        /// <param name="item">Item to push on the stack</param>
        public void Push(T item)
        {
            if (Count == _size)
            {
                _size *= GROW;
                System.Array.Resize(ref _storage, _size);
            }
            _storage[Count] = item;
            Count++;
        }

        /// <summary>
        /// Pops the item from the end of the array
        /// O(1)
        /// Possible: InvalidOperationException
        /// </summary>
        /// <returns>Item that got pop from the stack</returns>
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            Count--;
            return _storage[Count];
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
            return _storage[Count - 1];
        }

        /// <summary>
        /// Index on the internal array
        /// O(1)
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
                    return _storage[index];
                }
                throw new IndexOutOfRangeException("List count: " + Count + " index: " + index);
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    _storage[index] = value;
                }
                throw new IndexOutOfRangeException("List count: " + Count + " index: " + index);
            }
        }
    }
}