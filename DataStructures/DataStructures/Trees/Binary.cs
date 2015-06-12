using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class Binary<T> : IEnumerable<T> where T: IComparable<T>
    {
        private Node _root;

        public int Count => _root.Count;

        public void Insert(T item)
        {
            Node newNode = new Node(item);
            if (_root == null)
                _root = newNode;
            else
            {
                Node prevNode = _root;
                Node treeNode = _root;
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

        public bool Delete(T item)
        {
            Node treeNode = _root;
            while (treeNode != null)
            {
                int comparer = item.CompareTo(treeNode.Item);
                if (comparer < 0)
                {
                    treeNode = treeNode.Left;
                }
                else if (comparer > 0)
                {
                    treeNode = treeNode.Right;
                }
                else if (comparer == 0)
                {
                    //TODO: Delete
                    //Node changeNode = treeNode;
                    //changeNode = changeNode.Left;
                    //while (changeNode.Right != null)
                    //{
                    //    changeNode = changeNode.Right;
                    //}
                    //if (changeNode.Left != null)
                    //{
                        
                    //}
                    //else
                    //{
                    //    if (treeNode.Parent.Left == treeNode)
                    //    {
                    //        treeNode.Parent.Left
                    //    }
                    //    else
                    //    {
                            
                    //    }
                    //}
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node node = _root;
            Array.Stack<Node> parentStack = new Array.Stack<Node>();
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

        private class Node
        {
            public T Item;

            public Node Parent;
            public Node Left;
            public Node Right;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            /// <param name="parent"></param>
            /// <param name="left"></param>
            /// <param name="right"></param>
            public Node(T item, Node parent = null, Node left = null, Node right = null)
            {
                Item = item;
                Parent = parent;
                Left = left;
                Right = right;
            }

            public int Count
            {
                get
                {
                    int count = 1;
                    count += Left?.Count ?? 0;
                    count += Right?.Count ?? 0;
                    return count;
                }
            }
        }
    }
}
