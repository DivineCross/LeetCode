using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public class Solution20
    {
        private static readonly Dictionary<char, char> leftToRight = new Dictionary<char, char> {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}',
        };

        // https://leetcode.com/problems/valid-parentheses
        public bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (leftToRight.ContainsKey(c))
                    stack.Push(c);
                else if (stack.Any() && leftToRight[stack.Peek()] == c)
                    stack.Pop();
                else
                    return false;
            }

            return !stack.Any();
        }
    }

    public class Test20
    {
        [Theory]
        [InlineData((string)null)]
        [InlineData("")]
        [InlineData("()")]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("()()")]
        [InlineData("()[]")]
        [InlineData("(){}")]
        [InlineData("(())")]
        [InlineData("([])")]
        [InlineData("({})")]
        [InlineData("({})()")]
        [InlineData("({})[]")]
        [InlineData("({}){}")]
        [InlineData("({}){[]}")]
        [InlineData("{([])({})({[()]{}})}")]
        public void IsValidParenthesesTrue(string s)
        {
            Assert.True(new Solution20().IsValid(s));
        }

        [Theory]
        [InlineData("(")]
        [InlineData("[")]
        [InlineData("{")]
        [InlineData(")")]
        [InlineData("]")]
        [InlineData("}")]
        [InlineData("(]")]
        [InlineData("(()")]
        [InlineData("{}(")]
        [InlineData("([)]")]
        [InlineData("({)}")]
        [InlineData("[(())")]
        [InlineData("((()))[")]
        [InlineData(")}{({))[{{[}")]
        public void IsValidParenthesesFalse(string s)
        {
            Assert.False(new Solution20().IsValid(s));
        }
    }
}
