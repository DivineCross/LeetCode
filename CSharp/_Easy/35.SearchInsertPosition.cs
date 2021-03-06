using System;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution35
    {
        // https://leetcode.com/problems/search-insert-position
        public int SearchInsert(int[] nums, int target)
        {
            if (nums?.Any() != true)
                return 0;

            var length = nums.Length;
            var lastIndex = length - 1;
            var last = nums[lastIndex];
            if (target <= nums[0]) return 0;
            if (target == last) return lastIndex;
            if (target > last) return length;

            var l = 0;
            var r = lastIndex;
            while (l <= r)
            {
                var m = l + ((r - l) / 2);
                var mid = nums[m];
                if (target == mid)
                    return m;

                if (target < mid)
                    r = m - 1;
                else
                    l = m + 1;
            }

            return l;
        }

        public int SearchInsertSol2(int[] nums, int target)
        {
            if (nums?.Any() != true)
                return 0;

            var result = Array.BinarySearch(nums, target);
            return result >= 0 ? result : ~result;
        }
    }

    public class Test35
    {
        [Theory]
        [InlineData(null, 9, 0)]
        [InlineData(new int[] { }, 0, 0)]
        [InlineData(new int[] { }, 9, 0)]
        [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
        [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
        [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
        [InlineData(new[] { 1, 3, 5, 6 }, 0, 0)]
        [InlineData(new[] { 2, 7, 8, 9, 10 }, 9, 3)]
        [InlineData(new[] { 0 }, 0, 0)]
        [InlineData(new[] { 0 }, 1, 1)]
        [InlineData(new[] { 0 }, -1, 0)]
        [InlineData(new[] { 2 }, 1, 0)]
        [InlineData(new[] { 2 }, 2, 0)]
        [InlineData(new[] { 2 }, 3, 1)]
        [InlineData(new[] { -1, 1 }, -2, 0)]
        [InlineData(new[] { -1, 1 }, -1, 0)]
        [InlineData(new[] { -1, 1 }, 0, 1)]
        [InlineData(new[] { -1, 1 }, 1, 1)]
        [InlineData(new[] { -1, 1 }, 2, 2)]
        [InlineData(new[] { -99999, 11111 }, -99999, 0)]
        [InlineData(new[] { -99999, 11111 }, 0, 1)]
        [InlineData(new[] { -99999, 11111 }, 11111, 1)]
        [InlineData(new[] { -99999, 11111 }, 22222, 2)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -6, 0)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -5, 0)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -4, 1)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -3, 1)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -2, 2)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, -1, 2)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 0, 2)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 1, 3)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 2, 3)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 3, 4)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 4, 4)]
        [InlineData(new[] { -5, -3, 0, 2, 4 }, 5, 5)]
        public void SearchInsert(int[] nums, int target, int expected)
        {
            Assert.Equal(expected, new Solution35().SearchInsert(nums, target));
        }
    }
}
