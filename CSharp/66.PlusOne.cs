using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/plus-one
        public int[] PlusOne(int[] digits)
        {
            if (digits?.Any() != true)
                return new int[0];

            List<int> digitList = digits.ToList();
            for (int i = digitList.Count - 1; i >= 0; --i)
            {
                if (digitList[i] != 9)
                {
                    digitList[i]++;
                    return digitList.ToArray();
                }
                digitList[i] = 0;
            }
            digitList.Insert(0, 1);

            return digitList.ToArray();
        }
    }

    public partial class Test
    {
        [Theory]
        [InlineData(new object[] { null, new int[0] })]
        [InlineData(new object[] { new int[0], new int[0] })]
        [InlineData(new object[] {
            new [] { 0 },
            new [] { 1 } })]
        [InlineData(new object[] {
            new [] { 1 },
            new [] { 2 } })]
        [InlineData(new object[] {
            new [] {    9 },
            new [] { 1, 0 } })]
        [InlineData(new object[] {
            new [] { 1, 9 },
            new [] { 2, 0 } })]
        [InlineData(new object[] {
            new [] { 6, 9 },
            new [] { 7, 0 } })]
        [InlineData(new object[] {
            new [] {    9, 9 },
            new [] { 1, 0, 0 } })]
        [InlineData(new object[] {
            new [] { 1, 8, 9 },
            new [] { 1, 9, 0 } })]
        [InlineData(new object[] {
            new [] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 7 },
            new [] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 8 } })]
        [InlineData(new object[] {
            new [] {    9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 },
            new [] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } })]
        public void PlusOne(int[] digits, int[] expected)
        {
            Assert.Equal(expected, new Solution().PlusOne(digits));
        }
    }
}
