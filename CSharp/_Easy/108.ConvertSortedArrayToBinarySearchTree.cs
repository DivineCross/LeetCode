using System.Collections.Generic;
using System.Linq;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution108
    {
        // https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
        public TreeNode SortedArrayToBST(int[] nums)
        {
            return CreateRoot(0, nums.Length);

            TreeNode CreateRoot(int l, int r)
            {
                if (l >= r)
                    return null;

                var m = (l + r) / 2;

                return new TreeNode(nums[m]) {
                    left = CreateRoot(l, m),
                    right = CreateRoot(m + 1, r),
                };
            }
        }
    }

    public class Test108
    {
        public static List<object[]> Data { get; } = new List<object[]> {
            new object[] {
                new int[] { },
                new int?[] { },
            },
            new object[] {
                new int[] { 1 },
                new int?[] { 1 },
            },
            new object[] {
                new int[] { 1, 2 },
                new int?[] { 2, 1 },
            },
            new object[] {
                new int[] { 1, 2, 3 },
                new int?[] { 2, 1, 3 },
            },
            new object[] {
                new int[] { 1, 2, 3, 4 },
                new int?[] { 3, 2, 4, 1 },
            },
            new object[] {
                new int[] { 1, 2, 3, 4, 5 },
                new int?[] { 3, 2, 5, 1, null, 4 },
            },
            new object[] {
                new int[] { 1, 2, 3, 4, 5, 6, 7 },
                new int?[] { 4, 2, 6, 1, 3, 5, 7 },
            },
            new object[] {
                new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
                new int?[] { 6, 3, 9, 2, 5, 8, 10, 1, null, 4, null, 7 },
            },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void SortedArrayToBST(int[] nums, int?[] expected)
        {
            Assert.Equal(
                expected,
                new Solution108().SortedArrayToBST(nums).ToArray());
        }
    }
}
