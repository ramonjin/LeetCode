using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class PalindromeNumber : LeetCodeBase
    {
        public override void Run()
        {
            int a = 121;
            bool ret = IsPalindrome(a);
            Console.WriteLine(ret.ToString());
            Console.ReadKey();
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0)
            {
                return false;
            }

            if (x < 10)
            {
                return true;
            }

            string str = x.ToString();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != str[str.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
