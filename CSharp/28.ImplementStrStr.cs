using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/implement-strstr
        public int StrStr(string haystack, string needle)
        {
            if (haystack == null || needle == null)
                return -1;

            for (var h = 0; h + needle.Length <= haystack.Length; ++h)
                for (var n = 0; ; ++n)
                    if (n == needle.Length)
                        return h;
                    else if (haystack[h + n] != needle[n])
                        break;

            return -1;
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(null, null, -1)]
        [InlineData(null, "", -1)]
        [InlineData(null, "A", -1)]
        [InlineData("", null, -1)]
        [InlineData("", "", 0)]
        [InlineData("", "A", -1)]
        [InlineData("A", null, -1)]
        [InlineData("A", "", 0)]
        [InlineData("A", "A", 0)]
        [InlineData("A", "Z", -1)]
        [InlineData("A", "AZ", -1)]
        [InlineData("AA", "A", 0)]
        [InlineData("ABC", "A", 0)]
        [InlineData("ABC", "B", 1)]
        [InlineData("ABC", "C", 2)]
        [InlineData("ABC", "AB", 0)]
        [InlineData("ABC", "BC", 1)]
        [InlineData("ABC", "AC", -1)]
        [InlineData("ABC", "ABC", 0)]
        [InlineData("ABC", "ABZ", -1)]
        [InlineData("ABC", "ABCD", -1)]
        [InlineData("ABCABC", "A", 0)]
        [InlineData("ABCABC", "B", 1)]
        [InlineData("ABCABC", "AB", 0)]
        [InlineData("ABCABC", "BC", 1)]
        [InlineData("ABCABC", "ABC", 0)]
        public void StrStr(string haystack, string needle, int expected)
        {
            Assert.Equal(expected, new Solution().StrStr(haystack, needle));
            if (expected != -1)
                Assert.Equal(haystack.Substring(expected, needle.Length), needle);
        }
    }
}
