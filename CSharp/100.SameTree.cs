using System.Collections.Generic;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution100
    {
        // https://leetcode.com/problems/same-tree
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            return p == null && q == null
                ? true
                : p?.val != q?.val
                    ? false
                    : IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }

    public class Test100
    {
        public static List<object[]> Data { get; } = new List<object[]> {
            new object[] {
                new int?[] { },
                new int?[] { },
                true,
            },
            new object[] {
                new int?[] { },
                new int?[] { 1 },
                false,
            },
            new object[] {
                new int?[] { 1, null },
                new int?[] { 1, null },
                true,
            },
            new object[] {
                new int?[] { 1, 2, 3 },
                new int?[] { 1, 3, 2 },
                false,
            },
            new object[] {
                new int?[] { 1, null, 2, null, 3 },
                new int?[] { 1, null, 2, null, 3 },
                true,
            },
            new object[] {
                new int?[] { 1, null, 2, null, 3 },
                new int?[] { 1, null, 2, null, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
                false,
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void IsSameTree(int?[] p, int?[] q, bool expected)
        {
            Assert.Equal(
                expected,
                new Solution100().IsSameTree(TreeNode.From(p), TreeNode.From(q)));
        }
    }
}
