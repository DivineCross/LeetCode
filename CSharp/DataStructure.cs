using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.DataStructure
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode FromCollection(IEnumerable<int> collection)
        {
            if (collection == null)
                throw new ArgumentException($"'{nameof(collection)}' can not be null.");

            if (!collection.Any())
                return null;

            var head = new ListNode(collection.First());
            var node = head;
            foreach (var value in collection.Skip(1))
            {
                node.next = new ListNode(value);
                node = node.next;
            }

            return head;
        }
    }

    public static class ListNodeExtensions
    {
        public static IEnumerable<int> AsEnumerable(this ListNode head)
        {
            for (var node = head; node != null; node = node.next)
                yield return node.val;
        }
    }
}
