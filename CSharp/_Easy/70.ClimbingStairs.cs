using Xunit;

namespace LeetCode
{
    public class Solution70
    {
        // https://leetcode.com/problems/climbing-stairs
        public int ClimbStairs(int n)
        {
            var prev2 = 1;
            var prev1 = 1;
            var sum = 1;

            for (var i = 2; i <= n; ++i)
            {
                sum = prev2 + prev1;
                prev2 = prev1;
                prev1 = sum;
            }

            return sum;
        }
    }

    public class Test70
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        [InlineData(18, 4181)]
        [InlineData(19, 6765)]
        public void ClimbStairs(int n, int expected)
        {
            Assert.Equal(expected, new Solution70().ClimbStairs(n));
        }
    }
}
