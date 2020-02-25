using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution104
    {
        // https://leetcode.com/problems/maximum-depth-of-binary-tree
        public int MaxDepth(TreeNode root)
        {
            return root == null
                ? 0
                : 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
        }
    }

    public class Test104
    {
        public static List<object[]> Data { get; } = new List<object[]> {
            new object[] {
                new int?[] { },
                0,
            },
            new object[] {
                new int?[] { 1 },
                1,
            },
            new object[] {
                new int?[] { 1, null },
                1,
            },
            new object[] {
                new int?[] { 1, 2 },
                2,
            },
            new object[] {
                new int?[] { 1, 2, 3 },
                2,
            },
            new object[] {
                new int?[] { 1, 2, 3, 4 },
                3,
            },
            new object[] {
                new int?[] { 1, 2, 3, null, null, null, 7 },
                3,
            },
            new object[] {
                new int?[] { 3, 9, 20, null, null, 15, 7 },
                3,
            },
            new object[] {
                new int?[] { 1, 2, 3, null, null, null, 7, null, 9 },
                4,
            },
            new object[] {
                Enumerable.Repeat((int?)1, 1 << 10 - 1).ToArray(),
                10,
            },
            new object[] {
                Enumerable.Repeat((int?)1, 1 << 15 - 1).ToArray(),
                15,
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void MaxDepth(int?[] tree, int expected)
        {
            Assert.Equal(
                expected,
                new Solution104().MaxDepth(TreeNode.From(tree)));
        }
    }
}
