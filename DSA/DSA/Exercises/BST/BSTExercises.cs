using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA.DataStructures;

namespace DSA.Exercises.BST
{
    public class BSTExercises
    {
        public static BinarySearchNode<int>? SearchBST(BinarySearchNode<int>? root, int val)
        {
            if (root == null) return null;
            if (root.Item == val) return root;
            if (val < root.Item)
                return SearchBST(root.Left, val);
            else
                return SearchBST(root.Right, val);
        }
    }
}
