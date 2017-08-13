using System;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/remove-duplicates-from-sorted-array
        public int RemoveDuplicates(int[] nums)
        {
            if ( (nums?.Length ?? 0) < 1 )
                return 0;

            int distinctCount = 1;
            for ( int i = 1, repeatingNum = nums[0]; i < nums.Length; ++i )
                if ( nums[i] != repeatingNum )
                    repeatingNum = nums[distinctCount++] = nums[i];

            return distinctCount;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] {
            null,
            null })]
        [InlineData(new object[] {
            new int[] {},
            new int[] {} })]
        [InlineData(new object[] {
            new [] { 1 },
            new [] { 1 } })]
        [InlineData(new object[] {
            new [] { 1, 2 },
            new [] { 1, 2 } })]
        [InlineData(new object[] {
            new [] { 1, 1, 2 },
            new [] { 1, 2 } })]
        [InlineData(new object[] {
            new [] { 1, 1, 2, 2 },
            new [] { 1, 2 } })]
        [InlineData(new object[] {
            new [] { 1, 2, 2, 3, 3, 3 },
            new [] { 1, 2, 3 } })]
        public void RemoveDuplicates(int[] nums, int[] expected)
        {
            int expectedLength = expected?.Length ?? 0;
            Assert.Equal(expectedLength, new Solution().RemoveDuplicates(nums));
            Assert.Equal(expected, nums?.Take(expectedLength)?.ToArray());
        }
    }
}
