using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class Binary<T> : IEnumerable<T>, IDisposable where T : IComparable<T>
    {
        private Node<T> _root;

        public int Count => _root.Count;

        public void Insert(T item)
        {
            Node<T> newNode = new Node<T>(item);
            if (_root == null)
                _root = newNode;
            else
            {
                Node<T> prevNode = _root;
                Node<T> treeNode = _root;
                while (treeNode != null)
                {
                    prevNode = treeNode;
                    treeNode = newNode.Item.CompareTo(treeNode.Item) < 1 ? treeNode.Left : treeNode.Right;
                }
                newNode.Parent = prevNode;
                if (newNode.Item.CompareTo(prevNode.Item) < 1)
                    prevNode.Left = newNode;
                else
                    prevNode.Right = newNode;
            }
        }

        /// <summary>
        /// Recursive delete
        /// </summary>
        /// <param name="item">Item which is gonna be deleted</param>
        public void Delete(T item)
        {
            _root = DeleteNode(_root, item);
        }

        /// <summary>
        /// Recursive delete
        /// </summary>
        /// <param name="treeNode">Current subtree selected for deleting item</param>
        /// <param name="item">Item which is gonna be deleted</param>
        /// <returns>New subtree root</returns>
        private static Node<T> DeleteNode(Node<T> treeNode, T item)
        {
            if (treeNode == null) return null;
            switch (item.CompareTo(treeNode.Item))
            {
                case -1:
                    treeNode.Left = DeleteNode(treeNode.Left, item);
                    break;
                case 1:
                    treeNode.Right = DeleteNode(treeNode.Right, item);
                    break;
                default:
                    //No childs
                    if (treeNode.Left == null && treeNode.Right == null)
                    {
                        treeNode.Dispose();
                        treeNode = null;
                    }
                    //One child
                    else if (treeNode.Left == null)
                    {
                        Node<T> temp = treeNode;
                        treeNode = treeNode.Right;
                        temp.Dispose();
                    }
                    else if (treeNode.Right == null)
                    {
                        Node<T> temp = treeNode;
                        treeNode = treeNode.Left;
                        temp.Dispose();
                    }
                    //Two childs
                    else
                    {
                        Node<T> temp = FindMin(treeNode.Right);
                        treeNode.Item = temp.Item;
                        treeNode.Right = DeleteNode(treeNode.Right, temp.Item);
                    }
                    break;
            }
            return treeNode;
        }

        private static Node<T> FindMin(Node<T> subTree)
        {
            Node<T> prevNode = subTree;
            while (subTree != null)
            {
                prevNode = subTree;
                subTree = subTree.Left;
            }
            return prevNode;
        }

        public T Find(T item)
        {
            Node<T> treeNode = _root;
            while (treeNode != null)
            {
                switch (item.CompareTo(treeNode.Item))
                {
                    case -1:
                        treeNode = treeNode.Left;
                        break;
                    case 0:
                        return treeNode.Item;
                    case 1:
                        treeNode = treeNode.Right;
                        break;
                }
            }
            throw new KeyNotFoundException("Item not in tree");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = _root;
            Array.Stack<Node<T>> parentStack = new Array.Stack<Node<T>>();
            while (parentStack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    parentStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = parentStack.Pop();
                    yield return node.Item;
                    node = node.Right;
                }
            }
        }

        public void Dispose()
        {
            Node<T> node = _root;
            Array.Stack<Node<T>> parentStack = new Array.Stack<Node<T>>();
            while (parentStack.Count != 0 || node != null)
            {
                if (node != null)
                {
                    parentStack.Push(node);
                    node = node.Left;
                }
                else
                {
                    using (Node<T> disposeNode = parentStack.Pop())
                    {
                        node = disposeNode.Right;
                    }
                }
            }
            _root = null;
        }
    }
}
