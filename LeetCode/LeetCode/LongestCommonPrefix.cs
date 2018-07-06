using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LongestCommonPrefix : LeetCodeBase
    {
        public override void Run()
        {
            string[] a = { "c", "c"};
            string ret = Prefix(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }
        public string Prefix(string[] strs)
        {
            if (strs.Length == 0)
            {
                return string.Empty;
            }

            if (strs.Length == 1)
            {
                return strs[0];
            }

            int minLen = int.MaxValue;
            foreach (string s in strs)
            {
                if (s.Length < minLen)
                {
                    minLen = s.Length;
                }
            }

            if (minLen == 0)
            {
                return string.Empty;
            }

            for (int index = 0; index < minLen; index++)
            {
                char c = strs[0][index];
                for (int i = 1; i < strs.Length; i++)
                {
                    if (strs[i][index] != c)
                    {
                        return strs[0].Substring(0, index);
                    }
                }
            }

            return strs[0].Substring(0, minLen);
        }
    }
}
