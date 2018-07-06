using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Scramble_String : LeetCodeBase
    {
        public override void Run()
        {
            var a = "abb";
            var b = "bab";
            var ret = IsScramble(a, b);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public bool IsScramble(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            if (s1 == s2)
            {
                return true;
            }

            int[] charCount = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                charCount[s1[i] - 'a']++;
                charCount[s2[i] - 'a']--;
            }

            foreach (int count in charCount)
            {
                if (count != 0)
                {
                    return false;
                }
            }


            for (int mid = 1; mid < s1.Length; mid++)
            { 
                string s1Left = s1.Substring(0, mid);
                string s1Right = s1.Substring(mid);
                string s2Left = s2.Substring(0, mid);
                string s2Right = s2.Substring(mid);
                string s2LeftScramble = s2.Substring(0, s1.Length - mid);
                string s2RightScramble = s2.Substring(s1.Length - mid);

                if (IsScramble(s1Left, s2Left) && IsScramble(s1Right, s2Right))
                {
                    return true;
                }

                if (IsScramble(s1Left, s2RightScramble) && IsScramble(s1Right, s2LeftScramble))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
