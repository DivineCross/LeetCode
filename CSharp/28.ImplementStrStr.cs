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
        [InlineData(new object[] { null, null, -1 })]
        [InlineData(new object[] { null, "", -1 })]
        [InlineData(new object[] { null, "A", -1 })]
        [InlineData(new object[] { "", null, -1 })]
        [InlineData(new object[] { "", "", 0 })]
        [InlineData(new object[] { "", "A", -1 })]
        [InlineData(new object[] { "A", null, -1 })]
        [InlineData(new object[] { "A", "", 0 })]
        [InlineData(new object[] { "A", "A", 0 })]
        [InlineData(new object[] { "A", "Z", -1 })]
        [InlineData(new object[] { "A", "AZ", -1 })]
        [InlineData(new object[] { "AA", "A", 0 })]
        [InlineData(new object[] { "ABC", "A", 0 })]
        [InlineData(new object[] { "ABC", "B", 1 })]
        [InlineData(new object[] { "ABC", "C", 2 })]
        [InlineData(new object[] { "ABC", "AB", 0 })]
        [InlineData(new object[] { "ABC", "BC", 1 })]
        [InlineData(new object[] { "ABC", "AC", -1 })]
        [InlineData(new object[] { "ABC", "ABC", 0 })]
        [InlineData(new object[] { "ABC", "ABZ", -1 })]
        [InlineData(new object[] { "ABC", "ABCD", -1 })]
        [InlineData(new object[] { "ABCABC", "A", 0 })]
        [InlineData(new object[] { "ABCABC", "B", 1 })]
        [InlineData(new object[] { "ABCABC", "AB", 0 })]
        [InlineData(new object[] { "ABCABC", "BC", 1 })]
        [InlineData(new object[] { "ABCABC", "ABC", 0 })]
        public void StrStr(string haystack, string needle, int expectedIndex)
        {
            Assert.Equal(expectedIndex, new Solution().StrStr(haystack, needle));
            if (expectedIndex != -1)
                Assert.Equal(haystack.Substring(expectedIndex, needle.Length), needle);
        }
    }
}
