using System;
using System.Diagnostics;
using DataStructures.Array;

namespace DataStructures
{
    class Program
    {
        static List<int> list = new List<int>();
        static Queue<int> queue = new Queue<int>();
        static Stack<int> stack = new Stack<int>();
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();
            int max = 1000000;
            for (int i = 0; i < max; i++)
            {
                list.Add(i);
                queue.Enqueue(i);
                stack.Push(i);
            }
            Console.WriteLine("list count: {0}, queue count: {1}, stack count: {2}", list.Count, queue.Count, stack.Count);
            Console.WriteLine("Elapsed milliseconds: {0}", timer.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
