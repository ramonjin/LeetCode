using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Count_and_Say : LeetCodeBase
    {
        public override void Run()
        {
            var a = 5;
            var ret = CountAndSay(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public string CountAndSay(int n)
        {
            string ret = string.Empty;
            for (int i = 0; i < n; i++)
            {
                ret = CountSay(ret);
            }

            return ret;
        }

        private string CountSay(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return "1";
            }

            StringBuilder sb = new StringBuilder();
            char cur = ' ';
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (cur != str[i])
                {
                    if (count > 0)
                    {
                        sb.Append(count);
                        sb.Append(cur);
                    }

                    cur = str[i];
                    count = 1;
                }
                else
                {
                    count++;
                }
            }

            if (count > 0)
            {
                sb.Append(count);
                sb.Append(cur);
            }

            return sb.ToString();
        }
    }
}
