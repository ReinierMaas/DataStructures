using System;

namespace DataStructures.Array
{
    public class List<T>
    {
        private T[] _storage;
        public int Count { get; private set; }
        private int _size = 4;
        private static int _grow = 2;

        public List()
        {
            _storage = new T[_size];
        }

        /// <summary>
        /// Add's the item on the end of the array
        /// Resizes the array if needed
        /// Amortized O(1)
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            if (Count == _size)
            {
                _size *= _grow;
                System.Array.Resize(ref _storage, _size);
            }
            _storage[Count] = item;
            Count++;
        }

        /// <summary>
        /// Find's the item in the array
        /// O(n)
        /// </summary>
        /// <param name="item">Item to find</param>
        /// <returns>Returns item when found, else null</returns>
        public bool Find(T item)
        {
            bool found = false;
            int i = 0;
            while (i < Count)
            {
                if (_storage[i].Equals(item))
                {
                    found = true;
                    break;
                }
                i++;
            }
            while (i + 1 < Count)
            {
                _storage[i] = _storage[i + 1];
                i++;
            }
            Count--;
            return found;
        }

        /// <summary>
        /// Removes the item from the array
        /// O(n)
        /// </summary>
        /// <param name="item">Item to remove</param>
        /// <returns>Boolean true if removed, else false</returns>
        public bool Remove(T item)
        {
            bool found = false;
            int i = 0;
            while (i < Count)
            {
                if (_storage[i].Equals(item))
                {
                    found = true;
                    break;
                }
                i++;
            }
            while (i + 1 < Count)
            {
                _storage[i] = _storage[i + 1];
                i++;
            }
            Count--;
            return found;
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