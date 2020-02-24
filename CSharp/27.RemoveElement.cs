using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution27
    {
        // https://leetcode.com/problems/remove-element
        public int RemoveElement(int[] nums, int val)
        {
            if (nums?.Any() != true)
                return 0;

            var resultLength = 0;
            foreach (var num in nums)
                if (num != val)
                    nums[resultLength++] = num;

            return resultLength;
        }
    }

    public class Test27
    {
        [Theory]
        [InlineData(
            null,
            999,
            0)]
        [InlineData(
            new int[] {},
            999,
            0)]
        [InlineData(
            new[] { 1 },
            999,
            1)]
        [InlineData(
            new[] { 1, 2 },
            999,
            2)]
        [InlineData(
            new[] { 1 },
            1,
            0)]
        [InlineData(
            new[] { 1, 2 },
            1,
            1)]
        [InlineData(
            new[] { 1, 1, 2 },
            1,
            1)]
        [InlineData(
            new[] { 1, 2, 2, 3, 3, 3 },
            2,
            4)]
        public void RemoveElement(int[] nums, int val, int expectedLength)
        {
            Assert.Equal(expectedLength, new Solution27().RemoveElement(nums, val));
            Assert.False(nums?.Take(expectedLength).Any(n => n == val) ?? false);
        }
    }
}
