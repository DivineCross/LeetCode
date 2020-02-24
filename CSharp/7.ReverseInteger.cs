using System;

using Xunit;

namespace LeetCode
{
    public class Solution7
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

    public class Test7
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(-120, -21)]
        [InlineData(0, 0)]
        [InlineData(2147483647, 0)]
        [InlineData(-2147483648, 0)]
        [InlineData(1534236469, 0)]
        [InlineData(777, 777)]
        [InlineData(9487, 7849)]
        public void Reverse(int x, int expected)
        {
            Assert.Equal(expected, new Solution7().Reverse(x));
        }
    }
}
