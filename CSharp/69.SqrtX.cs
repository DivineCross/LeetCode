using System;

using Xunit;

namespace LeetCode
{
    public class Solution69
    {
        // https://leetcode.com/problems/sqrtx
        public int MySqrt(int x)
        {
            if (x <= 1)
                return x;

            var l = 1;
            var r = Math.Min(46340, x / 2);
            while (l <= r)
            {
                var m = (l + r) / 2;
                var square = m * m;

                if (x > square)
                    l = m + 1;
                else if (x < square)
                    r = m - 1;
                else
                    return m;
            }

            return Math.Min(l, r);
        }
    }

    public class Test69
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 2)]
        [InlineData(5, 2)]
        [InlineData(9, 3)]
        [InlineData(13, 3)]
        [InlineData(600, 24)]
        [InlineData(700, 26)]
        [InlineData(2147483647, 46340)]
        public void MySqrt(int x, int expected)
        {
            Assert.Equal(expected, new Solution69().MySqrt(x));
        }
    }
}
