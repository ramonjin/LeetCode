using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class LetterCombinationsOfAPhoneNumber: LeetCodeBase
    {
        public override void Run()
        {
            var a = "23";
            var ret = LetterCombinations(a);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        private List<char>[] map =
        {
            new List<char>(),
            new List<char>(),
            new List<char>("abc"),
            new List<char>("def"),
            new List<char>("ghi"),
            new List<char>("jkl"),
            new List<char>("mno"),
            new List<char>("pqrs"),
            new List<char>("tuv"),
            new List<char>("wxyz"),
        };

        public IList<string> LetterCombinations(string digits)
        {
            ret = new List<string>();

            if (string.IsNullOrEmpty(digits))
            {
                return ret;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                int n = digits[i] - '0';
                if (n == 0 || n == 1)
                {
                    return ret;
                }
            }

            char[] c = new char[digits.Length];
            Generate(c, digits, 0);
            return ret;
        }

        private List<string> ret;
        private void Generate(char[] c, string digits, int cur)
        {
            if (cur == digits.Length)
            {
                ret.Add(new string(c));
                return;
            }

            int n = digits[cur] - '0';
            List<char> list = map[n];
            int len = list.Count;
            for (int i = 0; i < len; i++)
            {
                c[cur] = list[i];
                Generate(c, digits, cur + 1);
            }
        }
    }
}
