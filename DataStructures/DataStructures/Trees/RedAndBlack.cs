using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class RedAndBlack<T> : Binary<T> where T : IComparable<T>
    {
        private RedAndBlackNode<T> _root;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public new void Insert(T item)
        {
            RedAndBlackNode<T> newNode = new RedAndBlackNode<T>(item);
            if (_root == null)
                _root = newNode;
            else
            {
                RedAndBlackNode<T> prevNode = _root;
                RedAndBlackNode<T> treeNode = _root;
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
            //Node is inserted
            //TODO: fixup
            //RedAndBlackNode<T> parent = newNode.Parent;
            ////Current node is root
            //if (parent == null)
            //{
            //    node.Red = false;
            //    return;
            //}
            ////Parent node is black
            //if (!parent.Red)
            //{
            //    return;
            //}
            ////Uncle is needed and for uncle grandparent is needed
            ////Grandparent is needed in both sub-statements
            //RedAndBlackNode<T> grandparent = node.Grandparent;
            //RedAndBlackNode<T> uncle = node.Uncle;
            ////Updating the grandparent to be red
            ////Both sub-trees have their sub-roots turned black
            ////Both paths remain at the same number of black nodes
            //if (uncle != null && uncle.Red)
            //{
            //    node.Parent.Red = false;
            //    uncle.Red = false;
            //    grandparent.Red = true;
            //    Insert(grandparent);
            //    return;
            //}
            ////Two red nodes rotate
            //if (node == parent.Right && parent == grandparent.Left)
            //{
            //    RedAndBlackNode<T> saveParent = parent;
            //    RedAndBlackNode<T> saveLeft = node.Left;
            //    grandparent.Left = node;
            //    node.Left = saveParent;
            //    saveParent.Right = saveLeft;
            //
            //    parent = node;
            //    node = saveParent;
            //}
            //else if (node == parent.Left && parent == grandparent.Right)
            //{
            //    RedAndBlackNode<T> saveParent = parent;
            //    RedAndBlackNode<T> saveRight = node.Right;
            //    grandparent.Right = node;
            //    node.Right = saveParent;
            //    saveParent.Left = saveRight;
            //
            //    parent = node;
            //    node = saveParent;
            //}
            ////Recolor grandparent
            //parent.Red = false;
            //grandparent.Red = true;
            //if (node == parent.Left)
            //{
            //    RotateRight(grandparent);
            //}
            //else
            //{
            //    RotateLeft(grandparent);
            //}
        }

        private void Delete(RedAndBlackNode<T> node)
        {

        }

        private void RotateLeft(RedAndBlackNode<T> node)
        {
            RedAndBlackNode<T> saveParent = node.Parent;
            RedAndBlackNode<T> saveLeft = node.Left;
            node.Grandparent.Left = node;
            node.Left = saveParent;
            saveParent.Right = saveLeft;
        }

        private void RotateRight(RedAndBlackNode<T> node)
        {
            RedAndBlackNode<T> saveParent = node.Parent;
            RedAndBlackNode<T> saveRight = node.Right;
            node.Grandparent.Right = node;
            node.Right = saveParent;
            saveParent.Left = saveRight;
        }
    }
}