using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Merge_k_Sorted_Lists : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[] { 1, 3, 5 };
            var b = new int[] { 2 };
            var c = new int[] { 4 };

            List<ListNode> list = new List<ListNode>();
            list.Add(ListNode.Parse(a));
            list.Add(ListNode.Parse(b));
            list.Add(ListNode.Parse(c));
            var ret = MergeKLists(list.ToArray());
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

        public ListNode MergeKLists(ListNode[] lists)
        {
            ListNode head = null;
            ListNode cur = null;
            while (IsValid(lists))
            {
                int min = int.MaxValue;
                int minIndex = -1;

                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] != null && lists[i].val < min)
                    {
                        min = lists[i].val;
                        minIndex = i;
                    }
                }

                if (head == null)
                {
                    head = lists[minIndex];
                    cur = head;
                    lists[minIndex] = cur.next;
                }
                else
                {
                    cur.next = lists[minIndex];
                    cur = cur.next;
                    lists[minIndex] = cur.next;
                }
            }

            return head;
        }

        private bool IsValid(ListNode[] lists)
        {
            if (lists == null)
            {
                return false;
            }

            foreach(ListNode node in lists)
            {
                if (node != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
