using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Reverse_Nodes_in_k_Group : LeetCodeBase
    {
        public override void Run()
        {
            var a = new int[] { 1, 2 };
            var ret = ReverseKGroup(ListNode.Parse(a), 2);
            while (ret != null)
            {
                Console.WriteLine(ret.val);
                ret = ret.next;
            }
            Console.ReadKey();
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            int count = 0;
            List<ListNode> list = new List<ListNode>();
            ListNode temp = head;
            while (temp != null)
            {
                list.Add(temp);
                count++;
                temp = temp.next;
            }
            if (count < k)
            {
                return head;
            }

            int index = 0;
            while (index + k <= count)
            {
                int start = index;
                int end = index + k - 1;
                while (start < end)
                {
                    ListNode node = list[start];
                    list[start] = list[end];
                    list[end] = node;
                    start++;
                    end--;
                }

                index += k;
            }

            for (int i = 0; i < count - 1; i++)
            {
                list[i].next = list[i + 1];
            }
            list[count - 1].next = null;
            return list[0];
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
    }
}
