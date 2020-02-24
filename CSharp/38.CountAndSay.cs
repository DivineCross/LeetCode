using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        private static readonly List<string> countAndSay = new List<string> { string.Empty, "1" };

        // https://leetcode.com/problems/count-and-say
        public string CountAndSay(int n)
        {
            if (n <= 0)
                return string.Empty;

            var lastString = countAndSay.Last();
            var sb = new StringBuilder();
            for (var i = countAndSay.Count; i <= n; ++i)
            {
                sb.Clear();
                var repeating = lastString[0];
                var count = 0;
                foreach (var c in lastString + "*")
                {
                    if (c == repeating)
                    {
                        count++;
                        continue;
                    }

                    sb.Append(count).Append(repeating);
                    repeating = c;
                    count = 1;
                }
                countAndSay.Add(lastString = sb.ToString());
            }

            return countAndSay[n];
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] { -99999, "" })]
        [InlineData(new object[] { -1, "" })]
        [InlineData(new object[] { 0, "" })]
        [InlineData(new object[] { 1, "1" })]
        [InlineData(new object[] { 2, "11" })]
        [InlineData(new object[] { 3, "21" })]
        [InlineData(new object[] { 4, "1211" })]
        [InlineData(new object[] { 5, "111221" })]
        [InlineData(new object[] { 6, "312211" })]
        [InlineData(new object[] { 7, "13112221" })]
        [InlineData(new object[] { 8, "1113213211" })]
        [InlineData(new object[] { 9, "31131211131221" })]
        [InlineData(new object[] { 10, "13211311123113112211" })]
        [InlineData(new object[] { 11, "11131221133112132113212221" })]
        [InlineData(new object[] { 12, "3113112221232112111312211312113211" })]
        [InlineData(new object[] { 13, "1321132132111213122112311311222113111221131221" })]
        public void CountAndSay(int n, string expected)
        {
            Assert.Equal(expected, new Solution().CountAndSay(n));
        }
    }
}
