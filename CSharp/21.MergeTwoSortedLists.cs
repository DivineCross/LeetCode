using System;
using System.Collections.Generic;
using System.Linq;

using Xunit;

using LeetCode.DataStructure;

namespace LeetCode
{
    public partial class Solution
    {
        // https://leetcode.com/problems/merge-two-sorted-lists
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            ListNode tail = dummyHead;
            while (l1 != null && l2 != null)
            {
                ListNode next = null;
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

    public partial class Test
    {
        [Fact]
        public void MergeTwoLists()
        {
            Func<ListNode, ListNode, ListNode> mergeTwoLists = new Solution().MergeTwoLists;
            Func<int[], int[], int[]> merge = (l1, l2) =>
                mergeTwoLists(ListNode.FromCollection(l1), ListNode.FromCollection(l2)).AsEnumerable().ToArray();

            int[] x = null;
            int[] y = null;
            int[] a = null;

            x = new int[] {};
            y = new int[] {};
            a = new int[] {};
            Assert.Equal(a, merge(x, y));

            x = new int[] {};
            y = new int[] { 1, 2 };
            a = new int[] { 1, 2 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 1, 2 };
            y = new int[] {};
            a = new int[] { 1, 2 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 1, 1 };
            y = new int[] { 2, 2 };
            a = new int[] { 1, 1, 2, 2 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 1, 2 };
            y = new int[] { 3, 4 };
            a = new int[] { 1, 2, 3, 4 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 1, 4 };
            y = new int[] { 2, 3 };
            a = new int[] { 1, 2, 3, 4 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 1, 1, 3, 5 };
            y = new int[] { 1, 1, 2, 4 };
            a = new int[] { 1, 1, 1, 1, 2, 3, 4, 5 };
            Assert.Equal(a, merge(x, y));

            x = new int[] { 7, 8, 9 };
            y = new int[] { 1, 1, 1, 1 };
            a = new int[] { 1, 1, 1, 1, 7, 8, 9 };
            Assert.Equal(a, merge(x, y));
        }
    }
}
