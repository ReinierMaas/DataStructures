using System;
using System.Collections.Generic;

namespace DataStructures.Array
{
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private T[] _storage;
        private int _size = 4;
        private const int GROW = 2;
        private readonly bool _maxHeap;
        private readonly Comparer<T> _comparer = Comparer<T>.Default;

        public int Count { get; private set; }
        /// <summary>
        /// Swaps to elements in storage
        /// O(1)
        /// </summary>
        /// <param name="index1">
        /// First index in storage
        /// </param>
        /// <param name="index2">
        /// Second index in storage
        /// </param>
        private void Swap(int index1, int index2)
        {
            T temp = _storage[index1];
            _storage[index1] = _storage[index2];
            _storage[index2] = temp;
        }

        /// <summary>
        /// Compares T on index1 with T on index2
        /// </summary>
        /// <param name="index1">
        /// Index1 to T
        /// </param>
        /// <param name="index2">
        /// Index2 to T
        /// </param>
        /// <returns>
        /// Bool indicating that index1 is preferred above index2
        /// </returns>
        private bool Compare(int index1, int index2)
        {
            int compare = _comparer.Compare(_storage[index1], _storage[index2]);
            return _maxHeap ? compare > 0 : compare < 0;
        }

        /// <summary>
        /// Calculates the parent of the node
        /// O(1)
        /// </summary>
        /// <param name="index">
        /// Index in the array of the node
        /// </param>
        /// <returns>
        /// Parent of the node
        /// </returns>
        private static int Parent(int index)
        {
            return (index - 1) / 2;
        }

        /// <summary>
        /// Calculates the left child of the node
        /// O(1)
        /// </summary>
        /// <param name="index">
        /// Index in the array of the node
        /// </param>
        /// <returns>
        /// Left child of the node
        /// </returns>
        private static int Child(int index)
        {
            return (2 * index) + 1;
        }

        /// <summary>
        /// Heapify up the given index
        /// O(log(n))
        /// </summary>
        /// <param name="index">
        /// Index to heapify up
        /// </param>
        private void HeapifyUp(int index)
        {
            while (true)
            {
                if (index > 0)
                {
                    int parent = Parent(index);
                    if (Compare(index, parent))
                    {
                        //Child preferred to parent
                        Swap(index, parent);
                        index = parent;
                        continue;
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Heapify down the given index
        /// O(log(n))
        /// </summary>
        /// <param name="index">
        /// Index to heapify down
        /// </param>
        private void HeapifyDown(int index)
        {
            while (true)
            {
                int childLeft = Child(index);
                if (childLeft < Count)
                {
                    int childRight = childLeft + 1;
                    if (Compare(childLeft, childRight))
                    {
                        //Left child preferred to right child
                        if (Compare(childLeft, index))
                        {
                            //Left child preferred to parent
                            Swap(index, childLeft);
                            index = childLeft;
                            continue;
                        }
                    }
                    else
                    {
                        //Right child preferred to left child
                        if (Compare(childRight, index))
                        {
                            //Right child preferred to parent
                            Swap(index, childRight);
                            index = childRight;
                            continue;
                        }
                    }
                }
                break;
            }
        }

        /// <summary>
        /// Create a new binary heap
        /// Insert Amortized O(log(n))
        /// Pop O(log(n))
        /// Peak O(1)
        /// </summary>
        public BinaryHeap(bool maxHeap)
        {
            _maxHeap = maxHeap;
            _storage = new T[_size];
        }

        /// <summary>
        /// Create a new binary heap
        /// Insert Amortized O(log(n))
        /// Pop O(log(n))
        /// Peak O(1)
        /// </summary>
        public BinaryHeap(IEnumerable<T> items, bool maxHeap = true)
        {
            _maxHeap = maxHeap;
            _storage = new T[_size];
            foreach (T item in items)
            {
                Insert(item);
            }
        }

        /// <summary>
        /// Insert a new item on the heap
        /// Resizes the array if needed
        /// Amortized O(log(n))
        /// </summary>
        /// <param name="item">
        /// Item to add
        /// </param>
        public void Insert(T item)
        {
            if (Count == _size)
            {
                _size *= GROW;
                System.Array.Resize(ref _storage, _size);
            }
            _storage[Count] = item;
            HeapifyUp(Count);
            Count++;
        }

        /// <summary>
        /// Pop the next from the heap
        /// O(log(n))
        /// </summary>
        /// <returns>
        /// The next item and removes it from the heap
        /// </returns>
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Count is zero");
            T temp = _storage[0];
            Count--;
            _storage[0] = _storage[Count];
            HeapifyDown(0);
            return temp;
        }

        /// <summary>
        /// Peek at the next item on the heap
        /// O(1)
        /// </summary>
        /// <returns>
        /// The next item and leaves it on the heap
        /// </returns>
        public T Peak()
        {
            if (Count == 0)
                throw new InvalidOperationException("Count is zero");
            return _storage[0];
        }
    }
}