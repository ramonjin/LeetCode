using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Merge_Two_Sorted_Lists : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[]{ 1, 3, 5 };
            var b = new int[] { 2 };
            var ret = MergeTwoLists(ListNode.Parse(a), ListNode.Parse(b));
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }

            public static ListNode Parse(IList<int> list)
            {
                if (list == null || list.Count == 0)
                {
                    return null;
                }

                ListNode head = new ListNode(list[0]);
                ListNode cur = head;
                for (int i = 1; i < list.Count; i++)
                {
                    ListNode temp = new ListNode(list[i]);
                    cur.next = temp;
                    cur = temp;
                }

                return head;
            }
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }

            if (l2 == null)
            {
                return l1;
            }

            ListNode head;
            if (l1.val < l2.val)
            {
                head = l1;
                l1 = l1.next;
            }
            else
            {
                head = l2;
                l2 = l2.next;
            }

            ListNode cur = head;
            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    cur.next = l2;
                    break;
                }

                if (l2 == null)
                {
                    cur.next = l1;
                    break;
                }

                if (l1.val < l2.val)
                {
                    cur.next = l1;
                    cur = l1;
                    l1 = l1.next;
                }
                else
                {
                    cur.next = l2;
                    cur = l2;
                    l2 = l2.next;
                }
            }

            return head;
        }
    }
}
