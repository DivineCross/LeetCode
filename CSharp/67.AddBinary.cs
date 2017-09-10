using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/add-binary
        public string AddBinary(string a, string b)
        {
            if (string.IsNullOrEmpty(a)) return b ?? string.Empty;
            if (string.IsNullOrEmpty(b)) return a ?? string.Empty;

            if (a.Length > 1) a = a.TrimStart('0');
            if (b.Length > 1) b = b.TrimStart('0');

            var length = Math.Max(a.Length, b.Length);
            a = a.PadLeft(length, '0');
            b = b.PadLeft(length, '0');

            var sb = new StringBuilder();
            bool c = false;
            for (int i = length - 1; i >= 0; --i)
            {
                bool x = a[i] == '1';
                bool y = b[i] == '1';
                bool s = c ^ x ^ y;
                c = x && y || x && c || y && c;

                sb.Insert(0, s ? '1' : '0');
            }
            if (c)
                sb.Insert(0, '1');

            return sb.ToString();
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] { null, null, "" })]
        [InlineData(new object[] { null, "", "" })]
        [InlineData(new object[] { "", null, "" })]
        [InlineData(new object[] { "", "", "" })]
        [InlineData(new object[] { "", "0", "0" })]
        [InlineData(new object[] { "0", "", "0" })]
        [InlineData(new object[] { "0", "0", "0" })]
        [InlineData(new object[] {
            "0",
            "1",
            "1" })]
        [InlineData(new object[] {
            "01",
            "01",
            "10" })]
        [InlineData(new object[] {
            "10",
            "01",
            "11" })]
        [InlineData(new object[] {
            "110",
            "001",
            "111" })]
        [InlineData(new object[] {
            "000000100",
            "011111111",
            "100000011" })]
        [InlineData(new object[] {
            "010000100",
            "011111111",
            "110000011" })]
        [InlineData(new object[] {
            "01111111111111111111111111111111",
            "01111111111111111111111111111111",
            "11111111111111111111111111111110" })]
        [InlineData(new object[] {
            "11111100000000000000000000000000000000",
            "00000011111111111111111111111111111111",
            "11111111111111111111111111111111111111" })]
        [InlineData(new object[] {
            "011111100000000000000000000000000000000",
            "011111111111111111111111111111111111111",
            "111111011111111111111111111111111111111" })]
        public void AddBinary(string a, string b, string expected)
        {
            Assert.Equal(expected, new Solution().AddBinary(a, b));
        }
    }
}
