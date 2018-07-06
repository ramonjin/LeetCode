using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RepeatedSubstringPattern : LeetCodeBase
    {
        public override void Run()
        {
            string a = "abab";
            bool ret = Pattern(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public bool Pattern(string s)
        {
            for (int i = 1; i < s.Length / 2 + 1; i++)
            {
                if (s.Length % i != 0)
                {
                    continue;
                }

                bool find = true;
                for (int j = 0; j < i; j++)
                {
                    if (!StrJumpEqual(s, j, i))
                    {
                        find = false;
                        break;
                    }
                }

                if (find)
                {
                    return true;
                }
            }
            return false;
        }

        private bool StrJumpEqual(string s, int offset, int jump)
        {
            char c = s[offset];
            int index = offset + jump;
            while (index < s.Length)
            {
                if (s[index] != c)
                {
                    return false;
                }
                index += jump;
            }

            return true;
        }


        #region Another problem

        public bool HasRepeat(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                // 找到下一个s[i]
                int j = s.IndexOf(s[i], i + 1);
                if (j < 0 || j - i > s.Length - j)
                {
                    continue;
                }

                // 如果两个坐标之间的字符串完全相等，返回true
                bool find = true;
                for(int k = 0; k < j - i; k++)
                {
                    if (s[i + k] != s[j + k])
                    {
                        find = false;
                        break;
                    }
                }

                if (find)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}
