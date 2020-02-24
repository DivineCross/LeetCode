using System;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution58
    {
        // https://leetcode.com/problems/length-of-last-word
        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            s = s.TrimEnd();
            var count = 0;
            foreach (var c in s.Reverse())
                if (c == ' ')
                    break;
                else
                    ++count;

            return count;
        }
    }

    public class Test58
    {
        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("  ", 0)]
        [InlineData("Hi", 2)]
        [InlineData("hi", 2)]
        [InlineData("hi ", 2)]
        [InlineData(" hi", 2)]
        [InlineData(" hi ", 2)]
        [InlineData("hi apple", 5)]
        [InlineData("hi apple ", 5)]
        [InlineData(" hi apple ", 5)]
        [InlineData("hi banana apple", 5)]
        [InlineData("Hello World", 5)]
        [InlineData("Hello World.", 6)]
        public void LengthOfLastWord(string s, int expected)
        {
            Assert.Equal(expected, new Solution58().LengthOfLastWord(s));
        }
    }
}
