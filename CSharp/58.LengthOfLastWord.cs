using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/length-of-last-word
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            s = s.TrimEnd();
            var count = 0;
            foreach (char c in s.Reverse())
                if (c == ' ')
                    break;
                else
                    ++count;

            return count;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] { null, 0 })]
        [InlineData(new object[] { "", 0 })]
        [InlineData(new object[] { " ", 0 })]
        [InlineData(new object[] { "  ", 0 })]
        [InlineData(new object[] { "Hi", 2 })]
        [InlineData(new object[] { "hi", 2 })]
        [InlineData(new object[] { "hi ", 2 })]
        [InlineData(new object[] { " hi", 2 })]
        [InlineData(new object[] { " hi ", 2 })]
        [InlineData(new object[] { "hi apple", 5 })]
        [InlineData(new object[] { "hi apple ", 5 })]
        [InlineData(new object[] { " hi apple ", 5 })]
        [InlineData(new object[] { "hi banana apple", 5 })]
        [InlineData(new object[] { "Hello World", 5 })]
        public void LengthOfLastWord(string s, int expected)
        {
            Assert.Equal(expected, new Solution().LengthOfLastWord(s));
        }
    }
}
