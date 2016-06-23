using System;
using System.Diagnostics;
using DataStructures.Array;
using DataStructures.Trees;

namespace DataStructures
{
    class Program
    {
        static List<int> _list = new List<int>();
        static Queue<int> _queue = new Queue<int>();
        static Stack<int> _stack = new Stack<int>();
        static Binary<int> _binary = new Binary<int>(); 
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                _list.Add(i);
                _queue.Enqueue(i);
                _stack.Push(i);
            }
            for (int i = 0; i < 100; i++)
            {
                _binary.Insert(i);
            }
            Console.WriteLine("list count: {0}, queue count: {1}, stack count: {2}, binary Count: {3}", _list.Count, _queue.Count, _stack.Count, _binary.Count);
            Console.WriteLine("Elapsed milliseconds: {0}", timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
