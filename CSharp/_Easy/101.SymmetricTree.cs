using System.Collections.Generic;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution101
    {
        // https://leetcode.com/problems/symmetric-tree
        public bool IsSymmetric(TreeNode root)
        {
            return root == null
                || IsSym(root.left, root.right);

            bool IsSym(TreeNode x, TreeNode y) =>
                x == y
                    || (x?.val == y?.val && IsSym(x.left, y.right) && IsSym(x.right, y.left));
        }
    }

    public class Test101
    {
        public static List<object[]> Data { get; } = new List<object[]> {
            new object[] {
                new int?[] { },
                true,
            },
            new object[] {
                new int?[] { 1, null },
                true,
            },
            new object[] {
                new int?[] { 1, 2 },
                false,
            },
            new object[] {
                new int?[] { 1, 1, 1 },
                true,
            },
            new object[] {
                new int?[] { 1, 2, 2 },
                true,
            },
            new object[] {
                new int?[] { 1, 2, 2, 3, 4, 4, 3 },
                true,
            },
            new object[] {
                new int?[] { 1, 2, 2, null, 3, null,3 },
                false,
            },
            new object[] {
                new int?[] { 1, null, 2, null, 2 },
                false,
            },
            new object[] {
                new int?[] { 1, 5, 5, null, 2, 2, null },
                true,
            },
            new object[] {
                new int?[] { 1, 1, 1, 1, 1, 1, null },
                false,
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void IsSymmetric(int?[] tree, bool expected)
        {
            Assert.Equal(
                expected,
                new Solution101().IsSymmetric(TreeNode.From(tree)));
        }
    }
}
