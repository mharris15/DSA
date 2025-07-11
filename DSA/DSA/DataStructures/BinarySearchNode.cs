using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA.DataStructures
{
    /// <summary>
    /// Represents a node in a binary tree.
    /// The basic operations supported by binary trees are searching, traversal, insertion, and deletion.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the node.</typeparam>
    public class BinarySearchNode<T> where T : IComparable<T>
    {
        /// <summary>
        /// Gets or sets the data item stored in the node.
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        public BinarySearchNode<T>? Parent { get; set; }

        /// <summary>
        /// Gets or sets the left child node.
        /// </summary>
        public BinarySearchNode<T>? Left { get; set; }

        /// <summary>
        /// Gets or sets the right child node.
        /// </summary>
        public BinarySearchNode<T>? Right { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchNode{T}"/> class with the specified item.
        /// </summary>
        /// <param name="item">The data item to store in the node.</param>
        public BinarySearchNode(T item)
        {
            Item = item;
            Parent = null;
            Left = null;
            Right = null;
        }

        /// <summary>
        /// Recursively searches the binary search tree for a node containing the specified item.
        /// </summary>
        /// <param name="node">The root node to start the search from.</param>
        /// <param name="x">The item to search for.</param>
        /// <returns>
        /// The <see cref="BinaryTreeNode{T}"/> containing the item if found; otherwise, <c>null</c>.
        /// </returns>
        public static BinarySearchNode<T>? Search(BinarySearchNode<T>? node, T x)
        {
            if (node == null)
                return null;

            int comparison = x.CompareTo(node.Item);

            if (comparison == 0)
                return node;

            if (comparison < 0)
                return Search(node.Left, x);
            else
                return Search(node.Right, x);
        }

        /// <summary>
        /// Finds the node with the minimum value in a binary search tree.
        /// </summary>
        /// <param name="node">The root of the subtree to search.</param>
        /// <returns>
        /// The <see cref="BinaryTreeNode{T}"/> with the smallest value, or <c>null</c> if the tree is empty.
        /// </returns>
        public static BinarySearchNode<T>? FindMinimum(BinarySearchNode<T>? node)
        {
            if (node == null)
                return null;

            var min = node;
            while (min.Left != null)
            {
                min = min.Left;
            }

            return min;
        }

        /// <summary>
        /// Finds the node with the maximum value in a binary search tree.
        /// </summary>
        /// <param name="node">The root of the subtree to search.</param>
        /// <returns>
        /// The <see cref="BinaryTreeNode{T}"/> with the largest value, or <c>null</c> if the tree is empty.
        /// </returns>
        public static BinarySearchNode<T>? FindMaximum(BinarySearchNode<T>? node)
        {
            if (node == null)
                return null;

            var max = node;
            while (max.Right != null)
            {
                max = max.Right;
            }

            return max;
        }

        /// <summary>
        /// Performs an in-order traversal of the binary tree and processes each item using the provided action.
        /// </summary>
        /// <param name="node">The root node to begin traversal from.</param>
        /// <param name="process">The action to perform on each item's value.</param>
        public static void TraverseInOrder(BinarySearchNode<T>? node, Action<T> process)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, process);
                process(node.Item);
                TraverseInOrder(node.Right, process);
            }
        }

        /// <summary>
        /// Inserts a new item into the binary search tree, preserving BST order and linking the parent.
        /// </summary>
        /// <param name="node">The current root or subtree node.</param>
        /// <param name="item">The item to insert.</param>
        public static void Insert(BinarySearchNode<T> node, T item)
        {
            if (item.CompareTo(node.Item) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinarySearchNode<T>(item)
                    {
                        Parent = node
                    };
                }
                else
                {
                    Insert(node.Left, item);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinarySearchNode<T>(item)
                    {
                        Parent = node
                    };
                }
                else
                {
                    Insert(node.Right, item);
                }
            }
        }

        /// <summary>
        /// Deletes a node with the given item from the binary search tree.
        /// </summary>
        /// <param name="root">The root of the tree.</param>
        /// <param name="item">The value to delete.</param>
        /// <returns>The new root of the tree (in case root node is deleted).</returns>
        public static BinarySearchNode<T>? Delete(BinarySearchNode<T>? root, T item)
        {
            if (root == null) return null;

            int cmp = item.CompareTo(root.Item);

            if (cmp < 0)
            {
                root.Left = Delete(root.Left, item);
                if (root.Left != null) root.Left.Parent = root;
            }
            else if (cmp > 0)
            {
                root.Right = Delete(root.Right, item);
                if (root.Right != null) root.Right.Parent = root;
            }
            else
            {
                // Case 1: No children
                if (root.Left == null && root.Right == null)
                    return null;

                // Case 2: One child
                if (root.Left == null)
                {
                    root.Right!.Parent = root.Parent;
                    return root.Right;
                }

                if (root.Right == null)
                {
                    root.Left.Parent = root.Parent;
                    return root.Left;
                }

                // Case 3: Two children
                var successor = FindMinimum(root.Right);
                root.Item = successor!.Item;
                root.Right = Delete(root.Right, successor.Item);
                if (root.Right != null) root.Right.Parent = root;
            }

            return root;
        }

    }
}
