using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    // Two Sum IV - Input is a BST 
    class TwoSumIV : LeetCodeBase
    {
        public override void Run()
        {
        }

        public bool FindTarget(TreeNode root, int k)
        {
            return Find(root, root, k);
        }

        public bool Find(TreeNode cur, TreeNode root, int k)
        {
            if (cur == null)
            {
                return false;
            }

            if (FindAnother(cur, root, k - cur.val))
            {
                return true;
            }

            if (Find(cur.left, root, k))
            {
                return true;
            }
            else
            {
                return Find(cur.right, root, k);
            }
        }

        public bool FindAnother(TreeNode cur, TreeNode root, int k)
        {
            if (root == null)
            {
                return false;
            }

            if (root.val == k && root != cur)
            {
                return true;
            }

            if (root.val > k)
            {
                root = root.left;
            }
            else
            {
                root = root.right;
            }

            return FindAnother(cur, root, k);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
