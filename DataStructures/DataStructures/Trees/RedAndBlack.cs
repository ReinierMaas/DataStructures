using System;

namespace DataStructures.Trees
{
    public class RedAndBlack
    {
        public RedAndBlack()
        {

        }

        public class Node<T>
        {
            public T Item;

            public Node<T> Parent;
            public Node<T> Left;
            public Node<T> Right;
            public bool Red;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            /// <param name="parent"></param>
            /// <param name="left"></param>
            /// <param name="right"></param>
            /// <param name="red"></param>
            public Node(T item, Node<T> parent = null, Node<T> left = null, Node<T> right = null, bool red = true)
            {
                Item = item;
                Parent = parent;
                Left = left;
                Right = right;
                Red = red;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public Node<T> Grandparent(Node<T> node)
            {
                return node?.Parent?.Parent;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="node"></param>
            /// <param name="grandparent"></param>
            /// <returns></returns>
            public Node<T> Uncle(Node<T> node, Node<T> grandparent = null)
            {
                grandparent = grandparent ?? Grandparent(node);
                if (grandparent == null) return null;
                return grandparent.Left == node.Parent ? grandparent.Right : grandparent.Left;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="node"></param>
            public void Insert(Node<T> node)
            {
                Node<T> parent = node.Parent;
                //Current node is root
                if (parent == null)
                {
                    node.Red = false;
                    return;
                }
                //Parent node is black
                if (!parent.Red)
                {
                    return;
                }
                //Uncle is needed and for uncle grandparent is needed
                //Grandparent is needed in both sub-statements
                Node<T> grandparent = Grandparent(node);
                Node<T> uncle = Uncle(node, grandparent);
                //Updating the grandparent to be red
                //Both sub-trees have their sub-roots turned black
                //Both paths remain at the same number of black nodes
                if (uncle != null && uncle.Red)
                {
                    node.Parent.Red = false;
                    uncle.Red = false;
                    grandparent.Red = true;
                    Insert(grandparent);
                    return;
                }
                //Two red nodes rotate
                if (node == parent.Right && parent == grandparent.Left)
                {
                    Node<T> saveParent = parent;
                    Node<T> saveLeft = node.Left;
                    grandparent.Left = node;
                    node.Left = saveParent;
                    saveParent.Right = saveLeft;

                    parent = node;
                    node = saveParent;
                }
                else if (node == parent.Left && parent == grandparent.Right)
                {
                    Node<T> saveParent = parent;
                    Node<T> saveRight = node.Right;
                    grandparent.Right = node;
                    node.Right = saveParent;
                    saveParent.Left = saveRight;

                    parent = node;
                    node = saveParent;
                }
                //Recolor grandparent
                parent.Red = false;
                grandparent.Red = true;
                if (node == parent.Left)
                {
                    RotateRight(grandparent);
                }
                else
                {
                    RotateLeft(grandparent);
                }
            }

            public void Delete(Node<T> node)
            {

            }

            public void RotateLeft(Node<T> node)
            {
                Node<T> saveParent = node.Parent;
                Node<T> saveLeft = node.Left;
                Grandparent(node).Left = node;
                node.Left = saveParent;
                saveParent.Right = saveLeft;
            }

            public void RotateRight(Node<T> node)
            {
                Node<T> saveParent = node.Parent;
                Node<T> saveRight = node.Right;
                Grandparent(node).Right = node;
                node.Right = saveParent;
                saveParent.Left = saveRight;
            }
        }
    }
}
