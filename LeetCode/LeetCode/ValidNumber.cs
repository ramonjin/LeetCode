using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class ValidNumber : LeetCodeBase
    {
        public override void Run()
        {
            string a = " 0.1";
            string b = "-2e-10";
            string c = "-.";
            bool i = IsNumber(c);
            Console.WriteLine(i.ToString());
            Console.ReadKey();
        }

        public bool IsNumber(string s)
        {
            s = s.Trim();
            if (s.Length == 0)
            {
                return false;
            }

            int start = 0;
            if (s[0] == '+' || s[0] == '-')
            {
                start = 1;
            }

            bool hasE = false;
            bool hasDot = false;
            bool hasNum = false;
            bool hasOper = false;
            for (int i = start; i < s.Length; i++)
            {
                char c = s[i];

                if (IsDigit(c))
                {
                    if (!hasNum)
                    {
                        hasNum = true;
                    }
                    continue;
                }

                if (c == '.')
                {
                    if (hasDot)
                    {
                        // 已经有小数点
                        return false;
                    }
                    else if (hasE)
                    {
                        // 小数点在ｅ后
                        return false;
                    }

                    // 小数点前 可以是数字或者正负号
                    if (i > 0)
                    {
                        if (IsDigit(s[i - 1]) || IsOper(s[i - 1]) && i < s.Length - 1)
                        {
                            hasDot = true;
                            continue;
                        }
                    }

                    // 小数点后面，可以是e，可以是数字，或者没有东西
                    if (i < s.Length - 1)
                    {
                        if (IsDigit(s[i + 1]) || (s[i + 1] == 'e' && i > 0))
                        {
                            hasDot = true;
                            continue;
                        }
                    }

                    return false;
                }

                if (c == 'e')
                {
                    if (hasE)
                    {
                        return false;
                    }

                    // e在字符串最后
                    if (i == s.Length - 1)
                    {
                        return false;
                    }

                    if (i == start)
                    {
                        return false;
                    }

                    hasE = true;
                    continue;
                }

                if (IsOper(c))
                {
                    if (hasOper)
                    {
                        return false;
                    }

                    // + - 前面必须是e
                    if (s[i - 1] != 'e')
                    {
                        return false;
                    }

                    if (i == s.Length - 1)
                    {
                        return false;
                    }

                    hasOper = true;
                    continue;
                }

                // 其他情况
                return false;
            }

            return true;
        }

        private bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        private bool IsOper(char c)
        {
            return c == '+' || c == '-';
        }
    }
}
