using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Remove_Nth_Node_From_End_of_List : LeetCodeBase
    {
        public override void Run()
        {
            ListNode n = new ListNode(1);
            ListNode head = n;
            n.next = new ListNode(2);
            n = n.next;
            n.next = new ListNode(3);
            n = n.next;
            n.next = new ListNode(4);
            n = n.next;
            n.next = new ListNode(5);
            n = n.next;

            var a = 5;
            var ret = RemoveNthFromEnd(head, a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                list.Add(cur);
                cur = cur.next;
            }

            int toRemove = list.Count - n;
            if (toRemove == 0)
            {
                head = head.next;
            }
            else
            {
                list[toRemove - 1].next = list[toRemove].next;
            }
            return head;
        }
    }
}
