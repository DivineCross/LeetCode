using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DataStructure
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public static TreeNode From(IEnumerable<int?> collection)
        {
            if (collection == null)
                throw new ArgumentException($"'{nameof(collection)}' can not be null.");

            var rootVal = collection.FirstOrDefault();
            if (rootVal == null)
                return null;

            var root = new TreeNode(rootVal.Value);
            var queue = new Queue<TreeNode>();
            root.AddTo(queue);

            var it = collection.GetEnumerator();
            var hasNode = it.MoveNext();
            while (queue.Any() && hasNode)
                AddChildren(queue.Dequeue(), GetNext(it, out _), GetNext(it, out hasNode));

            return root;

            void AddChildren(TreeNode parent, int? l, int? r)
            {
                parent.left = From(l).AddTo(queue);
                parent.right = From(r).AddTo(queue);
            }

            static int? GetNext(IEnumerator<int?> it, out bool hasNext)
            {
                return (hasNext = it.MoveNext()) ? it.Current : null;
            }
        }

        private static TreeNode From(int? val)
        {
            return val == null ? null : new TreeNode(val.Value);
        }
    }

    public static class TreeNodeExtensions
    {
        public static int?[] ToArray(this TreeNode root)
        {
            if (root?.val == null)
                return new int?[0];

            var vals = new List<int?>();
            var queue = new Queue<TreeNode>();
            root.AddTo(queue);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                vals.Add(node?.val);

                node.left.AddTo(queue);
                node.right.AddTo(queue);
           }

            return vals.ToArray();
        }

        public static TreeNode AddTo(this TreeNode node, Queue<TreeNode> queue)
        {
            if (node != null)
                queue.Enqueue(node);

            return node;
        }
    }
}
