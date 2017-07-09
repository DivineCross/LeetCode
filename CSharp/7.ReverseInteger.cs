using System;
using System.Collections.Generic;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/reverse-integer
        public int Reverse(int x)
        {
            int revX = 0;
            while (x != 0)
            {
                try {
                    revX = checked(revX * 10 + x % 10);
                } catch (OverflowException) {
                    return 0;
                }
                x /= 10;
            }

            return revX;
        }
    }

    public partial class Test
    {
        [Fact]
        public void Reverse()
        {
            Func<int, int> reverseInteger = new Solution().Reverse;

            Assert.Equal(0, reverseInteger(0));
            Assert.Equal(0, reverseInteger(2147483647));
            Assert.Equal(0, reverseInteger(-2147483648));
            Assert.Equal(0, reverseInteger(1534236469));
            Assert.Equal(32, reverseInteger(230));
        }
    }
}
