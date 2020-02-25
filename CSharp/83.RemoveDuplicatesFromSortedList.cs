using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution83
    {
        // https://leetcode.com/problems/remove-duplicates-from-sorted-list
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;

            var nonDup = head;
            var current = head.next;
            while (current != null)
            {
                if (current.val != nonDup.val)
                {
                    nonDup.next = current;
                    nonDup = current;
                }

                current = current.next;
            }
            nonDup.next = null;

            return head;
        }
    }

    public class Test83
    {
        [Theory]
        [InlineData(
            new int[] {},
            new int[] {})]
        [InlineData(
            new[] { 1 },
            new[] { 1 })]
        [InlineData(
            new[] { 1, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 1, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 1, 2, 2 },
            new[] { 1, 2 })]
        [InlineData(
            new[] { 1, 1, 2, 3, 3 },
            new[] { 1, 2, 3 })]
        [InlineData(
            new[] { 1, 2, 2, 3, 3, 3 },
            new[] { 1, 2, 3 })]
        public void DeleteDuplicates(int[] nums, int[] expected)
        {
            Assert.Equal(
                expected,
                new Solution83().DeleteDuplicates(ListNode.FromCollection(nums)).AsEnumerable());
        }
    }
}
