using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public class Solution38
    {
        private static readonly List<string> countAndSayStrs = new List<string> {
            string.Empty,
            "1",
        };

        // https://leetcode.com/problems/count-and-say
        public string CountAndSay(int n)
        {
            if (n <= 0)
                return string.Empty;

            var lastString = countAndSayStrs.Last();
            var sb = new StringBuilder();
            for (var i = countAndSayStrs.Count; i <= n; ++i)
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

                lastString = sb.ToString();
                countAndSayStrs.Add(lastString);
            }

            return countAndSayStrs[n];
        }
    }

    public class Test38
    {
        [Theory]
        [InlineData(-99999, "")]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        [InlineData(1, "1")]
        [InlineData(2, "11")]
        [InlineData(3, "21")]
        [InlineData(4, "1211")]
        [InlineData(5, "111221")]
        [InlineData(6, "312211")]
        [InlineData(7, "13112221")]
        [InlineData(8, "1113213211")]
        [InlineData(9, "31131211131221")]
        [InlineData(10, "13211311123113112211")]
        [InlineData(11, "11131221133112132113212221")]
        [InlineData(12, "3113112221232112111312211312113211")]
        [InlineData(13, "1321132132111213122112311311222113111221131221")]
        public void CountAndSay(int n, string expected)
        {
            Assert.Equal(expected, new Solution38().CountAndSay(n));
        }
    }
}
