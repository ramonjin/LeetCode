using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RemoveInvalidParentheses : LeetCodeBase
    {
        public override void Run()
        {
            var a = "()(((((((()";
            var ret = Remove(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public IList<string> Remove(string s)
        {
            // 先找到要删除哪些东西
            Stack<char> stack = new Stack<char>();
            foreach(char c in s)
            {
                if (c != '(' && c != ')')
                {
                    continue;
                }

                if (c == ')' && stack.Count > 0 && stack.Peek() == '(')
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            // 再一个一个的删除试试看
            List<string> ret = new List<string>();
            ret.Add(s);
            while (stack.Count > 0)
            {
                char c = stack.Pop();
                List<string> temp = new List<string>();
                foreach (string str in ret)
                {
                    int index = str.IndexOf(c);
                    while (index != -1)
                    {
                        string tempStr = str.Remove(index, 1);
                        if (!temp.Contains(tempStr))
                        {
                            temp.Add(tempStr);
                        }
                        index = str.IndexOf(c, index + 1);
                    }
                }

                ret = temp;
            }
            
            // 删除不符合规则的
            for (int i = ret.Count - 1; i >= 0; i--)
            {
                bool good = true;
                int leftCount = 0;

                foreach(char c in ret[i])
                {
                    if (c == '(')
                    {
                        leftCount++;
                    }
                    else if (c == ')')
                    {
                        leftCount--;
                    }

                    if (leftCount < 0)
                    {
                        good = false;
                        break;
                    }
                }

                if (!good || leftCount != 0)
                {
                    ret.RemoveAt(i);
                }
            }

            return ret;
        }
    }
}
