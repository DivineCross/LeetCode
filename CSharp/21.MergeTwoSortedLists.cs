using System.Linq;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public class Solution21
    {
        // https://leetcode.com/problems/merge-two-sorted-lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var dummyHead = new ListNode(0);
            var tail = dummyHead;
            while (l1 != null && l2 != null)
            {
                ListNode next;
                if (l1.val < l2.val)
                {
                    next = l1;
                    l1 = l1.next;
                }
                else
                {
                    next = l2;
                    l2 = l2.next;
                }

                tail.next = next;
                tail = tail.next;
            }

            if (l1 == null) tail.next = l2;
            if (l2 == null) tail.next = l1;

            return dummyHead.next;
        }

        public ListNode MergeTwoListsSol2(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoListsSol2(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoListsSol2(l1, l2.next);
                return l2;
            }
        }
    }

    public class Test21
    {
        [Theory]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        [InlineData(new int[] { }, new int[] { 1, 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2 }, new int[] { }, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 1, 1, 2, 2 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [InlineData(
            new int[] { 1, 2, 4 },
            new int[] { 1, 3, 4 },
            new int[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(
            new int[] { 1, 1, 3, 5 },
            new int[] { 1, 1, 2, 4 },
            new int[] { 1, 1, 1, 1, 2, 3, 4, 5 })]
        [InlineData(
            new int[] { 7, 8, 9 },
            new int[] { 1, 1, 1, 1 },
            new int[] { 1, 1, 1, 1, 7, 8, 9 })]
        public void MergeTwoLists(int[] l1, int[] l2, int[] expected)
        {
            Assert.Equal(
                expected,
                new Solution21()
                    .MergeTwoLists(ListNode.FromCollection(l1), ListNode.FromCollection(l2))
                    .AsEnumerable());
        }
    }
}
