using System.Collections.Generic;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        private static readonly Dictionary<char, int> romanSymbolToValue =
            new Dictionary<char, int> {
                ['I'] = 1,
                ['V'] = 5,
                ['X'] = 10,
                ['L'] = 50,
                ['C'] = 100,
                ['D'] = 500,
                ['M'] = 1000,
            };

        // https://leetcode.com/problems/roman-to-integer
        public int RomanToInt(string s)
        {
            var x = 0;
            var lastValue = 0;
            for (var i = s.Length - 1; i >= 0; --i)
            {
                var value = romanSymbolToValue[s[i]];
                if (value >= lastValue)
                    x += value;
                else
                    x -= value;

                lastValue = value;
            }

            return x;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData("I", 1)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XI", 11)]
        [InlineData("XIV", 14)]
        [InlineData("XIX", 19)]
        [InlineData("XX", 20)]
        [InlineData("XXIX", 29)]
        [InlineData("XL", 40)]
        [InlineData("XLIX", 49)]
        [InlineData("LVIII", 58)]
        [InlineData("LXX", 70)]
        [InlineData("XC", 90)]
        [InlineData("XCIX", 99)]
        [InlineData("C", 100)]
        [InlineData("CL", 150)]
        [InlineData("CXC", 190)]
        [InlineData("CC", 200)]
        [InlineData("CD", 400)]
        [InlineData("CDXC", 490)]
        [InlineData("D", 500)]
        [InlineData("DCCC", 800)]
        [InlineData("CM", 900)]
        [InlineData("M", 1000)]
        [InlineData("MDCCCLXXXVIII", 1888)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("MMMCMXCIX", 3999)]
        public void RomanToInt(string roman, int expected)
        {
            Assert.Equal(expected, new Solution().RomanToInt(roman));
        }
    }
}
