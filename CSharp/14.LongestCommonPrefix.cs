using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/longest-common-prefix
        public string LongestCommonPrefix(string[] strs)
        {
            if (!(strs?.Length > 0))
                return string.Empty;

            var firstStr = strs[0] ?? string.Empty;
            var prefixLength = firstStr.Length;
            for (var iStr = 1; iStr < strs.Length && prefixLength > 0; ++iStr)
                for (var iChar = 0; iChar < prefixLength; ++iChar)
                    if (!(iChar < strs[iStr]?.Length) || firstStr[iChar] != strs[iStr][iChar])
                        prefixLength = iChar;

            return firstStr.Substring(0, prefixLength);
        }

        public string LongestCommonPrefixSol2(string[] strs)
        {
            if (!(strs?.Length > 0))
                return string.Empty;

            var firstStr = strs[0] ?? string.Empty;
            var prefixLength = firstStr.Length;
            for (var i = 1; i < strs.Length && prefixLength > 0; ++i)
                updatePrefixLength(strs[i]);

            return firstStr.Substring(0, prefixLength);

            void updatePrefixLength(string theStr)
            {
                for (var i = 0; i < prefixLength; ++i)
                    if (!(i < theStr?.Length) || firstStr[i] != theStr[i])
                        prefixLength = i;
            }
        }

        public string LongestCommonPrefixSol3(string[] strs)
        {
            if (!(strs?.Length > 0))
                return string.Empty;

            var firstStr = strs[0] ?? string.Empty;
            int prefixLength;
            for (prefixLength = 0; hasCommonChar(prefixLength); ++prefixLength)
                continue;

            return firstStr.Substring(0, prefixLength);

            bool hasCommonChar(int index)
            {
                if (!(index < firstStr.Length))
                    return false;

                var c = firstStr[index];
                foreach (var str in strs)
                    if (!(index < str?.Length) || str[index] != c)
                        return false;

                return true;
            }
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData(new string[] { }, "")]
        [InlineData(new string[] { null }, "")]
        [InlineData(new string[] { "" }, "")]
        [InlineData(new string[] { "a" }, "a")]
        [InlineData(new string[] { "a", null }, "")]
        [InlineData(new string[] { "a", "" }, "")]
        [InlineData(new string[] { "a", "b" }, "")]
        [InlineData(new string[] { "a", "a" }, "a")]
        [InlineData(new string[] { "a", "a", null }, "")]
        [InlineData(new string[] { "a", "ab", "ac" }, "a")]
        [InlineData(new string[] { "ab", "abc", "abc" }, "ab")]
        [InlineData(new string[] { "abc", "abc", "abc" }, "abc")]
        [InlineData(new string[] { "flower","flow","flight" }, "fl")]
        [InlineData(new string[] { "dog","racecar","car" }, "")]
        public void LongestCommonPrefix(string[] strs, string expected)
        {
            Assert.Equal(expected, new Solution().LongestCommonPrefix(strs));
        }
    }
}
