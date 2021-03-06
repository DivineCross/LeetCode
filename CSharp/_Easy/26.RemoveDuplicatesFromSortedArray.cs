using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution26
    {
        // https://leetcode.com/problems/remove-duplicates-from-sorted-array
        public int RemoveDuplicates(int[] nums)
        {
            if ((nums?.Length ?? 0) < 1)
                return 0;

            var distinctCount = 1;
            for (int i = 1, repeatingNum = nums[0]; i < nums.Length; ++i)
                if (nums[i] != repeatingNum)
                    repeatingNum = nums[distinctCount++] = nums[i];

            return distinctCount;
        }
    }

    public class Test26
    {
        [Theory]
        [InlineData(
            null,
            null)]
        [InlineData(
            new int[] {},
            new int[] {})]
        [InlineData(
            new[] { 1 },
            new[] { 1 })]
        [InlineData(
            new[] { 1, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 1, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 1, 2, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 2, 2, 3, 3, 3 },
            new[] { 1, 2, 3 })]
        public void RemoveDuplicates(int[] nums, int[] expected)
        {
            var expectedLength = expected?.Length ?? 0;
            Assert.Equal(expectedLength, new Solution26().RemoveDuplicates(nums));
            Assert.Equal(expected, nums?.Take(expectedLength));
        }
    }
}
