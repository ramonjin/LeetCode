using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LongestValidParentheses : LeetCodeBase
    {
        public override void Run()
        {
            // ()(((
            // ((()
            // ()((())
            // ()()
            // (()(()
            // (()(()))
            string a = "()(((";
            int ret = FindLongest(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public int FindLongest(string s)
        {
            int max = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }

                    max = Math.Max(max, i - stack.Peek());
                }
            }

            return max;
        }
    }
}
