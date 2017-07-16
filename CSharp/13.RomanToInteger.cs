using System;
using System.Collections.Generic;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        private static Dictionary<char, int> romanSymbolToValue = new Dictionary<char, int> {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        // https://leetcode.com/problems/roman-to-integer
        public int RomanToInt(string s)
        {
            int x = 0;
            int lastValue = 0;
            for (int i = s.Length - 1; i >= 0; --i)
            {
                int value = romanSymbolToValue[s[i]];
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
        [Fact]
        public void RomanToInt()
        {
            Func<string, int> romanToInt = new Solution().RomanToInt;

            Assert.Equal(1, romanToInt("I"));
            Assert.Equal(4, romanToInt("IV"));
            Assert.Equal(5, romanToInt("V"));
            Assert.Equal(8, romanToInt("VIII"));
            Assert.Equal(9, romanToInt("IX"));
            Assert.Equal(10, romanToInt("X"));
            Assert.Equal(11, romanToInt("XI"));
            Assert.Equal(14, romanToInt("XIV"));
            Assert.Equal(19, romanToInt("XIX"));
            Assert.Equal(20, romanToInt("XX"));
            Assert.Equal(29, romanToInt("XXIX"));
            Assert.Equal(40, romanToInt("XL"));
            Assert.Equal(49, romanToInt("XLIX"));
            Assert.Equal(70, romanToInt("LXX"));
            Assert.Equal(90, romanToInt("XC"));
            Assert.Equal(99, romanToInt("XCIX"));
            Assert.Equal(100, romanToInt("C"));
            Assert.Equal(150, romanToInt("CL"));
            Assert.Equal(190, romanToInt("CXC"));
            Assert.Equal(200, romanToInt("CC"));
            Assert.Equal(400, romanToInt("CD"));
            Assert.Equal(490, romanToInt("CDXC"));
            Assert.Equal(500, romanToInt("D"));
            Assert.Equal(800, romanToInt("DCCC"));
            Assert.Equal(900, romanToInt("CM"));
            Assert.Equal(1000, romanToInt("M"));
            Assert.Equal(1888, romanToInt("MDCCCLXXXVIII"));
            Assert.Equal(3999, romanToInt("MMMCMXCIX"));
        }
    }
}
