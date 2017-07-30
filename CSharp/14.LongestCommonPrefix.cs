using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/longest-common-prefix
        public string LongestCommonPrefix(string[] strs)
        {
            if ( !(strs?.Length > 0) )
                return string.Empty;

            string firstStr = strs[0] ?? string.Empty;
            int prefixLength = firstStr.Length;
            for ( int iStr = 1; iStr < strs.Length && prefixLength > 0; ++iStr )
                for ( int iChar = 0; iChar < prefixLength; ++iChar )
                    if ( !(iChar < strs[iStr]?.Length) || firstStr[iChar] != strs[iStr][iChar] )
                        prefixLength = iChar;

            return firstStr.Substring(0, prefixLength);
        }

        public string LongestCommonPrefixSol2(string[] strs)
        {
            if ( !(strs?.Length > 0) )
                return string.Empty;

            string firstStr = strs[0] ?? string.Empty;
            int prefixLength = firstStr.Length;
            Action<string> updatePrefixLength = theStr => {
                for ( int i = 0; i < prefixLength; ++i )
                    if ( !(i < theStr?.Length) || firstStr[i] != theStr[i] )
                        prefixLength = i;
            };
            for ( int i = 1; i < strs.Length && prefixLength > 0; ++i )
                updatePrefixLength(strs[i]);

            return firstStr.Substring(0, prefixLength);
        }

        public string LongestCommonPrefixSol3(string[] strs)
        {
            if ( !(strs?.Length > 0) )
                return string.Empty;

            string firstStr = strs[0] ?? string.Empty;
            Func<int, bool> hasCommonChar = index => {
                if ( !(index < firstStr.Length) )
                    return false;

                char c = firstStr[index];
                foreach (var str in strs)
                    if ( !(index < str?.Length) || str[index] != c )
                        return false;

                return true;
            };

            int prefixLength;
            for (prefixLength = 0; hasCommonChar(prefixLength); ++prefixLength)
                continue;

            return firstStr.Substring(0, prefixLength);
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData( new object[] { null, "" } )]
        [InlineData( new object[] { new string[] { }, "" } )]
        [InlineData( new object[] { new string[] { null }, "" } )]
        [InlineData( new object[] { new string[] { "" }, "" } )]
        [InlineData( new object[] { new string[] { "a" }, "a" } )]
        [InlineData( new object[] { new string[] { "a", null }, "" } )]
        [InlineData( new object[] { new string[] { "a", "" }, "" } )]
        [InlineData( new object[] { new string[] { "a", "b" }, "" } )]
        [InlineData( new object[] { new string[] { "a", "a" }, "a" } )]
        [InlineData( new object[] { new string[] { "a", "a", null }, "" } )]
        [InlineData( new object[] { new string[] { "a", "ab", "ac" }, "a" } )]
        [InlineData( new object[] { new string[] { "ab", "abc", "abc" }, "ab" } )]
        [InlineData( new object[] { new string[] { "abc", "abc", "abc" }, "abc" } )]
        public void LongestCommonPrefix(string[] strs, string expected)
        {
            Assert.Equal(expected, new Solution().LongestCommonPrefix(strs));
        }
    }
}
