using System;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/reverse-integer
        public int Reverse(int x)
        {
            var revX = 0;
            while (x != 0)
            {
                try
                {
                    revX = checked(revX * 10 + x % 10);
                }
                catch (OverflowException)
                {
                    return 0;
                }
                x /= 10;
            }

            return revX;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(2147483647, 0)]
        [InlineData(-2147483648, 0)]
        [InlineData(1534236469, 0)]
        [InlineData(230, 32)]
        [InlineData(777, 777)]
        [InlineData(9487, 7849)]
        public void Reverse(int x, int expected)
        {
            Assert.Equal(expected, new Solution().Reverse(x));
        }
    }
}
