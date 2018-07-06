using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ShortestPalindrome : LeetCodeBase
    {
        public override void Run()
        {
            string s = "aab";
            s = fuck(s);
            Console.WriteLine(s);
        }

        public string fuck(string s)
        {
            int diff = 0;
            while (diff < s.Length - 1)
            {
                bool find = true;
                for (int i = 0; i < s.Length - diff; i++)
                {
                    if (s[i] != s[s.Length - i - 1 - diff])
                    {
                        find = false;
                        break;
                    }
                }

                if (find)
                {
                    break;
                }
                diff++;
            }

            StringBuilder sb = new StringBuilder(s.Length + diff);
            for (int i = 0; i < diff; i++)
            {
                sb.Append(s[s.Length - i - 1]);
            }

            sb.Append(s);
            return sb.ToString();
        }
    }
}
