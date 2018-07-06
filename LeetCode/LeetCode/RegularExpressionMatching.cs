using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RegularExpressionMatching : LeetCodeBase
    {
        public override void Run()
        {
            string a = "aba";
            string b = "a*c*a";
            bool ret = IsMatch(a, b);
            Console.WriteLine(ret);
            Console.ReadKey();
        }

        public bool IsMatch(string s, string p)
        {
            return Match(s, 0, p, 0);
        }

        private bool Match(string s, int i, string p, int j)
        {
            // for s[i], p[j], 
            // if p[j + 1] != *, which is easy, if s[i] == p[j], test s[i+1] and p[j+1]
            // if p[j + 1] == *, where trouble comes, test all the way along.
            if (j >= p.Length)
            {
                return i == s.Length;
            }

            // 如果后面一个是*
            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                // 如果通过验证
                if (p[j] == '.' || (i < s.Length && s[i] == p[j]))
                {
                    if (Match(s, i, p, j + 2))
                    {
                        return true;
                    }

                    if (i < s.Length)
                    {
                        return Match(s, i + 1, p, j);
                    }
                    else
                    {
                        return Match(s, i, p, j + 2);
                    }
                }
                else
                {
                    // 没通过的话，掠过*
                    return Match(s, i, p, j + 2);
                }
            }
            else
            {
                if (i < s.Length && (p[j] == '.' || s[i] == p[j]))
                {
                    return Match(s, i + 1, p, j + 1);
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
