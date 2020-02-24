using System;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/maximum-subarray
        public int MaxSubArray(int[] nums)
        {
            if (nums?.Any() != true)
                return 0;

            var max = int.MinValue;
            var sum = 0;
            foreach (var num in nums)
            {
                sum += num;
                max = Math.Max(max, sum);
                sum = Math.Max(0, sum);
            }

            return max;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] { null, 0 })]
        [InlineData(new object[] { new int[] { }, 0 })]
        [InlineData(new object[] { new[] { 0 }, 0 })]
        [InlineData(new object[] { new[] { 1 }, 1 })]
        [InlineData(new object[] { new[] { 2, 4 }, 6 })]
        [InlineData(new object[] { new[] { 2, 0 }, 2 })]
        [InlineData(new object[] { new[] { 1, 2, 3 }, 6 })]
        [InlineData(new object[] { new[] { -3 }, -3 })]
        [InlineData(new object[] { new[] { -3, -2 }, -2 })]
        [InlineData(new object[] { new[] { -3, -6 }, -3 })]
        [InlineData(new object[] { new[] { -4, -1, -2, -3 }, -1 })]
        [InlineData(new object[] { new[] { -1, -2, -4, -3 }, -1 })]
        [InlineData(new object[] { new[] { -3, -3, 3 }, 3 })]
        [InlineData(new object[] { new[] { -3, -2, 3 }, 3 })]
        [InlineData(new object[] { new[] { -3, 1 }, 1 })]
        [InlineData(new object[] { new[] { 2, -3 }, 2 })]
        [InlineData(new object[] { new[] { 2, -3, 4 }, 4 })]
        [InlineData(new object[] { new[] { 2, -3, 9 }, 9 })]
        [InlineData(new object[] { new[] { 1, 2, 3, -50, 2 }, 6 })]
        [InlineData(new object[] { new[] { 1, 2, 3, -3, 2 }, 6 })]
        [InlineData(new object[] { new[] { 1, 2, 3, -2, 2 }, 6 })]
        [InlineData(new object[] { new[] { 1, 2, 3, -1, 2 }, 7 })]
        [InlineData(new object[] { new[] { 1, 2, 3, 0, 2 }, 8 })]
        [InlineData(new object[] { new[] { 1, 2, 3, -50, 2, 5 }, 7 })]
        [InlineData(new object[] { new[] { -2, 5, -1, 9, -4, 8, 7 }, 24 })]
        [InlineData(new object[] { new[] { -2, 5, -2, 9, -4, 8, 7 }, 23 })]
        [InlineData(new object[] { new[] { -2, 5, -6, 9, -4, 8, 7 }, 20 })]
        [InlineData(new object[] { new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6 })]
        [InlineData(new object[] { new[] { 8, -19, 5, -4, 20 }, 21 })]
        [InlineData(new object[] { new[] { 5, 0, -4, -2, 2, -4, 5, -7, 3, 0, 3 }, 6 })]
        [InlineData(new object[] {
            new[] { 9, 0, -2, -2, -3, -4, 0, 1, -4, 5, -8, 7, -3, 7, -6, -4, -7, -8 },
            11,
        })]
        public void MaxSubArray(int[] nums, int expected)
        {
            Assert.Equal(expected, new Solution().MaxSubArray(nums));
        }
    }
}
