using System.Collections.Generic;
using System.Linq;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution107
    {
        // https://leetcode.com/problems/binary-tree-level-order-traversal-ii
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var levels = new Stack<IList<int>>();
            if (root?.val == null)
                return levels.ToList();

            var vals = new List<int>();
            var queue = new Queue<TreeNode>();
            var nextQueue = new Queue<TreeNode>();
            Enqueue(queue, root);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                vals.Add(node.val);
                Enqueue(nextQueue, node.left);
                Enqueue(nextQueue, node.right);

                if (!queue.Any())
                {
                    levels.Push(vals);
                    vals = new List<int>();
                    Swap(ref queue, ref nextQueue);
                }
            }

            return levels.ToList();

            void Enqueue(Queue<TreeNode> q, TreeNode n)
            {
                if (n != null)
                    q.Enqueue(n);
            }

            void Swap(ref Queue<TreeNode> x, ref Queue<TreeNode> y)
            {
                var t = x;
                x = y;
                y = t;
            }
        }
    }

    public class Test107
    {
        public static List<object[]> Data { get; } = new List<object[]> {
            new object[] {
                new int?[] { },
                new int[][] {
                },
            },
            new object[] {
                new int?[] { 1 },
                new int[][] {
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 1, null },
                new int[][] {
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 1, 2 },
                new int[][] {
                    new[] { 2 },
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 1, 2, 3 },
                new int[][] {
                    new[] { 2, 3 },
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 1, 2, 3, 4 },
                new int[][] {
                    new[] { 4 },
                    new[] { 2, 3 },
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 1, 2, 3, null, null, null, 7 },
                new int[][] {
                    new[] { 7 },
                    new[] { 2, 3 },
                    new[] { 1 },
                },
            },
            new object[] {
                new int?[] { 3, 9, 20, null, null, 15, 7 },
                new int[][] {
                    new[] { 15, 7 },
                    new[] { 9, 20 },
                    new[] { 3 },
                },
            },
            new object[] {
                new int?[] { 1, 2, 3, null, null, null, 7, null, 9 },
                new int[][] {
                    new[] { 9 },
                    new[] { 7 },
                    new[] { 2, 3 },
                    new[] { 1 },
                },
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void LevelOrderBottom(int?[] tree, int[][] expected)
        {
            var actual = new Solution107().LevelOrderBottom(TreeNode.From(tree));

            for (var i = 0; i < expected.Length; ++i)
                Assert.Equal(expected[i], actual[i]);
        }
    }
}
