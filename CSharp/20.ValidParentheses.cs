using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/valid-parentheses
        public bool IsValidParentheses(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var leftToRight = new Dictionary<char, char> {
                ['('] = ')',
                ['['] = ']',
                ['{'] = '}',
            };

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

    public partial class Test
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
            Assert.True(new Solution().IsValidParentheses(s));
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
            Assert.False(new Solution().IsValidParentheses(s));
        }
    }
}
