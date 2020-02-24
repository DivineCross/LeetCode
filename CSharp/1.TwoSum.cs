using System;
using System.Collections.Generic;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/two-sum
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; ++i)
            {
                var num = nums[i];
                var diff = target - num;
                if (dict.ContainsKey(num))
                    return new[] { dict[num], i };

                dict[diff] = i;
            }

            return new[] { -1, -1 };
        }
    }

    public partial class Test
    {
        [Fact]
        public void TwoSum()
        {
            Func<int[], int, int[]> twoSum = new Solution().TwoSum;

            Assert.Equal(new[] { 1, 2 }, twoSum(new[] { 1, 2, 3, 6 }, 5));
        }
    }
}
