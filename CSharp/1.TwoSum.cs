using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/two-sum
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                var num = nums[i];
                var diff = target - num;
                if (map.ContainsKey(num))
                    return new[] { map[num], i };

                map[diff] = i;
            }

            throw new InvalidOperationException();
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 50, 50 }, 100, new[] { 0, 1 })]
        [InlineData(new[] { 1, 50, 50, 25 }, 100, new[] { 1, 2 })]
        [InlineData(new[] { 1, 2, 3, 6 }, 5, new[] { 1, 2 })]
        public void TwoSum(int[] nums, int target, int[] expectedIndexes)
        {
            Assert.True(new Solution().TwoSum(nums, target).ToHashSet()
                .SetEquals(expectedIndexes.ToHashSet()));
        }
    }
}
