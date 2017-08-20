using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/remove-element
        public int RemoveElement(int[] nums, int val)
        {
            if (nums?.Any() != true)
                return 0;

            int resultLength = 0;
            foreach (var num in nums)
                if (num != val)
                    nums[resultLength++] = num;

            return resultLength;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] {
            null,
            999,
            0 })]
        [InlineData(new object[] {
            new int[] {},
            999,
            0 })]
        [InlineData(new object[] {
            new [] { 1 },
            999,
            1 })]
        [InlineData(new object[] {
            new [] { 1, 2 },
            999,
            2 })]
        [InlineData(new object[] {
            new [] { 1 },
            1,
            0 })]
        [InlineData(new object[] {
            new [] { 1, 2 },
            1,
            1 })]
        [InlineData(new object[] {
            new [] { 1, 1, 2 },
            1,
            1 })]
        [InlineData(new object[] {
            new [] { 1, 2, 2, 3, 3, 3 },
            2,
            4 })]
        public void RemoveElement(int[] nums, int val, int expectedLength)
        {
            Assert.Equal(expectedLength, new Solution().RemoveElement(nums, val));
            Assert.False(nums?.Take(expectedLength)?.Where(n => n == val)?.Any() ?? false);
        }
    }
}
