using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/palindrome-number
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x >= 10 && x % 10 == 0))
                return false;

            var revX = 0;
            while (x > revX)
            {
                revX = revX * 10 + x % 10;
                x /= 10;
            }

            return x == revX || x == revX / 10;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(777)]
        [InlineData(123454321)]
        [InlineData(1234554321)]
        public void IsPalindromeTrue(int x)
        {
            Assert.True(new Solution().IsPalindrome(x));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(78)]
        [InlineData(4455)]
        [InlineData(5566)]
        [InlineData(1010)]
        [InlineData(-777)]
        [InlineData(-787)]
        [InlineData(-123454321)]
        [InlineData(-1234554321)]
        [InlineData(-2147483648)]
        public void IsPalindromeFalse(int x)
        {
            Assert.False(new Solution().IsPalindrome(x));
        }
    }
}
