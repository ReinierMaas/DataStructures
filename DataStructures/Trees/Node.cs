using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class Node<T> : IDisposable
    {
        public T Item;

        public Node<T> Parent;
        public Node<T> Left;
        public Node<T> Right;

        public Node(T item)
        {
            Item = item;
        }

        public Node<T> Grandparent => Parent?.Parent;

        public Node<T> Uncle
        {
            get
            {
                Node<T> grandparent = Grandparent;
                if (grandparent == null) return null;
                return grandparent.Left == Parent ? grandparent.Right : grandparent.Left;
            }
        }

        public int Count => 1 + (Left?.Count ?? 0) + (Right?.Count ?? 0);

        public void Dispose()
        {
            Parent = null;
            Left = null;
            Right = null;
            Item = default(T);
        }
    }
    public class RedAndBlackNode<T> : Node<T>
    {
        public new RedAndBlackNode<T> Parent;
        public new RedAndBlackNode<T> Left;
        public new RedAndBlackNode<T> Right;
        public bool Red = true;

        public RedAndBlackNode(T item) : base(item) { }

        public new RedAndBlackNode<T> Grandparent => Parent?.Parent;

        public new RedAndBlackNode<T> Uncle
        {
            get
            {
                RedAndBlackNode<T> grandparent = Grandparent;
                if (grandparent == null) return null;
                return grandparent.Left == Parent ? grandparent.Right : grandparent.Left;
            }
        }
    }
}