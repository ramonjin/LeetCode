using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ImplementStrStr : LeetCodeBase
    {
        public override void Run()
        {
            string a = "mississippi";
            string b = "issip";
            int i = StrStr(a, b);
            Console.WriteLine(i.ToString());
            Console.ReadKey();
        }

        public int StrStr(string haystack, string needle)
        {
            int maxSearchIndex = haystack.Length - needle.Length;
            for (int i = 0; i <= maxSearchIndex; i++)
            {
                bool find = true;
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        find = false;
                        break;
                    }
                }

                if (find)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
