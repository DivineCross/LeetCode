using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution88
    {
        // https://leetcode.com/problems/merge-sorted-array
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var t1 = m - 1;
            var t2 = n - 1;
            for (var tail = m + n - 1; tail >= 0 && t2 >= 0; --tail)
                nums1[tail] = t1 < 0
                    ? nums2[t2--]
                    : nums1[t1] > nums2[t2]
                        ? nums1[t1--]
                        : nums2[t2--];
        }
    }

    public class Test88
    {
        [Theory]
        [InlineData(
            new int[] { },
            new int[] { },
            new int[] { })]
        [InlineData(
            new int[] { },
            new int[] { 1 },
            new int[] { 1 })]
        [InlineData(
            new int[] { 2 },
            new int[] { },
            new int[] { 2 })]
        [InlineData(
            new[] { 1, 2 },
            new[] { 4, 5 },
            new[] { 1, 2, 4, 5 })]
        [InlineData(
            new[] { 1, 2, 3 },
            new[] { 2, 5, 6 },
            new[] { 1, 2, 2, 3, 5, 6 })]
        public void Merge(int[] nums1, int[] nums2, int[] expected)
        {
            var inputs = nums1.Concat(Enumerable.Repeat(0, nums2.Length)).ToArray();
            new Solution88().Merge(inputs, nums1.Length, nums2, nums2.Length);

            Assert.Equal(expected, inputs);
        }
    }
}
